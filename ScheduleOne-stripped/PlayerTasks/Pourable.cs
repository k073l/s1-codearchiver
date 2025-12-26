using System;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Growing;
using ScheduleOne.Trash;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScheduleOne.PlayerTasks;
[RequireComponent(typeof(Accelerometer))]
public class Pourable : Draggable
{
    public Action onInitialPour;
    [Header("Pourable settings")]
    public bool Unlimited;
    public float StartQuantity;
    public float PourRate_L;
    public float AngleFromUpToPour;
    [Tooltip("Multiplier for pour rate when pourable is shaken up and down")]
    public float ShakeBoostRate;
    public bool AffectsCoverage;
    [Header("Particles")]
    public float ParticleMinMultiplier;
    public float ParticleMaxMultiplier;
    [Header("Pourable References")]
    public ParticleSystem[] PourParticles;
    public Transform PourPoint;
    public AudioSourceController PourLoop;
    [Header("Trash")]
    public TrashItem TrashItem;
    [HideInInspector]
    public GrowContainer TargetGrowContainer;
    protected bool hasPoured;
    protected bool autoSetCurrentQuantity;
    private float[] particleMinSizes;
    private float[] particleMaxSizes;
    private AverageAcceleration accelerometer;
    public bool IsPouring { get; protected set; }
    public float NormalizedPourRate { get; private set; }
    public float CurrentQuantity { get; protected set; }

    protected virtual void Start();
    protected override void Update();
    protected override void FixedUpdate();
    protected virtual void UpdatePouring();
    private float GetShakeBoost();
    protected virtual void PourAmount(float amount);
    protected bool IsPourPointOverPot();
    protected virtual bool CanPour();
}