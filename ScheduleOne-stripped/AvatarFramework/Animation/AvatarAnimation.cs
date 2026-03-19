using System;
using System.Collections;
using RootMotion.FinalIK;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Skating;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.AvatarFramework.Animation;
public class AvatarAnimation : MonoBehaviour
{
    public enum EFlinchType
    {
        Light,
        Heavy
    }

    public enum EFlinchDirection
    {
        Forward,
        Backward,
        Left,
        Right
    }

    public const bool ImpostorsEnabled;
    public const float AnimationRangeSqr;
    public const float FrustrumCullMinDist;
    public const float RunningAnimationSpeed;
    public const float MaxBoneOffset;
    public const float MaxBoneOffsetSqr;
    public static Vector3 SITTING_OFFSET;
    public const float SEAT_TIME;
    private const string StandUpFromBackClipName;
    private const string StandUpFromFrontClipName;
    public bool DEBUG_MODE;
    [Header("References")]
    public Animator animator;
    public Transform HipBone;
    public Transform[] Bones;
    protected Avatar avatar;
    public Transform LeftHandContainer;
    public Transform RightHandContainer;
    public Transform RightHandAlignmentPoint;
    public Transform LeftHandAlignmentPoint;
    public AvatarIKController IKController;
    public AvatarFootstepDetector FootstepDetector;
    [Header("Settings")]
    public LayerMask GroundingMask;
    public bool AllowCulling;
    public UnityEvent onStandupStart;
    public UnityEvent onStandupDone;
    public UnityEvent onHeavyFlinch;
    private BoneTransform[] standUpFromBackBoneTransforms;
    private BoneTransform[] standUpFromFrontBoneTransforms;
    private BoneTransform[] ragdollBoneTransforms;
    private Coroutine standUpRoutine;
    private Coroutine seatRoutine;
    private Skateboard activeSkateboard;
    private bool animationEnabled;
    public bool IsCrouched { get; protected set; }
    public bool IsSeated => (Object)(object)CurrentSeat != (Object)null;
    public float TimeSinceSitEnd { get; protected set; } = 1000f;
    public AvatarSeat CurrentSeat { get; protected set; }
    public bool StandUpAnimationPlaying { get; protected set; }
    public bool IsAvatarCulled { get; private set; }

    protected virtual void Awake();
    private void Start();
    private void Update();
    private void UpdateAnimationActive();
    public void SetDirection(float dir);
    public void SetStrafe(float strafe);
    public void SetTimeAirborne(float airbone);
    public void SetCrouched(bool crouched);
    public void SetGrounded(bool grounded);
    public void Jump();
    public void SetAnimationEnabled(bool enabled);
    public void ResetAnimatorState();
    public void Flinch(Vector3 forceDirection, EFlinchType flinchType);
    public void PlayStandUpAnimation();
    protected void RagdollChange(bool wasRagdolled, bool ragdoll, bool playStandUpAnim);
    private void AlignPositionToHips();
    private bool ShouldGetUpFromBack();
    private void PopulateBoneTransforms(BoneTransform[] boneTransforms);
    private void PopulateAnimationStartBoneTransforms(string clipName, BoneTransform[] boneTransforms);
    public void SetTrigger(string trigger);
    public void ResetTrigger(string trigger);
    public void SetBool(string id, bool value);
    public void SetSeat(AvatarSeat seat);
    public void SkateboardMounted(Skateboard board);
    public void SkateboardDismounted();
    private void SkateboardPush();
}