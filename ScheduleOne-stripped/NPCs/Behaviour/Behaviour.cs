using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.Management;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace ScheduleOne.NPCs.Behaviour;
public class Behaviour : NetworkBehaviour
{
    public const int MAX_CONSECUTIVE_PATHING_FAILURES;
    public bool EnabledOnAwake;
    [Header("Settings")]
    public string Name;
    [Tooltip("Behaviour priority; higher = takes priority over lower number behaviour")]
    public int Priority;
    public UnityEvent onEnable;
    public UnityEvent onDisable;
    public UnityEvent onBegin;
    public UnityEvent onEnd;
    protected int consecutivePathingFailures;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public bool Enabled { get; protected set; }
    public bool Started { get; private set; }
    public bool Active { get; private set; }
    public NPCBehaviour beh { get; private set; }
    public NPC Npc => beh.Npc;

    public override void Awake();
    protected override void OnValidate();
    public virtual void Enable();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendEnable();
    public void Enable_Networked(NetworkConnection conn);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void Enable_Client(NetworkConnection conn);
    public virtual void Disable();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendDisable();
    public void Disable_Networked(NetworkConnection conn);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void Disable_Client(NetworkConnection conn);
    private void UpdateGameObjectName();
    public void Begin_Networked(NetworkConnection conn);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void Begin_Client(NetworkConnection conn);
    protected virtual void Begin();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendEnd();
    public void End_Networked(NetworkConnection conn);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void End_Client(NetworkConnection conn);
    protected virtual void End();
    public void Pause_Networked(NetworkConnection conn);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void Pause_Client(NetworkConnection conn);
    protected virtual void Pause();
    public void Resume_Networked(NetworkConnection conn);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void Resume_Client(NetworkConnection conn);
    protected virtual void Resume();
    public virtual void BehaviourUpdate();
    public virtual void BehaviourLateUpdate();
    public virtual void ActiveMinPass();
    protected void SetPriority(int p);
    protected void SetDestination(ITransitEntity transitEntity, bool teleportIfFail = true);
    protected unsafe virtual void SetDestination(Vector3 position, bool teleportIfFail = true);
    protected virtual void WalkCallback(NPCMovement.WalkResult result);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SendEnable_2166136261();
    public void RpcLogic___SendEnable_2166136261();
    private void RpcReader___Server_SendEnable_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_Enable_Client_328543758(NetworkConnection conn);
    private void RpcLogic___Enable_Client_328543758(NetworkConnection conn);
    private void RpcReader___Observers_Enable_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Enable_Client_328543758(NetworkConnection conn);
    private void RpcReader___Target_Enable_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendDisable_2166136261();
    public void RpcLogic___SendDisable_2166136261();
    private void RpcReader___Server_SendDisable_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_Disable_Client_328543758(NetworkConnection conn);
    private void RpcLogic___Disable_Client_328543758(NetworkConnection conn);
    private void RpcReader___Observers_Disable_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Disable_Client_328543758(NetworkConnection conn);
    private void RpcReader___Target_Disable_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_Begin_Client_328543758(NetworkConnection conn);
    private void RpcLogic___Begin_Client_328543758(NetworkConnection conn);
    private void RpcReader___Observers_Begin_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Begin_Client_328543758(NetworkConnection conn);
    private void RpcReader___Target_Begin_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendEnd_2166136261();
    public void RpcLogic___SendEnd_2166136261();
    private void RpcReader___Server_SendEnd_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_End_Client_328543758(NetworkConnection conn);
    private void RpcLogic___End_Client_328543758(NetworkConnection conn);
    private void RpcReader___Observers_End_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_End_Client_328543758(NetworkConnection conn);
    private void RpcReader___Target_End_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_Pause_Client_328543758(NetworkConnection conn);
    private void RpcLogic___Pause_Client_328543758(NetworkConnection conn);
    private void RpcReader___Observers_Pause_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Pause_Client_328543758(NetworkConnection conn);
    private void RpcReader___Target_Pause_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_Resume_Client_328543758(NetworkConnection conn);
    private void RpcLogic___Resume_Client_328543758(NetworkConnection conn);
    private void RpcReader___Observers_Resume_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Resume_Client_328543758(NetworkConnection conn);
    private void RpcReader___Target_Resume_Client_328543758(PooledReader PooledReader0, Channel channel);
    protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EBehaviour_Assembly_002DCSharp_002Edll();
}