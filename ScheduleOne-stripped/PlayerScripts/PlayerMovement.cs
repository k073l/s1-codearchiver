using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.UI;
using ScheduleOne.Vehicles;
using ScheduleOne.Vision;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace ScheduleOne.PlayerScripts;
public class PlayerMovement : PlayerSingleton<PlayerMovement>
{
    public class MovementEvent
    {
        public List<Action> actions;
        public Vector3 LastUpdatedDistance;
        public void Update(Vector3 newPosition);
    }

    public const float DEV_SPRINT_MULTIPLIER;
    public const float GROUNDED_THRESHOLD;
    public const float SLOPE_THRESHOLD;
    public static float WalkSpeed;
    public static float SprintMultiplier;
    public static float StaticMoveSpeedMultiplier;
    public const float StaminaRestoreDelay;
    public static float JumpMultiplier;
    public static float ControllerRadius;
    public static float StandingControllerHeight;
    public static float CrouchHeightMultiplier;
    public static float CrouchTime;
    public const float StaminaDrainRate;
    public const float StaminaRestoreRate;
    public static float StaminaReserveMax;
    public const float SprintChangeRate;
    [Header("References")]
    public Player Player;
    public CharacterController Controller;
    [Header("Move settings")]
    [SerializeField]
    protected float sensitivity;
    [SerializeField]
    protected float dead;
    public bool canMove;
    public bool canJump;
    public bool SprintingRequiresStamina;
    public float MoveSpeedMultiplier;
    public float SlipperyMovementMultiplier;
    public bool ForceSprint;
    [Header("Jump/fall settings")]
    [SerializeField]
    protected float jumpForce;
    [SerializeField]
    protected float gravityMultiplier;
    [SerializeField]
    protected LayerMask groundDetectionMask;
    [Header("Slope Settings")]
    [SerializeField]
    protected float slopeForce;
    [SerializeField]
    protected float slopeForceRayLength;
    [Header("Crouch Settings")]
    [SerializeField]
    protected float crouchSpeedMultipler;
    [SerializeField]
    protected float Crouched_VigIntensity;
    [SerializeField]
    protected float Crouched_VigSmoothness;
    [Header("Visibility Points")]
    [SerializeField]
    protected List<Transform> visibilityPointsToScale;
    private Dictionary<Transform, float> originalVisibilityPointOffsets;
    protected Vector3 movement;
    protected float movementY;
    public List<LandVehicle> recentlyDrivenVehicles;
    private bool isJumping;
    public float CurrentStaminaReserve;
    public Action<float> onStaminaReserveChanged;
    public Action onJump;
    public Action onLand;
    public UnityEvent onCrouch;
    public UnityEvent onUncrouch;
    protected float horizontalAxis;
    protected float verticalAxis;
    protected float timeGrounded;
    private Dictionary<int, MovementEvent> movementEvents;
    private float timeSinceStaminaDrain;
    private bool sprintActive;
    private bool sprintReleased;
    private Vector3 residualVelocityDirection;
    private float residualVelocityForce;
    private float residualVelocityDuration;
    private float residualVelocityTimeRemaining;
    private bool teleport;
    private Vector3 teleportPosition;
    private List<string> sprintBlockers;
    private Vector3 lastFrameMovement;
    private Coroutine playerRotCoroutine;
    public static float GravityMultiplier { get; set; } = 1f;
    public float playerHeight { get; protected set; }
    public Vector3 Movement => movement;
    public LandVehicle currentVehicle { get; protected set; }
    public float airTime { get; protected set; }
    public bool isCrouched { get; protected set; }
    public float standingScale { get; protected set; } = 1f;
    public bool isRagdolled { get; protected set; }
    public bool isSprinting { get; protected set; }
    public float CurrentSprintMultiplier { get; protected set; } = 1f;
    public bool IsGrounded { get; private set; } = true;

    protected override void Awake();
    protected override void Start();
    protected virtual void Update();
    private void FixedUpdate();
    private void LateUpdate();
    protected virtual void Move();
    private void ClampMovement();
    protected float GetSurfaceAngle();
    private bool isGrounded();
    protected void UpdateHorizontalAxis();
    protected void UpdateVerticalAxis();
    private IEnumerator Jump();
    private void TryToggleCrouch();
    public bool CanStand();
    public void SetCrouched(bool c);
    private void UpdateCrouchVignetteEffect();
    private void UpdatePlayerHeight();
    public void LerpPlayerRotation(Quaternion rotation, float lerpTime);
    private IEnumerator LerpPlayerRotation_Process(Quaternion endRotation, float lerpTime);
    private void EnterVehicle(LandVehicle vehicle);
    private void ExitVehicle(LandVehicle veh, Transform exitPoint);
    public unsafe void Teleport(Vector3 position);
    public void SetResidualVelocity(Vector3 dir, float force, float time);
    public void WarpToNavMesh();
    public void RegisterMovementEvent(int threshold, Action action);
    public void DeregisterMovementEvent(Action action);
    private void UpdateMovementEvents();
    public void ChangeStamina(float change, bool notify = true);
    public void SetStamina(float value, bool notify = true);
    public void AddSprintBlocker(string tag);
    public void RemoveSprintBlocker(string tag);
}