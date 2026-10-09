using System;
using System.Collections;
using RootMotion.FinalIK;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Skating;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace ScheduleOne.AvatarFramework.Animation;
public class AvatarAnimation : MonoBehaviour
{
    public struct BoneTransform
    {
        public Vector3 Position;
        public Quaternion Rotation;
    }

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

    private const float MaxDirectionSpeed;
    private const float MaxStrafeSpeed;
    private const float MaxCrouchDirectionSpeed;
    private const float MaxCrouchStrafeSpeed;
    private const float MotionParameterLerpSpeed;
    public const float SitTransitionDuration;
    private static readonly Vector3 SittingOffset;
    private const string StandUpFromBackClipName;
    private const string StandUpFromFrontClipName;
    public Action OnStandupStart;
    public Action OnStandupDone;
    [Header("References")]
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    [FormerlySerializedAs("Bones")]
    private Transform[] _bones;
    [SerializeField]
    private AvatarIKController _ikController;
    [SerializeField]
    private AvatarFootstepDetector _footstepDetector;
    [Header("Settings")]
    [Range(10f, 100f)]
    public float VisibilityRange;
    public AnimationCurve DirectionAnimationValueCurve;
    public AnimationCurve StrafeAnimationValueCurve;
    public AnimationCurve CrouchMovementAnimationValue;
    private Avatar avatar;
    private BoneTransform[] standUpFromBackBoneTransforms;
    private BoneTransform[] standUpFromFrontBoneTransforms;
    private BoneTransform[] ragdollBoneTransforms;
    private Coroutine standUpRoutine;
    private Coroutine seatRoutine;
    private Skateboard activeSkateboard;
    private bool animationEnabled;
    private BoneTransform[] _lastFrameBoneTransforms;
    private bool _lastFrameBoneTransformsValid;
    private bool _activateRagdollNextFrame;
    private float _currentStrafe;
    private float _currentDirection;
    private float _targetStrafe;
    private float _targetDirection;
    private Vector3 _currentMotion;
    public bool IsCrouched { get; protected set; }
    public bool IsSeated => (Object)(object)CurrentSeat != (Object)null;
    public float TimeSinceSitEnd { get; protected set; } = 1000f;
    public AvatarSeat CurrentSeat { get; protected set; }
    public bool StandUpAnimationPlaying { get; protected set; }

    protected virtual void Awake();
    private void Start();
    private void Update();
    private void LateUpdate();
    public void SetFootstepVolumeMultiplier(float volume);
    public void SetMotion(Vector3 relativeMotion, bool isCrouched);
    private float UpdateBlend(float relativeMotion, float maxSpeed, AnimationCurve curve);
    private void SetDirection(float dir);
    private void SetStrafe(float strafe);
    public void SetTimeAirborne(float airbone);
    public void SetCrouched(bool crouched);
    public void SetGrounded(bool grounded);
    public void Jump();
    private void SetAnimationEnabled(bool enabled);
    private void RefreshAnimatorActive();
    public void ResetAnimatorState();
    public void Flinch(Vector3 forceDirection, EFlinchType flinchType);
    private void PlayStandUpAnimation();
    protected void RagdollChange(bool ragdoll);
    private bool IsHipBoneFacingUpwards();
    private void PopulateBoneTransforms(BoneTransform[] boneTransforms);
    private void PopulateAnimationStartBoneTransforms(string clipName, BoneTransform[] boneTransforms);
    private void ApplyBoneTransforms(BoneTransform[] boneTransforms);
    public void SetTrigger(string trigger);
    public void ResetTrigger(string trigger);
    public void SetBool(string id, bool value);
    public void SetFloat(string id, float value);
    public void SetSeat(AvatarSeat seat, string animationId = "", float sitTransitionDuration = 0.35f);
    public void SkateboardMounted(Skateboard board);
    public void SkateboardDismounted();
    private void SkateboardPush();
}