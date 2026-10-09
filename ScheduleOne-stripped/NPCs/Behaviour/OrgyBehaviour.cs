using System;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class OrgyBehaviour : MoveToAndActBehaviour
{
    private string _buildingId;
    private Action<string, string> _onStartOrgy;
    private Action<string, string> _onEndOrgy;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EOrgyBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EOrgyBehaviourAssembly_002DCSharp_002Edll_Excuted;
    [ObserversRpc]
    [TargetRpc]
    public void Set_Client(NetworkConnection conn, Vector3 position, Vector3 faceDir, string buildingId);
    protected override void OnStartAct();
    protected override void OnEndAct();
    public void SubscribeToStartOrgy(Action<string, string> handler);
    public void UnsubscribeFromStartOrgy(Action<string, string> handler);
    public void SubscribeToEndOrgy(Action<string, string> handler);
    public void UnsubscribeFromEndOrgy(Action<string, string> handler);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_Set_Client_1954385944(NetworkConnection conn, Vector3 position, Vector3 faceDir, string buildingId);
    public void RpcLogic___Set_Client_1954385944(NetworkConnection conn, Vector3 position, Vector3 faceDir, string buildingId);
    private void RpcReader___Observers_Set_Client_1954385944(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Set_Client_1954385944(NetworkConnection conn, Vector3 position, Vector3 faceDir, string buildingId);
    private void RpcReader___Target_Set_Client_1954385944(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}