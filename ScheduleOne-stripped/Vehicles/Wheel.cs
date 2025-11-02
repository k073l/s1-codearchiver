using System;
using ScheduleOne.Audio;
using UnityEngine;

namespace ScheduleOne.Vehicles;
public class Wheel : MonoBehaviour
{
    public const float SIDEWAY_SLIP_THRESHOLD;
    public const float FORWARD_SLIP_THRESHOLD;
    public const float DRIFT_AUDIO_THRESHOLD;
    public const float MIN_SPEED_FOR_DRIFT;
    public const float WHEEL_ANIMATION_DISTANCE;
    public bool DEBUG_MODE;
    [Header("References")]
    public Transform wheelModel;
    public Transform modelContainer;
    public WheelCollider wheelCollider;
    public Transform axleConnectionPoint;
    public Collider staticCollider;
    public ParticleSystem DriftParticles;
    [Header("Settings")]
    public bool DriftParticlesEnabled;
    public float ForwardStiffnessMultiplier_Handbrake;
    public float SidewayStiffnessMultiplier_Handbrake;
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
    private Transform wheelTransform;
    public bool isStatic { get; protected set; }
    public bool IsDrifting { get; protected set; }
    public bool IsDrifting_Smoothed => DriftTime > 0.2f;
    public float DriftTime { get; protected set; }
    public float DriftIntensity { get; protected set; }

    protected virtual void Start();
    public void FixedUpdateWheel();
    private void CheckDrifting();
    private void UpdateDriftEffects();
    private void UpdateDriftAudio();
    private void ApplyFriction();
    public virtual void SetIsStatic(bool s);
    private void GroundWheelModel();
    public bool IsWheelGrounded();
}