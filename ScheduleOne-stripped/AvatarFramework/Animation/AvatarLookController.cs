using FishNet.Object;
using RootMotion.FinalIK;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.AvatarFramework.Animation;
public class AvatarLookController : MonoBehaviour
{
    private const float CullRange;
    private const float CullRangeSqr;
    public const float LookAtPlayerRange;
    public const float EyeContractRange;
    public static Transform TempContainer;
    public bool DEBUG;
    [Header("References")]
    public AimIK Aim;
    public Transform HeadBone;
    public Transform LookForwardTarget;
    public Transform LookOrigin;
    public EyeController Eyes;
    [Header("Settings")]
    public bool AutoLookAtPlayer;
    public float LookLerpSpeed;
    public float AimIKWeight;
    public float BodyRotationSpeed;
    protected NPC _npc;
    private Avatar avatar;
    private Vector3 lookAtPos;
    private Transform lookAtTarget;
    private Vector3 lastFrameOffset;
    private bool overrideLookAt;
    private Vector3 overriddenLookTarget;
    private int overrideLookPriority;
    private bool overrideRotateBody;
    private bool blockLookOverrides;
    public Transform ForceLookTarget;
    public bool ForceLookRotateBody;
    private float defaultIKWeight;
    private Player nearestPlayer;
    private float nearestPlayerDist;
    private float localPlayerSqrDist;
    private static readonly ProfilerMarker updateLookMarker;
    private static readonly ProfilerMarker lerpTargetMarker;
    private static readonly ProfilerMarker eyeLookAtMarker;
    public float BodyRotationSpeedMultiplier { get; set; } = 1f;

    private void Awake();
    private void UpdateLook();
    private void UpdateNearestPlayer();
    private void LateUpdate();
    public unsafe void OverrideLookTarget(Vector3 targetPosition, int priority, bool rotateBody = false);
    public void BlockLookTargetOverrides();
    private void LookForward();
    private void LerpTargetTransform();
    private bool CanLookAt(Vector3 position);
    protected void RagdollChange(bool oldValue, bool ragdoll, bool playStandUpAnim);
    public void OverrideIKWeight(float weight);
    public void ResetIKWeight();
}