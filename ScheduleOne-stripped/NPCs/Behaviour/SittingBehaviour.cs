using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.AvatarFramework.Animation;
using ScheduleOne.DevUtilities;
using ScheduleOne.SpecialCustomers;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class SittingBehaviour : MoveToAndActBehaviour
{
    private int _seatId;
    private AvatarSeat _seat;
    private Coroutine _actingCo;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002ESittingBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002ESittingBehaviourAssembly_002DCSharp_002Edll_Excuted;
    [ObserversRpc]
    [TargetRpc]
    public void Set_Client(NetworkConnection conn, Vector3 position, Vector3 faceDir, int seatId, int itemToEquipIndex = -1);
    protected override void OnStartAct();
    protected override void OnEndAct();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_Set_Client_3293339476(NetworkConnection conn, Vector3 position, Vector3 faceDir, int seatId, int itemToEquipIndex = -1);
    public void RpcLogic___Set_Client_3293339476(NetworkConnection conn, Vector3 position, Vector3 faceDir, int seatId, int itemToEquipIndex = -1);
    private void RpcReader___Observers_Set_Client_3293339476(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Set_Client_3293339476(NetworkConnection conn, Vector3 position, Vector3 faceDir, int seatId, int itemToEquipIndex = -1);
    private void RpcReader___Target_Set_Client_3293339476(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}