using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class DancingBehaviour : MoveToAndActBehaviour
{
    private static readonly string[] DanceAnimationBools;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EDancingBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EDancingBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public string GetRandomDanceAnimationBool();
    [ObserversRpc]
    [TargetRpc]
    public void SetDanceAnimation_Client(NetworkConnection conn, string animationName);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_SetDanceAnimation_Client_2971853958(NetworkConnection conn, string animationName);
    public void RpcLogic___SetDanceAnimation_Client_2971853958(NetworkConnection conn, string animationName);
    private void RpcReader___Observers_SetDanceAnimation_Client_2971853958(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetDanceAnimation_Client_2971853958(NetworkConnection conn, string animationName);
    private void RpcReader___Target_SetDanceAnimation_Client_2971853958(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}