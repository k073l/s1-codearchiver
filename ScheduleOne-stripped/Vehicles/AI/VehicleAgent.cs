using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using Pathfinding;
using ScheduleOne.DevUtilities;
using ScheduleOne.Math;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Vehicles.AI;
[RequireComponent(typeof(LandVehicle))]
public class VehicleAgent : MonoBehaviour
{
    public enum ENavigationResult
    {
        Failed,
        Complete,
        Stopped
    }

    public enum EAgentStatus
    {
        Inactive,
        MovingToRoad,
        OnRoad
    }

    public enum EPathGroupStatus
    {
        Inactive,
        Calculating
    }

    public enum ESweepType
    {
        FL,
        FR,
        RL,
        RR
    }

    public delegate void NavigationCallback(ENavigationResult status);
    public const string VehicleGraphName;
    public const string RoadGraphName;
    public const float MaxDistanceFromPath;
    public const float MaxDistanceFromPathWhenReversing;
    public static Vector3 MainGraphSamplePoint;
    public static float MinRenavigationRate;
    public const float Steer_P;
    public const float Steer_I;
    public const float Steer_D;
    public const float Throttle_P;
    public const float Throttle_I;
    public const float Throttle_D;
    public const float Steer_Rate;
    public const float MaxAxlePositionShift;
    public const float OBSTACLE_MIN_RANGE;
    public const float OBSTACLE_MAX_RANGE;
    public const float MAX_STEER_ANGLE_OVERRIDE;
    public const float KINEMATIC_MODE_MIN_DISTANCE;
    public const float INFREQUENT_UPDATE_RATE;
    public bool DEBUG_MODE;
    public DriveFlags Flags;
    [Header("Seekers")]
    [SerializeField]
    protected Seeker roadSeeker;
    [SerializeField]
    protected Seeker generalSeeker;
    [Header("References")]
    [SerializeField]
    protected Transform CTE_Origin;
    [SerializeField]
    protected Transform FrontAxlePosition;
    [SerializeField]
    protected Transform RearAxlePosition;
    [Header("Sensors")]
    [SerializeField]
    protected Sensor sensor_FL;
    [SerializeField]
    protected Sensor sensor_FM;
    [SerializeField]
    protected Sensor sensor_FR;
    [SerializeField]
    protected Sensor sensor_RR;
    [SerializeField]
    protected Sensor sensor_RL;
    private Sensor[] sensors;
    [Header("Sweeping")]
    [SerializeField]
    protected LayerMask sweepMask;
    [SerializeField]
    protected Transform sweepOrigin_FL;
    [SerializeField]
    protected Transform sweepOrigin_FR;
    [SerializeField]
    protected Transform sweepOrigin_RL;
    [SerializeField]
    protected Transform sweepOrigin_RR;
    [SerializeField]
    protected Wheel leftWheel;
    [SerializeField]
    protected Wheel rightWheel;
    protected const float sweepSegment;
    [Header("Path following")]
    protected float sampleStepSizeMin;
    protected float sampleStepSizeMax;
    protected int aheadPointSamples;
    protected const float DestinationDistanceSlowThreshold;
    protected const float DestinationArrivalThreshold;
    [Header("Steer settings")]
    [SerializeField]
    protected float steerTargetFollowRate;
    private SteerPID steerPID;
    [Header("Turning speed reduction")]
    protected float turnSpeedReductionMinRange;
    protected float turnSpeedReductionMaxRange;
    protected float turnSpeedReductionDivisor;
    private float minTurnSpeedReductionAngleThreshold;
    private float minTurningSpeed;
    [Header("Throttle")]
    [SerializeField]
    protected float throttleMin;
    [SerializeField]
    protected float throttleMax;
    private PID throttlePID;
    public static float UnmarkedSpeed;
    public static float ReverseSpeed;
    private ValueTracker speedReductionTracker;
    [Header("Pursuit Mode")]
    public bool PursuitModeEnabled;
    public Transform PursuitTarget;
    public float PursuitDistanceUpdateThreshold;
    private Vector3 PursuitTargetLastPosition;
    [Header("Stuck Detection")]
    public VehicleTeleporter Teleporter;
    public PositionHistoryTracker PositionHistoryTracker;
    public float StuckTimeThreshold;
    public int StuckSamples;
    public float StuckDistanceThreshold;
    protected NavigationCallback storedNavigationCallback;
    protected SpeedZone currentSpeedZone;
    protected LandVehicle vehicle;
    protected float wheelbase;
    protected float wheeltrack;
    protected float vehicleLength;
    protected float vehicleWidth;
    protected float turnRadius;
    protected float sweepTrack;
    private float wheelBottomOffset;
    [Header("Control info - READONLY")]
    [SerializeField]
    protected float targetSpeed;
    [SerializeField]
    protected float targetSteerAngle_Normalized;
    protected float lateralOffset;
    protected PathSmoothingUtility.SmoothedPath path;
    private float timeSinceLastNavigationCall;
    private float sweepTestFailedTime;
    private NavigationSettings currentNavigationSettings;
    private Coroutine navigationCalculationRoutine;
    private Coroutine reverseCoroutine;
    public bool KinematicMode { get; protected set; }
    public bool AutoDriving { get; protected set; }
    public bool IsReversing => reverseCoroutine != null;
    public Vector3 TargetLocation { get; protected set; } = Vector3.zero;
    protected float sampleStepSize => Mathf.Lerp(sampleStepSizeMin, sampleStepSizeMax, Mathf.Clamp01(vehicle.speed_Kmh / vehicle.TopSpeed));
    protected float turnSpeedReductionRange => Mathf.Lerp(turnSpeedReductionMinRange, turnSpeedReductionMaxRange, Mathf.Clamp(vehicle.speed_Kmh / vehicle.TopSpeed, 0f, 1f));
    protected float maxSteerAngle => vehicle.ActualMaxSteeringAngle;
    private Vector3 FrontOfVehiclePosition => ((Component)this).transform.position + ((Component)this).transform.forward * vehicleLength / 2f;
    public bool NavigationCalculationInProgress => navigationCalculationRoutine != null;

