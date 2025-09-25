using System;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Lighting;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Police;
using ScheduleOne.Vehicles;
using ScheduleOne.Vehicles.AI;
using ScheduleOne.Vision;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class VehiclePursuitBehaviour : Behaviour
{
    public const float RECENT_VISIBILITY_THRESHOLD;
    public const float EXIT_VEHICLE_MAX_SPEED;
    public const float CLOSE_ENOUGH_THRESHOLD;
    public const float UPDATE_FREQUENCY;
    public const float STATIONARY_THRESHOLD;
    public const float TIME_STATIONARY_TO_EXIT;
    [Header("Settings")]
    public AnimationCurve RepathDistanceThresholdMap;
    public LandVehicle vehicle;
    private bool initialContactMade;
    private bool aggressiveDrivingEnabled;
    private float timeSinceLastSighting;
    private bool visionEventReceived;
    private int consecutiveVehiclePathingFailures;
    private float timeStationary;
    private Vector3 currentDriveTarget;
    private int targetChanges;
    private float timeSincePursuitStart;
    private bool beginAsSighted;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EVehiclePursuitBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EVehiclePursuitBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public Player Target { get; protected set; }
    public bool IsTargetRecentlyVisible { get; private set; }
    public bool IsTargetImmediatelyVisible { get; private set; }
    private bool isDriving => (Object)(object)vehicle.OccupantNPCs[0] == (Object)(object)base.Npc;
    private VehicleAgent Agent => vehicle.Agent;

    public override void Awake();
    private void OnDestroy();
    public void BeginAsSighted();
    protected override void Begin();
    protected override void Resume();
    protected override void Pause();
    protected override void End();
    public virtual void AssignTarget(Player target);
    private void StartPursuit();
    public override void BehaviourUpdate();
    public override void ActiveMinPass();
    protected virtual void FixedUpdate();
    private void UpdateDestination();
    private bool IsTargetValid();
    private void CheckExitVehicle();
    private Vector3 GetPlayerChasePoint();
    private void SetAggressiveDriving(bool aggressive);
    private void DriveTo(Vector3 location);
    private void NavigationCallback(VehicleAgent.ENavigationResult status);
    private bool IsAsCloseAsPossible(Vector3 pos, out Vector3 closestPosition);
    protected void CheckTargetVisibility();
    public void MarkPlayerVisible();
    protected bool IsTargetVisible();
    private void ProcessVisionEvent(VisionEventReceipt visionEventReceipt);
    private void ProcessThirdPartyVisionEvent(VisionEventReceipt visionEventReceipt);
    protected virtual void TargetSpotted();
    [ServerRpc(RequireOwnership = false)]
    public void NotifyServerTargetSeen();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_NotifyServerTargetSeen_2166136261();
    public void RpcLogic___NotifyServerTargetSeen_2166136261();
    private void RpcReader___Server_NotifyServerTargetSeen_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EVehiclePursuitBehaviour_Assembly_002DCSharp_002Edll();
}