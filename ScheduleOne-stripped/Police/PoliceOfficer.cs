using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.AvatarFramework.Customization;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.FX;
using ScheduleOne.Law;
using ScheduleOne.Map;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Vehicles;
using ScheduleOne.Vision;
using ScheduleOne.VoiceOver;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Police;
public class PoliceOfficer : NPC
{
    public const float DEACTIVATION_TIME;
    public const float INVESTIGATION_COOLDOWN;
    public const float INVESTIGATION_MAX_DISTANCE;
    public const float INVESTIGATION_MIN_VISIBILITY;
    public const float INVESTIGATION_CHECK_INTERVAL;
    public const float BODY_SEARCH_CHANCE_DEFAULT;
    public const float MIN_CHATTER_INTERVAL;
    public const float MAX_CHATTER_INTERVAL;
    public static Action<VisionEventReceipt> OnPoliceVisionEvent;
    public static List<PoliceOfficer> Officers;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public NetworkObject _003CTargetPlayerNOB_003Ek__BackingField;
    public LandVehicle AssignedVehicle;
    [Header("References")]
    public PursuitBehaviour PursuitBehaviour;
    public VehiclePursuitBehaviour VehiclePursuitBehaviour;
    public BodySearchBehaviour BodySearchBehaviour;
    public CheckpointBehaviour CheckpointBehaviour;
    public FootPatrolBehaviour FootPatrolBehaviour;
    public ProximityCircle ProxCircle;
    public VehiclePatrolBehaviour VehiclePatrolBehaviour;
    public SentryBehaviour SentryBehaviour;
    public PoliceChatterVO ChatterVO;
    public Behaviour[] DeactivationBlockingBehaviours;
    [Header("Dialogue")]
    public DialogueContainer CheckpointDialogue;
    [Header("Tools")]
    public AvatarEquippable BatonPrefab;
    public AvatarEquippable TaserPrefab;
    public AvatarEquippable GunPrefab;
    [Header("Settings")]
    public bool AutoDeactivate;
    public bool ChatterEnabled;
    [Header("Behaviour Settings")]
    [Range(0f, 1f)]
    public float Suspicion;
    [Range(0f, 1f)]
    public float Leniency;
    [Header("Body Search Settings")]
    [Range(0f, 1f)]
    public float BodySearchChance;
    [Range(1f, 10f)]
    public float BodySearchDuration;
    [HideInInspector]
    public PoliceBelt belt;
    private float timeSinceReadyToPool;
    private float timeSinceOutOfSight;
    private float chatterCountDown;
    private Investigation currentBodySearchInvestigation;
    public SyncVar<NetworkObject> syncVar____003CTargetPlayerNOB_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EPolice_002EPoliceOfficerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EPolice_002EPoliceOfficerAssembly_002DCSharp_002Edll_Excuted;
    public NetworkObject TargetPlayerNOB {[CompilerGenerated]
        get; [CompilerGenerated]
        protected set; }
    public NetworkObject SyncAccessor__003CTargetPlayerNOB_003Ek__BackingField { get; set; }

    public override void Awake();
    protected override void Start();
    protected override void Update();
    protected void FixedUpdate();
    protected override void MinPass();
    private void CheckDeactivation();
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public virtual void BeginFootPursuit_Networked(NetworkObject target, bool includeColleagues = true);
    [ObserversRpc(RunLocally = true)]
    private void BeginFootPursuitTest(string playerCode);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public virtual void BeginVehiclePursuit_Networked(NetworkObject target, NetworkObject vehicle, bool beginAsSighted);
    [ObserversRpc(RunLocally = true)]
    private void BeginVehiclePursuit(NetworkObject target, NetworkObject vehicle, bool beginAsSighted);
    public void BeginBodySearch_LocalPlayer();
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public virtual void BeginBodySearch_Networked(NetworkObject target);
    [ObserversRpc(RunLocally = true)]
    private void BeginBodySearch(NetworkObject target);
    [ObserversRpc(RunLocally = true)]
    public virtual void AssignToCheckpoint(CheckpointManager.ECheckpointLocation location);
    public void UnassignFromCheckpoint();
    public void StartFootPatrol(PatrolGroup group, bool warpToStartPoint);
    public void StartVehiclePatrol(VehiclePatrolRoute route, LandVehicle vehicle);
    public virtual void AssignToSentryLocation(SentryLocation location);
    public void UnassignFromSentryLocation();
    public void Activate();
    public void Deactivate();
    protected override bool ShouldNoticeGeneralCrime(Player player);
    public override bool ShouldSave();
    public override string GetNameAddress();
    private void UpdateChatter();
    private void ProcessVisionEvent(VisionEventReceipt visionEventReceipt);
    public static PoliceOfficer GetNearestOfficer(Vector3 position, out float distanceToTarget, bool onlyConscious = true);
    public virtual void UpdateBodySearch();
    private bool CanInvestigate();
    private void UpdateExistingInvestigation();
    private void CheckNewInvestigation();
    private void StartBodySearchInvestigation(Player player);
    private void StopBodySearchInvestigation();
    public void ConductBodySearch(Player player);
    private bool CanInvestigatePlayer(Player player);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_BeginFootPursuit_Networked_419679943(NetworkObject target, bool includeColleagues = true);
    public virtual void RpcLogic___BeginFootPursuit_Networked_419679943(NetworkObject target, bool includeColleagues = true);
    private void RpcReader___Server_BeginFootPursuit_Networked_419679943(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_BeginFootPursuitTest_3615296227(string playerCode);
    private void RpcLogic___BeginFootPursuitTest_3615296227(string playerCode);
    private void RpcReader___Observers_BeginFootPursuitTest_3615296227(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_BeginVehiclePursuit_Networked_2261819652(NetworkObject target, NetworkObject vehicle, bool beginAsSighted);
    public virtual void RpcLogic___BeginVehiclePursuit_Networked_2261819652(NetworkObject target, NetworkObject vehicle, bool beginAsSighted);
    private void RpcReader___Server_BeginVehiclePursuit_Networked_2261819652(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_BeginVehiclePursuit_2261819652(NetworkObject target, NetworkObject vehicle, bool beginAsSighted);
    private void RpcLogic___BeginVehiclePursuit_2261819652(NetworkObject target, NetworkObject vehicle, bool beginAsSighted);
    private void RpcReader___Observers_BeginVehiclePursuit_2261819652(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_BeginBodySearch_Networked_3323014238(NetworkObject target);
    public virtual void RpcLogic___BeginBodySearch_Networked_3323014238(NetworkObject target);
    private void RpcReader___Server_BeginBodySearch_Networked_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_BeginBodySearch_3323014238(NetworkObject target);
    private void RpcLogic___BeginBodySearch_3323014238(NetworkObject target);
    private void RpcReader___Observers_BeginBodySearch_3323014238(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_AssignToCheckpoint_4087078542(CheckpointManager.ECheckpointLocation location);
    public virtual void RpcLogic___AssignToCheckpoint_4087078542(CheckpointManager.ECheckpointLocation location);
    private void RpcReader___Observers_AssignToCheckpoint_4087078542(PooledReader PooledReader0, Channel channel);
    public override bool ReadSyncVar___ScheduleOne_002EPolice_002EPoliceOfficer(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002EPolice_002EPoliceOfficer_Assembly_002DCSharp_002Edll();
}