using System.Collections;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.Law;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.NPCs.Actions;
public class NPCActions : NetworkBehaviour
{
    private NPC npc;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EActions_002ENPCActionsAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EActions_002ENPCActionsAssembly_002DCSharp_002Edll_Excuted;
    protected NPCBehaviour behaviour => npc.Behaviour;

    public override void Awake();
    public void Cower();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void CallPolice_Networked(NetworkObject playerObj);
    public void SetCallPoliceBehaviourCrime(Crime crime);
    public void FacePlayer(Player player);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_CallPolice_Networked_3323014238(NetworkObject playerObj);
    public void RpcLogic___CallPolice_Networked_3323014238(NetworkObject playerObj);
    private void RpcReader___Server_CallPolice_Networked_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002EActions_002ENPCActions_Assembly_002DCSharp_002Edll();
}