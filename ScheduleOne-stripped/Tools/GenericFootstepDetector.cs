using ScheduleOne.Audio;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.GamePhysics;
using ScheduleOne.Materials;
using UnityEngine;

namespace ScheduleOne.Tools;
public abstract class GenericFootstepDetector : MonoBehaviour
{
    private const float GroundDetectionRange;
    private const float GroundDetectionRayOriginShift;
    [SerializeField]
    private float _baseVolume;
    [SerializeField]
    private float _stepDetectionCooldown;
    [SerializeField]
    protected Transform _referencePoint;
    private float _timeOnLastStep;
    private static LayerMask _groundDetectionLayerMask;
    public float VolumeMultiplier { get; set; } = 1f;

    private void Awake();
    protected virtual void Start();
    protected void TriggerStep(EMaterialType materialType, Vector3 stepPosition);
    protected bool IsCooldown();
    protected bool IsGrounded(out EMaterialType surfaceType);
}