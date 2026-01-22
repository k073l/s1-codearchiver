using System;
using System.Collections;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Vehicles.Sound;
public class VehicleSound : MonoBehaviour
{
    public const float COLLISION_SOUND_COOLDOWN;
    public const float AUDIO_LERP_SPEED;
    public const float MinCollisionMomentum;
    public const float MaxCollisionMomentum;
    public const float MinCollisionVolume;
    public const float MaxCollisionVolume;
    public const float MinCollisionPitch;
    public const float MaxCollisionPitch;
    public float EngineVolumeMultiplier;
    public float EnginePitchMultiplier;
    [Header("References")]
    public AudioSourceController EngineStartSource;
    public AudioSourceController EngineIdleSource;
    public AudioSourceController EngineLoopSource;
    public AudioSourceController HandbrakeSource;
    public AudioSourceController ImpactSound;
    [Header("Engine Loop Settings")]
    public AnimationCurve EngineLoopPitchCurve;
    public AnimationCurve EngineLoopVolumeCurve;
    private float lastCollisionTime;
    private float lastCollisionMomentum;
    private Coroutine volumeRoutine;
    public LandVehicle Vehicle { get; private set; }

    protected virtual void Awake();
    private void EngineStart();
    private void HandbrakeApplied();
    private void StartUpdateVolume();
    private void UpdateIdle(bool engineRunning);
    private void UpdateEngineLoop(bool engineRunning, float normalizedspeed);
    private void OnCollision(Collision collision);
}