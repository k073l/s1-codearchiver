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
    [Header("General Setttings")]
    public float GiveUpRange;
    public float GiveUpTime;
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
    protected bool overrideTargetDistance;
    protected float targetDistanceOverride;
    protected bool isTargetRecentlyVisible;
    protected bool isTargetImmediatelyVisible;
    protected float timeSinceLastSighting;
    protected float playerSightedDuration;
    protected Vector3 lastKnownTargetPosition;
    private float timeSinceLastReposition;
    private float timeWithinAttackRange;
    protected AvatarWeapon currentWeapon;
    protected int successfulHits;
    protected int consecutiveMissedShots;
    protected Coroutine rangedWeaponRoutine;
    protected Coroutine searchRoutine;
    protected Vector3 currentSearchDestination;
    protected bool hasSearchDestination;
    private float nextAngryVO;
    private bool NetworkInitialize___EarlyScheduleOne_002ECombat_002ECombatBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ECombat_002ECombatBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public ICombatTargetable Target { get; protected set; }
    public bool IsSearching { get; protected set; }
    public float TimeSinceTargetReacquired { get; protected set; }

    public override void Awake();
    public override void OnSpawnServer(NetworkConnection connection);
    private void Update();
    [ObserversRpc(RunLocally = true)]
    public void SetTarget(NetworkConnection conn, NetworkObject target);
    protected virtual void SetTarget(NetworkObject target);
    protected override void Begin();
    protected override void Resume();
    protected override void Pause();
    protected override void End();
    public override void Disable();
    protected virtual void StartCombat();
    protected virtual void EndCombat();
    public override void BehaviourUpdate();
    protected virtual void FixedUpdate();
    protected void UpdateTimeout();
    protected virtual void UpdateLookAt();
    protected void SetMovementSpeed(float speed, string label = "combat", int priority = 5);
    private void EnsureRangedWeaponRoutineIsRunning();
    protected Vector3 GetPredictedFutureTargetPosition(float lead_Min = 0f, float lead_Max = 2f);
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
    protected bool IsTargetVisible();
    protected void ProcessVisionEvent(VisionEventReceipt visionEventReceipt);
    protected virtual void TargetSpotted();
    protected virtual float GetSearchTime();
    private void StartSearching();
    private void StopSearching();
    private IEnumerator SearchRoutine();
    private Vector3 GetNextSearchLocation();
    protected virtual bool IsTargetValid();
    private void RepositionToTargetRange(Vector3 origin);
    private Vector3 GetRandomReachablePointNear(Vector3 point, float randomRadius, float minDistance = 0f);
    protected float GetMinTargetDistance();
    protected float GetMaxTargetDistance();
    protected bool IsTargetInRange(Vector3 origin = default(Vector3));
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_SetTarget_1824087381(NetworkConnection conn, NetworkObject target);
    public void RpcLogic___SetTarget_1824087381(NetworkConnection conn, NetworkObject target);
    private void RpcReader___Observers_SetTarget_1824087381(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetWeapon_3615296227(string weaponPath);
    protected virtual void RpcLogic___SetWeapon_3615296227(string weaponPath);
    private void RpcReader___Observers_SetWeapon_3615296227(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ClearWeapon_2166136261();
    protected void RpcLogic___ClearWeapon_2166136261();
    private void RpcReader___Observers_ClearWeapon_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_Attack_2166136261();
    protected virtual void RpcLogic___Attack_2166136261();
    private void RpcReader___Observers_Attack_2166136261(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002ECombat_002ECombatBehaviour_Assembly_002DCSharp_002Edll();
}