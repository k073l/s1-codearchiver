using ScheduleOne.Audio;
using ScheduleOne.Core;
using UnityEngine;
using UnityEngine.VFX;

namespace ScheduleOne.Vehicles;
[RequireComponent(typeof(Rigidbody))]
public class MotorbikeBurnout : MonoBehaviour
{
    [Header("Setup")]
    [Tooltip("Transform at the front wheel's ground contact point. The burnout pivots around this.")]
    [SerializeField]
    private Transform frontWheelContact;
    [SerializeField]
    private Transform rearWheelVisual;
    [Header("Burnout Behaviour")]
    [Tooltip("Max degrees the rear end swings left/right from center.")]
    [SerializeField]
    private float maxSwingAngle;
    [Tooltip("How fast the wobble's target angle drifts. Higher = twitchier, more frantic.")]
    [SerializeField]
    private float wobbleSpeed;
    [Tooltip("How hard the 'tire' pulls the bike toward the current wobble target. Lower = looser, lazier fishtail (less lateral grip).")]
    [SerializeField]
    private float swingSpring;
    [Tooltip("Resistance to the swing motion. Higher = less overshoot/oscillation.")]
    [SerializeField]
    private float swingDamper;
    [Tooltip("Purely cosmetic rear wheel spin speed while burning out.")]
    [SerializeField]
    private float rearWheelRPM;
    [Header("Slide Lean")]
    [Tooltip("Visual mesh root to bank into the slide. Assign a CHILD of this object, not this object itself - the rigidbody's own rotation is owned by the hinge joint, so rolling it directly here would fight the physics. Leave empty to skip the lean effect.")]
    [SerializeField]
    private Transform leanVisual;
    [Tooltip("Max degrees the visual rolls into the direction of the slide.")]
    [SerializeField]
    private float maxLeanAngle;
    [Tooltip("Degrees/sec the lean angle can change by. Higher = snaps into the lean, lower = smoother/heavier feel.")]
    [SerializeField]
    private float leanSpeed;
    [Header("Burnout Settings")]
    [SerializeField]
    private float burnoutInterruptThreshold;
    [SerializeField]
    private float burnoutDuration;
    [Header("Burnout Effects")]
    [SerializeField]
    private AudioSourceController _burnoutAudio;
    [SerializeField]
    private VisualEffect burnoutEffect;
    private Rigidbody rb;
    private Rigidbody anchorBody;
    private HingeJoint pivotJoint;
    private float noiseOffset;
    private float currentLeanAngle;
    private float _burnoutTimer;
    public bool BurnoutActive { get; private set; }
    public float BurnoutInterruptThreshold => burnoutInterruptThreshold;

    private void Awake();
    [Button]
    public void BeginBurnout();
    [Button]
    public void EndBurnout();
    private void Update();
    private void FixedUpdate();
    private void UpdateLean();
}