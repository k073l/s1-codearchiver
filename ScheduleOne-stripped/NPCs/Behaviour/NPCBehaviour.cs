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
    public void ConsumeProduct(ProductItemInstance product);
    protected virtual void OnKnockOut();
    protected virtual void OnDie();
    public Behaviour GetBehaviour(string BehaviourName);
    public virtual void Update();
    public virtual void LateUpdate();
    protected virtual void MinPass();
    public void SortBehaviourStack();
    private Behaviour GetEnabledBehaviour();
    private void AddEnabledBehaviour(Behaviour b);
    private void RemoveEnabledBehaviour(Behaviour b);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_Summon_900355577(string buildingGUID, int doorIndex, float duration);
    public void RpcLogic___Summon_900355577(string buildingGUID, int doorIndex, float duration);
    private void RpcReader___Server_Summon_900355577(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_ConsumeProduct_2622925554(ProductItemInstance product);
    public void RpcLogic___ConsumeProduct_2622925554(ProductItemInstance product);
    private void RpcReader___Server_ConsumeProduct_2622925554(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002ENPCBehaviour_Assembly_002DCSharp_002Edll();
}