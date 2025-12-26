using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class FaceTargetBehaviour : Behaviour
{
    public enum ETargetType
    {
        Player,
        Position
    }

    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EFaceTargetBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EFaceTargetBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public ETargetType TargetType { get; private set; }
    public Player TargetPlayer { get; private set; }
    public Vector3 TargetPosition { get; private set; } = Vector3.zero;
    public float Countdown { get; private set; }

    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetTarget(NetworkObject player, float countDown = 5f);
    [ObserversRpc(RunLocally = true)]
    private void SetTargetLocal(NetworkObject player);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetTarget(Vector3 position, float countDown = 5f);
    [ObserversRpc(RunLocally = true)]
    private void SetTargetLocal(Vector3 position);
    public override void Activate();
    public override void BehaviourUpdate();
    private Vector3 GetTargetPosition();
    public override void Disable();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetTarget_244313061(NetworkObject player, float countDown = 5f);
    public void RpcLogic___SetTarget_244313061(NetworkObject player, float countDown = 5f);
    private void RpcReader___Server_SetTarget_244313061(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetTargetLocal_3323014238(NetworkObject player);
    private void RpcLogic___SetTargetLocal_3323014238(NetworkObject player);
    private void RpcReader___Observers_SetTargetLocal_3323014238(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetTarget_3661469815(Vector3 position, float countDown = 5f);
    public void RpcLogic___SetTarget_3661469815(Vector3 position, float countDown = 5f);
    private void RpcReader___Server_SetTarget_3661469815(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetTargetLocal_4276783012(Vector3 position);
    private void RpcLogic___SetTargetLocal_4276783012(Vector3 position);
    private void RpcReader___Observers_SetTargetLocal_4276783012(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}