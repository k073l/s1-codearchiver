using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
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
using UnityEngine.Serialization;

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
    public const float OBSTACLE_AVOIDANCE_RANGE_SQR;
    public const float PLAYER_DIST_IMPACT_THRESHOLD;
    public static Dictionary<Vector3, Vector3> cachedClosestReachablePoints;
    public static List<Vector3> cachedClosestPointKeys;
    public const float CLOSEST_REACHABLE_POINT_CACHE_MAX_SQR_OFFSET;
    private const float SlipperyModeMultiplier;
    [SerializeField]
    private bool DEBUG;
    [Header("Obstacle Avoidance Settings")]
    [SerializeField]
    [FormerlySerializedAs("ObstacleAvoidanceEnabled")]
    private bool _obstacleAvoidanceEnabled;
    [SerializeField]
    [FormerlySerializedAs("DefaultObstacleAvoidanceType")]
    private ObstacleAvoidanceType _defaultObstacleAvoidanceType;
    [Header("References")]
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private CapsuleCollider _capsuleCollider;
    [SerializeField]
    private Collider[] _avatarColliders;
    [SerializeField]
    private SmoothedVelocityCalculator _velocityCalculator;
    [SerializeField]
    private Draggable _ragdollDraggable;
    private NPC _npc;
    private bool _hasDestination;
    private NavMeshPath _currentPath;
    private Vector3[] _currentPathCorners;
    private Action<WalkResult> _moveResultCallback;
    private float _moveCallbackSuccessThreshold;
    private float _gravityMultiplier;
    private float _defaultAngularSpeed;
    private NPCSpeedController _speedController;
    private Coroutine _faceDirectionRoutine;
    private Ladder _currentLadder;
    private Coroutine _ladderClimbRoutine;
    private float ragdollStaticTime;
    private NPCPathCache _pathCache;
    private bool _cacheNextPath;
    private float _timeOnLastHitByCar;
    private float timeUntilNextStumble;
    private float timeSinceStumble;
    private Vector3 stumbleDirection;
    private CircularQueue<Vector3> desiredVelocityHistory;
    private int desiredVelocityHistoryLength;
    private float velocityHistorySpacing;
    private float timeSinceLastVelocityHistoryRecord;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ENPCMovementAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ENPCMovementAssembly_002DCSharp_002Edll_Excuted;
    public bool IsMoving { get; }
    public Vector3 Velocity => _velocityCalculator.Velocity;
    public Vector3 AgentDesiredVelocity => _agent.desiredVelocity;
    public Vector3 CurrentDestination { get; protected set; } = Vector3.zero;
    public bool CanMove { get; }
    public float DefaultWalkSpeed => _npc.NPCData.Movement.WalkSpeed;
    public NPCSpeedController SpeedController => _speedController;
    public EStance CurrentStance { get; protected set; }
    public Vector3 FootPosition => ((Component)this).transform.position;
    public int NavMeshAreaMask => _agent.areaMask;
    public float TimeSinceHitByCar => Time.time - _timeOnLastHitByCar;
    public bool FaceDirectionInProgress => _faceDirectionRoutine != null;
    public bool IsOnLadder => (Object)(object)_currentLadder != (Object)null;
    public float CurrentLadderSpeed { get; protected set; }
    public bool Disoriented { get; set; }
    public bool SlipperyMode { get; set; }
    private bool _isClimbingUpwards => CurrentLadderSpeed > 0.1f;

    public override void Awake();
    private void OnDestroy();
    public override void OnStartClient();
    public override void OnStartServer();
    protected virtual void Update();
    protected virtual void FixedUpdate();
    public void OnTriggerEnter(Collider other);
    public void OnCollisionEnter(Collision collision);
    private void CheckHit(Collider other, Collider thisCollider, bool isCollision, Vector3 hitPoint, Collision collision = null);
    public void Warp(Transform target);
    public unsafe void Warp(Vector3 position, Quaternion rotation = default(Quaternion));
    [ObserversRpc(ExcludeServer = true)]
    private void Warp_Client(Vector3 position, Quaternion rotation = default(Quaternion));
    public void SetObstacleAvoidanceEnabled(bool enabled);
    public void SetAgentAvoidancePriority(int priority);
    public void SetAgentType(EAgentType type);
    public void SetSeat(AvatarSeat seat, string animationId = "", float sitTransitionDuration = 0.35f);
    public void SetStance(EStance stance);
    public void SetGravityMultiplier(float multiplier);
    public void SetAngularSpeedMultiplier(float multiplier);
    public void SetIgnoreCollision(Collider collider, bool ignore);
    public void SetIgnoreCollision(Collider[] colliders, bool ignore);
    private void UpdateObstacleAvoidance();
    private void OnVisibilityChange(bool visible);
    private void OnEnterVehicle(LandVehicle veh);
    private void OnExitVehicle(LandVehicle veh);
    private void SetAgentEnabled(bool enabled);
    private void UpdateStumble();
    private void Stumble();
    private void SetAgentSpeed(float speed);
    private void RecordVelocity();
    private void UpdateSlippery();
    private void UpdateCache();
    public void ActivateRagdoll_Server();
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void ActivateRagdoll_Server(Vector3 forcePoint, Vector3 forceDir, float forceMagnitude);
    [ObserversRpc(RunLocally = true)]
    public void ActivateRagdoll(Vector3 forcePoint, Vector3 forceDir, float forceMagnitude);
    [ObserversRpc(RunLocally = true)]
    public void ApplyRagdollForce(Vector3 forcePoint, Vector3 forceDir, float forceMagnitude);
    [ObserversRpc(RunLocally = true)]
    public void DeactivateRagdoll();
    private void UpdateRagdoll();
    private void UpdateRagdollStaticCounter();
    private bool CanRecoverFromRagdoll();
    public void SetDestination(Transform target);
    public void SetDestination(Vector3 pos);
    public void SetDestination(ITransitEntity entity);
    public void SetDestination(Vector3 pos, Action<WalkResult> callback = null, float maximumDistanceForSuccess = 1f, float cacheMaxDistSqr = 1f);
    public void Stop();
    private void UpdateDestination();
    private unsafe void SetDestination(Vector3 pos, Action<WalkResult> callback = null, bool interruptExistingCallback = true, float successThreshold = 1f, float cacheMaxDistSqr = 1f);
    private bool IsNPCPositionValid(Vector3 position);
    private bool SmartSampleNavMesh(Vector3 position, out NavMeshHit hit, float minRadius = 1f, float maxRadius = 10f, int steps = 3);
    private void EndSetDestination(WalkResult result);
    public unsafe void FacePoint(Vector3 point, float lerpTime = 0.5f);
    public unsafe void FaceDirection(Vector3 forward, float lerpTime = 0.5f);
    protected IEnumerator FaceDirection_Process(Vector3 forward, float lerpTime);
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
    private void RpcWriter___Observers_Warp_Client_3848837105(Vector3 position, Quaternion rotation = default(Quaternion));
    private unsafe void RpcLogic___Warp_Client_3848837105(Vector3 position, Quaternion rotation = default(Quaternion));
    private void RpcReader___Observers_Warp_Client_3848837105(PooledReader PooledReader0, Channel channel);
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