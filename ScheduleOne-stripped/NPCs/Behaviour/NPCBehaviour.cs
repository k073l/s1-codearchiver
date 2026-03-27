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
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.Doors;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Map;
using ScheduleOne.Networking;
using ScheduleOne.Product;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs.Behaviour;
public class NPCBehaviour : NetworkBehaviour
{
    public bool DEBUG_MODE;
    [Header("References")]
    public NPCScheduleManager ScheduleManager;
    [Header("Default Behaviours")]
    public CoweringBehaviour CoweringBehaviour;
    public RagdollBehaviour RagdollBehaviour;
    public CallPoliceBehaviour CallPoliceBehaviour;
    public GenericDialogueBehaviour GenericDialogueBehaviour;
    public HeavyFlinchBehaviour HeavyFlinchBehaviour;
    public FaceTargetBehaviour FaceTargetBehaviour;
    public DeadBehaviour DeadBehaviour;
    public UnconsciousBehaviour UnconsciousBehaviour;
    public Behaviour SummonBehaviour;
    public ConsumeProductBehaviour ConsumeProductBehaviour;
    public CombatBehaviour CombatBehaviour;
    public FleeBehaviour FleeBehaviour;
    public StationaryBehaviour StationaryBehaviour;
    public RequestProductBehaviour RequestProductBehaviour;
    [SerializeField]
    protected List<Behaviour> behaviourStack;
    private Coroutine summonRoutine;
    [SerializeField]
    private List<Behaviour> enabledBehaviours;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002ENPCBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002ENPCBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public Behaviour activeBehaviour { get; set; }
    public NPC Npc { get; private set; }

    public override void Awake();
    protected virtual void Start();
    private void OnDestroy();
    protected override void OnValidate();
    public override void OnSpawnServer(NetworkConnection connection);
    [ServerRpc(RequireOwnership = false)]
    public void Summon(string buildingGUID, int doorIndex, float duration);
    [ServerRpc(RequireOwnership = false)]
    public void ConsumeProduct(ProductItemInstance product, bool removeFromInventory = false);
    private void OnKnockOut();
    private void OnRevive();
    protected virtual void OnDie();
    public Behaviour GetBehaviour(string BehaviourName);
    public T GetBehaviour<T>()
        where T : Behaviour;
    public virtual void Update();
    public virtual void LateUpdate();
    protected virtual void OnTick();
    protected virtual void OnUncappedMinutePass();
    public void SortBehaviourStack();
    private Behaviour GetEnabledBehaviour();
    private void AddEnabledBehaviour(Behaviour b);
    private void RemoveEnabledBehaviour(Behaviour b);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void EnableBehaviour_Server(int behaviourIndex);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void EnableBehaviour_Client(NetworkConnection conn, int behaviourIndex);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void DisableBehaviour_Server(int behaviourIndex);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void DisableBehaviour_Client(NetworkConnection conn, int behaviourIndex);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void ActivateBehaviour_Server(int behaviourIndex);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void ActivateBehaviour_Client(NetworkConnection conn, int behaviourIndex);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void DeactivateBehaviour_Server(int behaviourIndex);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void DeactivateBehaviour_Client(NetworkConnection conn, int behaviourIndex);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void PauseBehaviour_Server(int behaviourIndex);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void PauseBehaviour_Client(NetworkConnection conn, int behaviourIndex);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void ResumeBehaviour_Server(int behaviourIndex);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void ResumeBehaviour_Client(NetworkConnection conn, int behaviourIndex);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_Summon_900355577(string buildingGUID, int doorIndex, float duration);
    public void RpcLogic___Summon_900355577(string buildingGUID, int doorIndex, float duration);
    private void RpcReader___Server_Summon_900355577(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_ConsumeProduct_3964170259(ProductItemInstance product, bool removeFromInventory = false);
    public void RpcLogic___ConsumeProduct_3964170259(ProductItemInstance product, bool removeFromInventory = false);
    private void RpcReader___Server_ConsumeProduct_3964170259(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_EnableBehaviour_Server_3316948804(int behaviourIndex);
    public void RpcLogic___EnableBehaviour_Server_3316948804(int behaviourIndex);
    private void RpcReader___Server_EnableBehaviour_Server_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_EnableBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    public void RpcLogic___EnableBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    private void RpcReader___Observers_EnableBehaviour_Client_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_EnableBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    private void RpcReader___Target_EnableBehaviour_Client_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_DisableBehaviour_Server_3316948804(int behaviourIndex);
    public void RpcLogic___DisableBehaviour_Server_3316948804(int behaviourIndex);
    private void RpcReader___Server_DisableBehaviour_Server_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_DisableBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    public void RpcLogic___DisableBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    private void RpcReader___Observers_DisableBehaviour_Client_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_DisableBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    private void RpcReader___Target_DisableBehaviour_Client_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ActivateBehaviour_Server_3316948804(int behaviourIndex);
    public void RpcLogic___ActivateBehaviour_Server_3316948804(int behaviourIndex);
    private void RpcReader___Server_ActivateBehaviour_Server_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ActivateBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    public void RpcLogic___ActivateBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    private void RpcReader___Observers_ActivateBehaviour_Client_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_ActivateBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    private void RpcReader___Target_ActivateBehaviour_Client_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_DeactivateBehaviour_Server_3316948804(int behaviourIndex);
    public void RpcLogic___DeactivateBehaviour_Server_3316948804(int behaviourIndex);
    private void RpcReader___Server_DeactivateBehaviour_Server_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_DeactivateBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    public void RpcLogic___DeactivateBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    private void RpcReader___Observers_DeactivateBehaviour_Client_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_DeactivateBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    private void RpcReader___Target_DeactivateBehaviour_Client_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_PauseBehaviour_Server_3316948804(int behaviourIndex);
    public void RpcLogic___PauseBehaviour_Server_3316948804(int behaviourIndex);
    private void RpcReader___Server_PauseBehaviour_Server_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_PauseBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    public void RpcLogic___PauseBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    private void RpcReader___Observers_PauseBehaviour_Client_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_PauseBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    private void RpcReader___Target_PauseBehaviour_Client_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ResumeBehaviour_Server_3316948804(int behaviourIndex);
    public void RpcLogic___ResumeBehaviour_Server_3316948804(int behaviourIndex);
    private void RpcReader___Server_ResumeBehaviour_Server_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ResumeBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    public void RpcLogic___ResumeBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    private void RpcReader___Observers_ResumeBehaviour_Client_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_ResumeBehaviour_Client_2681120339(NetworkConnection conn, int behaviourIndex);
    private void RpcReader___Target_ResumeBehaviour_Client_2681120339(PooledReader PooledReader0, Channel channel);
    protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002ENPCBehaviour_Assembly_002DCSharp_002Edll();
}