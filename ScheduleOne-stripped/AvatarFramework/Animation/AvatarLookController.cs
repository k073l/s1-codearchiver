using System.Collections.Generic;
using System.Linq;
using FishNet.Object;
using RootMotion.FinalIK;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.AvatarFramework.Animation;
public class AvatarLookController : MonoBehaviour
{
    public const float LookAtPlayerRange;
    public const float EyeContractRange;
    public const float AimIKRange;
    public bool DEBUG;
    [Header("References")]
    public AimIK Aim;
    public Transform HeadBone;
    public Transform LookForwardTarget;
    public Transform LookOrigin;
    public EyeController Eyes;
    [Header("Optional NPC reference")]
    public NPC NPC;
    [Header("Settings")]
    public bool AutoLookAtPlayer;
    public float LookLerpSpeed;
    public float AimIKWeight;
    public float BodyRotationSpeed;
    private Avatar avatar;
    private Vector3 lookAtPos;
    private Transform lookAtTarget;
    private Vector3 lastFrameOffset;
    private bool overrideLookAt;
    private Vector3 overriddenLookTarget;
    private int overrideLookPriority;
    private bool overrideRotateBody;
    private bool blockLookOverrides;
    private Vector3 lastFrameLookOriginPos;
    private Vector3 lastFrameLookOriginForward;
    public Transform ForceLookTarget;
    public bool ForceLookRotateBody;
    private float defaultIKWeight;
    private Player nearestPlayer;
    private float nearestPlayerDist;
    private float localPlayerDist;
    private float cullRange;
    public float BodyRotationSpeedMultiplier { get; set; } = 1f;

    private void Awake();
    private void UpdateLook();
    private void UpdateNearestPlayer();
    private void LateUpdate();
    public unsafe void OverrideLookTarget(Vector3 targetPosition, int priority, bool rotateBody = false);
    public void BlockLookTargetOverrides();
    private void LookForward();
    private void LerpTargetTransform();
    private Player GetNearestPlayer();
    private bool CanLookAt(Vector3 position);
    protected void RagdollChange(bool oldValue, bool ragdoll, bool playStandUpAnim);
    public void OverrideIKWeight(float weight);
    public void ResetIKWeight();
}