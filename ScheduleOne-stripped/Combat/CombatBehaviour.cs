using System;
using System.Collections;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.Tools;
using ScheduleOne.Vision;
using ScheduleOne.VoiceOver;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace ScheduleOne.Combat;
public class CombatBehaviour : Behaviour
{
    public const float RECENT_VISIBILITY_THRESHOLD;
    public const float REPOSITION_TIME;
    public const float SEARCH_RADIUS_MIN;
    public const float SEARCH_RADIUS_MAX;
    public const float SEARCH_SPEED;
    public const float CONSECUTIVE_MISS_ACCURACY_BOOST;
    public const float REACHED_DESTINATION_DISTANCE;
    public const float DelayBeforeFirstAttack;
    public bool DEBUG;
    [Header("General Setttings")]
    public float GiveUpRange;
    public int GiveUpAfterSuccessfulHits;
    public bool PlayAngryVO;
    [Header("Movement settings")]
    [Range(0f, 1f)]
    public float DefaultMovementSpeed;
    [Header("Weapon settings")]
    public AvatarWeapon DefaultWeapon;
    public AvatarMeleeWeapon VirtualPunchWeapon;
    [Header("Search settings")]
    public float DefaultSearchTime;
    [Header("References")]
    public SmoothedVelocityCalculator TargetVelocityTracker;
    [Header("Debug settings")]
    public bool CombatOnStart;
    public NetworkObject DebugTarget;
    protected float timeSinceLastSighting;
    protected Vector3 lastKnownTargetPosition;
    private float timeSinceLastReposition;
    private float timeWithinAttackRange;
    private bool visionEventReceived;
    private float _timeOnCombatStart;
    protected AvatarWeapon currentWeapon;
    protected int successfulHits;
    protected int consecutiveMissedShots;
    protected Coroutine rangedWeaponRoutine;
    protected Coroutine searchRoutine;
    protected Vector3 currentSearchDestination;
    protected bool hasSearchDestination;
    private float nextAngryVO;
    public Action onSuccessfulHit;
    private bool NetworkInitialize___EarlyScheduleOne_002ECombat_002ECombatBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ECombat_002ECombatBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public ICombatTargetable Target { get; protected set; }
    public bool IsSearching { get; protected set; }
    public float TimeSinceTargetReacquired { get; protected set; }
    public bool IsTargetRecentlyVisible { get; private set; }
    public bool IsTargetImmediatelyVisible { get; private set; }

    public override void Awake();
    private void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetTargetAndEnable_Server(NetworkObject target);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    protected void SetTarget_Client(NetworkConnection conn, NetworkObject target);
    protected virtual void SetTarget(NetworkObject target);
    public override void Activate();
    public override void Resume();
    public override void Pause();
    public override void Deactivate();
    public override void Disable();
    protected virtual void StartCombat();
    protected virtual void EndCombat();
    public override void BehaviourUpdate();
    protected void UpdateTimeout();
    protected virtual void UpdateLookAt();
    protected void SetMovementSpeed(float speed, string label = "combat", int priority = 5);
    private void EnsureRangedWeaponRoutineIsRunning();
    protected Vector3 GetPredictedFutureTargetPosition(float lead_Min = 0f, float lead_Max = 2f);
    protected unsafe override void SetDestination(Vector3 position, bool teleportIfFail = true, float successThreshold = 1f);
    [ObserversRpc(RunLocally = true)]
    protected virtual void SetWeapon(string weaponPath);
    protected virtual void OnCurrentWeaponChanged(AvatarWeapon weapon);
    [ObserversRpc(RunLocally = true)]
    protected void ClearWeapon();
    protected virtual bool ReadyToAttack(bool checkTarget = true);
    private bool IsCurrentWeaponMelee();
    [ObserversRpc(RunLocally = true)]
    protected virtual void Attack();
    protected void SucessfulHit();
    private IEnumerator RangedWeaponRoutine();
    private IEnumerator RepositionToRangedWeaponRange();
    protected virtual float GetIdealRangedWeaponDistance();
    private bool Shoot();
    private void SetWeaponRaised(bool raised);
    protected void CheckTargetVisibility();
    public void MarkPlayerVisible();
    protected bool IsTargetVisibleThisFrame();
    protected void ProcessVisionEvent(VisionEventReceipt visionEventReceipt);
    protected virtual void TargetSpotted();
    [ServerRpc(RequireOwnership = false)]
    public void NotifyServerTargetSeen();
    protected virtual float GetSearchTime();
    private void StartSearching();
    private void StopSearching();
    private IEnumerator SearchRoutine();
    private Vector3 GetNextSearchLocation();
    protected virtual bool IsTargetValid();
    private void RepositionToTargetMeleeRange(Vector3 origin);
    private unsafe bool GetRandomReachablePointNear(Vector3 originPoint, float randomRadius, out Vector3 randomPoint, float minDistance = 0f);
    protected float GetMinTargetDistance();
    protected float GetMaxTargetDistance();
    protected bool IsTargetInRange(Vector3 origin = default(Vector3));
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetTargetAndEnable_Server_3323014238(NetworkObject target);
    public void RpcLogic___SetTargetAndEnable_Server_3323014238(NetworkObject target);
    private void RpcReader___Server_SetTargetAndEnable_Server_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetTarget_Client_1824087381(NetworkConnection conn, NetworkObject target);
    protected void RpcLogic___SetTarget_Client_1824087381(NetworkConnection conn, NetworkObject target);
    private void RpcReader___Observers_SetTarget_Client_1824087381(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetTarget_Client_1824087381(NetworkConnection conn, NetworkObject target);
    private void RpcReader___Target_SetTarget_Client_1824087381(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetWeapon_3615296227(string weaponPath);
    protected virtual void RpcLogic___SetWeapon_3615296227(string weaponPath);
    private void RpcReader___Observers_SetWeapon_3615296227(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ClearWeapon_2166136261();
    protected void RpcLogic___ClearWeapon_2166136261();
    private void RpcReader___Observers_ClearWeapon_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_Attack_2166136261();
    protected virtual void RpcLogic___Attack_2166136261();
    private void RpcReader___Observers_Attack_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_NotifyServerTargetSeen_2166136261();
    public void RpcLogic___NotifyServerTargetSeen_2166136261();
    private void RpcReader___Server_NotifyServerTargetSeen_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    protected override void Awake_UserLogic_ScheduleOne_002ECombat_002ECombatBehaviour_Assembly_002DCSharp_002Edll();
}