    private void Awake();
    protected virtual void Start();
    private void InitializeVehicleData();
    protected virtual void FixedUpdate();
    protected void InfrequentUpdate();
    protected void LateUpdate();
    protected void UpdateKinematic(float deltaTime);
    private Vector3 GetAxleGroundHit(bool front);
    private void UpdateSweep();
    private void UpdateSpeedReduction();
    private void UpdatePursuitMode();
    private void UpdateStuckDetection();
    private void CheckDistanceFromPath();
    private void UpdateOvertaking();
    protected virtual void RefreshSpeedZone();
    protected virtual void UpdateSpeed();
    protected void UpdateSteering();
    public void Navigate(Vector3 location, NavigationSettings settings = null, NavigationCallback callback = null);
    private void NavigationCalculationCallback(NavigationUtility.ENavigationCalculationResult result, PathSmoothingUtility.SmoothedPath _path);
    private void EndDriving();
    public void StopNavigating();
    public void RecalculateNavigation();
    public bool SweepTurn(ESweepType sweep, float sweepAngle, bool reverse, out float hitDistance, out Vector3 hitPoint, float steerAngle = 0f);
    public void BetterSweepTurn(ESweepType sweep, float steerAngle, bool reverse, LayerMask mask, out float hitDistance, out RaycastHit hit);
    public void StartReverse();
    public IEnumerator Reverse();
    private void StopReversing();
    private Collider GetClosestForwardObstruction(out float obstructionDist);
    public bool IsOnVehicleGraph();
    private float GetDistanceFromVehicleGraph();
    private Vector3 GetPathLateralDirection();
    public bool GetIsStuck();
}