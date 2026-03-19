using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.AvatarFramework.Animation;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.Doors;
using ScheduleOne.Dragging;
using ScheduleOne.Management;
using ScheduleOne.Map;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Skating;
using ScheduleOne.Tools;
using ScheduleOne.Vehicles;
using ScheduleOne.VoiceOver;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace ScheduleOne.NPCs;
public class NPCMovement : NetworkBehaviour
{
    public enum EAgentType
    {
        Humanoid,
        BigHumanoid,
        IgnoreCosts
    }

    public enum EStance
    {
        None,
        Stanced
    }

    public enum WalkResult
    {
        Failed,
        Interrupted,
        Stopped,
        Partial,
        Success
    }

    private const float VehicleRunoverSpeed;
    private const float VehicleRunoverRelativeVelocityThreshold_Sqr;
    private const float VehicleImpactCooldown;
    private const float VehicleImpactForceMultiplier;
    private const float SkateboardRunoverSpeed;
    private const float SkateboardImpactForceMultiplier;
    public const float LIGHT_FLINCH_THRESHOLD;
    public const float HEAVY_FLINCH_THRESHOLD;
    public const float RAGDOLL_THRESHOLD;
    public const float MOMENTUM_ANNOYED_THRESHOLD;
    public const float MOMENTUM_LIGHT_FLINCH_THRESHOLD;
    public const float MOMENTUM_HEAVY_FLINCH_THRESHOLD;
    public const float MOMENTUM_RAGDOLL_THRESHOLD;
    public const bool USE_PATH_CACHE;
    public const float STUMBLE_DURATION;
    public const float STUMBLE_FORCE;
    public const float OBSTACLE_AVOIDANCE_RANGE;
    public const float PLAYER_DIST_IMPACT_THRESHOLD;
    public static Dictionary<Vector3, Vector3> cachedClosestReachablePoints;
    public static List<Vector3> cachedClosestPointKeys;
    public const float CLOSEST_REACHABLE_POINT_CACHE_MAX_SQR_OFFSET;
    public bool DEBUG;
    [Header("Settings")]
    public float WalkSpeed;
    public float RunSpeed;
    public float MoveSpeedMultiplier;
    [Header("Obstacle Avoidance")]
    public bool ObstacleAvoidanceEnabled;
    public ObstacleAvoidanceType DefaultObstacleAvoidanceType;
    [Header("Slippery Mode")]
    public bool SlipperyMode;
    public float SlipperyModeMultiplier;
    [Header("References")]
    public NavMeshAgent Agent;
    public NPCSpeedController SpeedController;
    public CapsuleCollider CapsuleCollider;
    public NPCAnimation Animation;
    public SmoothedVelocityCalculator VelocityCalculator;
    public Draggable RagdollDraggable;
    public Collider RagdollDraggableCollider;
    protected NPC npc;
    public float MovementSpeedScale;
    private float ragdollStaticTime;
    public UnityEvent<LandVehicle> onHitByCar;
    public UnityEvent onRagdollStart;
    public UnityEvent onRagdollEnd;
    private bool cacheNextPath;
    private Vector3 currentDestination_Reachable;
    private Action<WalkResult> walkResultCallback;
    private float currentMaxDistanceForSuccess;
    private bool forceIsMoving;
    private Coroutine faceDirectionRoutine;
    private List<ConstantForce> ragdollForceComponents;
    private float timeUntilNextStumble;
    private float timeSinceStumble;
    private Vector3 stumbleDirection;
    private CircularQueue<Vector3> desiredVelocityHistory;
    private int desiredVelocityHistoryLength;
    private float velocityHistorySpacing;
    private float timeSinceLastVelocityHistoryRecord;
    private NavMeshPath agentCurrentPath;
    private float agentCurrentSpeed;
    private Vector3[] agentCurrentPathCorners;
    private Coroutine ladderClimbRoutine;
    private float _defaultAngularSpeed;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ENPCMovementAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ENPCMovementAssembly_002DCSharp_002Edll_Excuted;
    public bool HasDestination { get; protected set; }
    public bool IsMoving { get; }
    public bool IsPaused { get; protected set; }
    public Vector3 FootPosition => ((Component)this).transform.position;
    public float GravityMultiplier { get; protected set; } = 1f;
    public EStance Stance { get; protected set; }
    public float TimeSinceHitByCar { get; protected set; }
    public bool FaceDirectionInProgress => faceDirectionRoutine != null;
    public bool IsOnLadder => (Object)(object)CurrentLadder != (Object)null;
    public float CurrentLadderSpeed { get; protected set; }
    public bool IsClimbingUpwards => CurrentLadderSpeed > 0.1f;
    public Ladder CurrentLadder { get; protected set; }
    public Vector3 CurrentDestination { get; protected set; } = Vector3.zero;
    public NPCPathCache PathCache { get; private set; } = new NPCPathCache();
    public bool Disoriented { get; set; }

