using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.Map;
using ScheduleOne.Tools;
using ScheduleOne.UI;
using ScheduleOne.Vehicles;
using ScheduleOne.Vision;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace ScheduleOne.PlayerScripts;
public class PlayerMovement : PlayerSingleton<PlayerMovement>
{
    public const float DevSprintMultiplier;
    public const float WalkSpeed;
    public static float StaticMoveSpeedMultiplier;
    public const float InputSensitivity;
    public const float InputDeadZone;
    public const float SlipperyMovementMultiplier;
    public const float GroundedThreshold;
    public const float SlopeThreshold;
    public const float SlopeForce;
    public const float SlopeForceRayLength;
    public const float ControllerRadius;
    public const float DefaultCharacterControllerHeight;
    public const float CrouchHeightMultiplier;
    public const float CrouchTime;
    public const float CrouchSpeedMultipler;
    public const float CrouchedVigIntensity;
    public const float CrouchedVigSmoothness;
    public const bool SprintingRequiresStamina;
    public const float SprintChangeRate;
    public const float SprintMultiplier;
    public const float StaminaDrainRate;
    public const float StaminaRestoreRate;
    public const float StaminaRestoreDelay;
    public static float StaminaReserveMax;
    public const float JumpForce;
    public static float JumpMultiplier;
    public static float GravityMultiplier;
    public const float BaseGravityMultiplier;
    public const float VerticalLadderSpeedMultiplier;
    public const float LateralLadderSpeedMultiplier;
    public const float LadderTopBuffer;
    public const float LadderPitchAdjustment;
    public const float DismountForce;
    public const float DismountForceDuration;
    [Header("References")]
    public Player Player;
    public CharacterController Controller;
    [Header("Jump/fall settings")]
    [FormerlySerializedAs("groundDetectionMask")]
    public LayerMask GroundDetectionMask;
    public readonly FloatStack MoveSpeedMultiplierStack;
    public Action<float> onStaminaReserveChanged;
    public Action onJump;
    public Action onLand;
    public Action onCrouch;
    public Action onUncrouch;
    private Vector3 movement;
    private Vector3 lastFrameMovement;
    private float movementY;
    private float timeOnLadderDismount;
    private Vector3 ladderDismountDir;
    private float horizontalAxis;
    private float verticalAxis;
    private Dictionary<int, MotionEvent> movementEvents;
    private float timeSinceStaminaDrain;
    private bool sprintActive;
    private bool sprintReleased;
    private List<string> sprintBlockers;
    private Vector3 residualVelocityDirection;
    private float residualVelocityForce;
    private float residualVelocityDuration;
    private float residualVelocityTimeRemaining;
    private bool teleport;
    private Vector3 teleportPosition;
    private float playerLadderYPosOnLastClimbSound;
    private Coroutine playerRotCoroutine;
    public bool CanMove { get; set; } = true;
    public bool CanJump { get; set; } = true;
    public Vector3 Movement => movement;
    public bool IsJumping { get; private set; }
    public float TimeAirborne { get; private set; }
    public float TimeGrounded { get; private set; }
    public bool IsGrounded { get; private set; } = true;
    public bool IsCrouched { get; private set; }
    public float StandingScale { get; private set; } = 1f;
    public bool IsRagdolled { get; private set; }
    public bool IsSprinting { get; private set; }
    public bool ForceSprint { get; set; }
    public float CurrentStaminaReserve { get; private set; } = StaminaReserveMax;
    public float CurrentSprintMultiplier { get; private set; } = 1f;
    public LandVehicle CurrentVehicle { get; protected set; }
    public Ladder CurrentLadder { get; set; }
    public bool IsOnLadder => (Object)(object)CurrentLadder != (Object)null;
    public float MoveSpeedMultiplier => MoveSpeedMultiplierStack.Value;

    protected override void Awake();
    protected override void Start();
    private void Update();
    private void FixedUpdate();
    private void LateUpdate();
    private void Move();
    private void ClampMovement();
    private float GetSurfaceAngle();
    private bool GetIsGrounded();
    public unsafe void Teleport(Vector3 position, bool alignFeetToPosition = false);
    public void SetResidualVelocity(Vector3 dir, float force, float time);
    public void WarpToNavMesh();
    private void UpdateHorizontalAxis();
    private void UpdateVerticalAxis();
    public void Jump();
    public void SetCrouched(bool c);
    private void TryToggleCrouch();
    private bool CanStand();
    private void UpdateCrouchVignetteEffect();
    private void UpdatePlayerHeight();
    public void LerpPlayerRotation(Quaternion rotation, float lerpTime);
    private IEnumerator LerpPlayerRotation_Process(Quaternion endRotation, float lerpTime);
    public void SetPlayerRotation(Quaternion rotation);
    private void EnterVehicle(LandVehicle vehicle);
    private void ExitVehicle(LandVehicle veh, Transform exitPoint);
    public void RegisterMovementEvent(int threshold, Action action);
    public void DeregisterMovementEvent(Action action);
    private void UpdateMovementEvents();
    public void ChangeStamina(float change, bool notify = true);
    public void SetStamina(float value, bool notify = true);
    public void AddSprintBlocker(string tag);
    public void RemoveSprintBlocker(string tag);
    public void MountLadder(Ladder ladder);
    public void DismountLadder();
    private void LadderMove();
    private void PlayLadderClimbSound();
}