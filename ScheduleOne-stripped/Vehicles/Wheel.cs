using System;
using ScheduleOne.Audio;
using ScheduleOne.Core;
using ScheduleOne.Experimental;
using ScheduleOne.Weather;
using UnityEngine;

namespace ScheduleOne.Vehicles;
public class Wheel : MonoBehaviour
{
    public const float SIDEWAY_SLIP_THRESHOLD;
    public const float FORWARD_SLIP_THRESHOLD;
    public const float DRIFT_AUDIO_THRESHOLD;
    public const float MIN_SPEED_FOR_DRIFT;
    public const float WHEEL_ANIMATION_DISTANCE;
    public const float HandbrakeFowardStiffnessMultiplier_Front;
    public const float HandbrakeSidewayStiffnessMultiplier_Front;
    public const float HandbrakeFowardStiffnessMultiplier_Rear;
    public const float HandbrakeSidewayStiffnessMultiplier_Rear;
    public bool DEBUG_MODE;
    [Header("References")]
    public Transform wheelModel;
    public Transform modelContainer;
    public WheelCollider wheelCollider;
    public Transform axleConnectionPoint;
    public Collider staticCollider;
    public ParticleSystem DriftParticles;
    [Header("Data")]
    [SerializeField]
    private WheelData _defaultData;
    [SerializeField]
    private WheelOverrideData _rainOverrideData;
    [Header("Settings")]
    public bool DriftParticlesEnabled;
    [Header("Drift Audio")]
    public bool DriftAudioEnabled;
    public AudioSourceController DriftAudioSource;
    private float defaultForwardStiffness;
    private float defaultSidewaysStiffness;
    private LandVehicle vehicle;
    private Vector3 lastFixedUpdatePosition;
    private WheelHit wheelData;
    private WheelFrictionCurve forwardCurve;
    private WheelFrictionCurve sidewaysCurve;
    private VehicleSettings _settings;
    public bool IsDrifting { get; protected set; }
    public bool IsDrifting_Smoothed => DriftTime > 0.2f;
    public float DriftTime { get; protected set; }
    public float DriftIntensity { get; protected set; }
    public bool IsSteerWheel { get; set; }

    private void Awake();
    protected virtual void Start();
    public void FixedUpdateWheel();
    public void FakeWheelRotation();
    private void CheckDrifting();
    private void UpdateDriftEffects();
    private void UpdateDriftAudio();
    private void ApplyFriction();
    public virtual void SetPhysicsEnabled(bool enabled);
    public bool IsWheelGrounded();
    public void OnWeatherChange(WeatherConditions newConditions);
    [Button]
    private void ApplyDefaultWheelModelPosition();
}