    public override void Awake();
    private void Start();
    public override void OnStartClient();
    protected virtual void Update();
    public void SetAgentEnabled(bool enabled);
    private void UpdateRagdoll();
    private void Stumble();
    private void UpdateDestination();
    protected virtual void FixedUpdate();
    private void UpdateStumble();
    private void UpdateSpeed();
    private void RecordVelocity();
    private void UpdateSlippery();
    private void UpdateCache();
    public bool CanRecoverFromRagdoll();
    private void UpdateAvoidance();
    public void OnTriggerEnter(Collider other);
    public void OnCollisionEnter(Collision collision);
    private void CheckHit(Collider other, Collider thisCollider, bool isCollision, Vector3 hitPoint, Collision collision = null);
    public void Warp(Transform target);
    public unsafe void Warp(Vector3 position);
    [ObserversRpc(ExcludeServer = true)]
    private void ReceiveWarp(Vector3 position);
    public void VisibilityChange(bool visible);
    public bool CanMove();
    public void SetAgentType(EAgentType type);
    public void SetSeat(AvatarSeat seat);
    public void SetStance(EStance stance);
    public void SetGravityMultiplier(float multiplier);
    public void SetAngularSpeedMultiplier(float multiplier);
    public void SetRagdollDraggable(bool draggable);
    public void ActivateRagdoll_Server();
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void ActivateRagdoll_Server(Vector3 forcePoint, Vector3 forceDir, float forceMagnitude);
    [ObserversRpc(RunLocally = true)]
    public void ActivateRagdoll(Vector3 forcePoint, Vector3 forceDir, float forceMagnitude);
    [ObserversRpc(RunLocally = true)]
    public void ApplyRagdollForce(Vector3 forcePoint, Vector3 forceDir, float forceMagnitude);
    [ObserversRpc(RunLocally = true)]
    public void DeactivateRagdoll();
    private bool SmartSampleNavMesh(Vector3 position, out NavMeshHit hit, float minRadius = 1f, float maxRadius = 10f, int steps = 3);
    public void SetDestination(Transform target);
    public void SetDestination(Vector3 pos);
    public void SetDestination(ITransitEntity entity);
    public void SetDestination(Vector3 pos, Action<WalkResult> callback = null, float maximumDistanceForSuccess = 1f, float cacheMaxDistSqr = 1f);
    private unsafe void SetDestination(Vector3 pos, Action<WalkResult> callback = null, bool interruptExistingCallback = true, float successThreshold = 1f, float cacheMaxDistSqr = 1f);
    private bool IsNPCPositionValid(Vector3 position);
    private void EndSetDestination(WalkResult result);
    public void Stop();
    public void WarpToNavMesh();
    public unsafe void FacePoint(Vector3 point, float lerpTime = 0.5f);
    public unsafe void FaceDirection(Vector3 forward, float lerpTime = 0.5f);
    protected IEnumerator FaceDirection_Process(Vector3 forward, float lerpTime);
    public void PauseMovement();
    public void ResumeMovement();
    public bool IsAsCloseAsPossible(Vector3 location, float distanceThreshold = 0.5f);
    public bool GetClosestReachablePoint(Vector3 targetPosition, out Vector3 closestPoint);
    public bool CanGetTo(Vector3 position, float proximityReq = 1f);
    public bool CanGetTo(ITransitEntity entity, float proximityReq = 1f);
    public bool CanGetTo(Vector3 position, float proximityReq, out NavMeshPath path);
    private NavMeshPath GetPathTo(Vector3 position, float proximityReq = 1f);
    public void TraverseLadder(Ladder ladder);
    private void CancelTraverseLadder();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_ReceiveWarp_4276783012(Vector3 position);
    private unsafe void RpcLogic___ReceiveWarp_4276783012(Vector3 position);
    private void RpcReader___Observers_ReceiveWarp_4276783012(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ActivateRagdoll_Server_2690242654(Vector3 forcePoint, Vector3 forceDir, float forceMagnitude);
    public void RpcLogic___ActivateRagdoll_Server_2690242654(Vector3 forcePoint, Vector3 forceDir, float forceMagnitude);
    private void RpcReader___Server_ActivateRagdoll_Server_2690242654(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ActivateRagdoll_2690242654(Vector3 forcePoint, Vector3 forceDir, float forceMagnitude);
    public unsafe void RpcLogic___ActivateRagdoll_2690242654(Vector3 forcePoint, Vector3 forceDir, float forceMagnitude);
    private void RpcReader___Observers_ActivateRagdoll_2690242654(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ApplyRagdollForce_2690242654(Vector3 forcePoint, Vector3 forceDir, float forceMagnitude);
    public void RpcLogic___ApplyRagdollForce_2690242654(Vector3 forcePoint, Vector3 forceDir, float forceMagnitude);
    private void RpcReader___Observers_ApplyRagdollForce_2690242654(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_DeactivateRagdoll_2166136261();
    public void RpcLogic___DeactivateRagdoll_2166136261();
    private void RpcReader___Observers_DeactivateRagdoll_2166136261(PooledReader PooledReader0, Channel channel);
    protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002ENPCMovement_Assembly_002DCSharp_002Edll();
}