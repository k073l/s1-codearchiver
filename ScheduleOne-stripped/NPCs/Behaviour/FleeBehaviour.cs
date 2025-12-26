using FishNet;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.VoiceOver;
using UnityEngine;
using UnityEngine.AI;

namespace ScheduleOne.NPCs.Behaviour;
public class FleeBehaviour : Behaviour
{
    public enum EFleeMode
    {
        Entity,
        Point
    }

    public const float FLEE_DIST_MIN;
    public const float FLEE_DIST_MAX;
    public const float FLEE_SPEED;
    private Vector3 currentFleeTarget;
    private float nextVO;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EFleeBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EFleeBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public NetworkObject EntityToFlee { get; private set; }
    public Vector3 PointToFlee { get; }
    public EFleeMode FleeMode { get; private set; }
    public Vector3 FleeOrigin { get; private set; } = Vector3.zero;

    [ObserversRpc(RunLocally = true)]
    public void SetEntityToFlee(NetworkObject entity);
    [ObserversRpc(RunLocally = true)]
    public void SetPointToFlee(Vector3 point);
    public override void Activate();
    public override void Resume();
    public override void Deactivate();
    public override void Pause();
    private void StartFlee();
    public override void OnActiveTick();
    public override void BehaviourUpdate();
    private void Stop();
    private void Flee();
    public Vector3 GetFleePosition();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_SetEntityToFlee_3323014238(NetworkObject entity);
    public void RpcLogic___SetEntityToFlee_3323014238(NetworkObject entity);
    private void RpcReader___Observers_SetEntityToFlee_3323014238(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetPointToFlee_4276783012(Vector3 point);
    public void RpcLogic___SetPointToFlee_4276783012(Vector3 point);
    private void RpcReader___Observers_SetPointToFlee_4276783012(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}