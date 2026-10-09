using System;
using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Networking;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Dragging;
public class DragManager : NetworkSingleton<DragManager>
{
    public const float DefaultDraggableOffset;
    public AudioSourceController ThrowSound;
    [Header("Settings")]
    public float DragForce;
    public float DampingFactor;
    public float TorqueForce;
    public float TorqueDampingFactor;
    public float ThrowForce;
    public float MassInfluence;
    private List<Draggable> AllDraggables;
    private List<Draggable> CurrentlyUpdating;
    private Draggable lastThrownDraggable;
    private Draggable lastHeldDraggable;
    private bool _dragStartedThisFrame;
    private Action onThrowEvent;
    private bool NetworkInitialize___EarlyScheduleOne_002EDragging_002EDragManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EDragging_002EDragManagerAssembly_002DCSharp_002Edll_Excuted;
    public Draggable CurrentDraggable { get; protected set; }
    public bool IsDragging => (Object)(object)CurrentDraggable != (Object)null;

    public override void OnSpawnServer(NetworkConnection connection);
    public void Update();
    private void UpdateInput();
    public void FixedUpdate();
    public bool IsDraggingAllowed();
    public void RegisterDraggable(Draggable draggable);
    public void Deregister(Draggable draggable);
    public void StartDragging(Draggable draggable);
    [ServerRpc(RequireOwnership = false)]
    private void SetDragger_Server(string draggableGUID, NetworkObject dragger, Vector3 position);
    [ObserversRpc(RunLocally = true)]
    private void SetDragger_Client(string draggableGUID, NetworkObject dragger, Vector3 position);
    public void StopDragging(Vector3 velocity);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    private void SetTransformData_Server(string guid, Vector3 position, Quaternion rotation, Vector3 velocity);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetTransformData_Client(NetworkConnection conn, string guid, Vector3 position, Quaternion rotation, Vector3 velocity);
    private Vector3 GetTargetPosition();
    public void SubscribeToThrowEvent(Action callback);
    public void UnsubscribeFromThrowEvent(Action callback);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetDragger_Server_807933219(string draggableGUID, NetworkObject dragger, Vector3 position);
    private void RpcLogic___SetDragger_Server_807933219(string draggableGUID, NetworkObject dragger, Vector3 position);
    private void RpcReader___Server_SetDragger_Server_807933219(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetDragger_Client_807933219(string draggableGUID, NetworkObject dragger, Vector3 position);
    private void RpcLogic___SetDragger_Client_807933219(string draggableGUID, NetworkObject dragger, Vector3 position);
    private void RpcReader___Observers_SetDragger_Client_807933219(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetTransformData_Server_4062762274(string guid, Vector3 position, Quaternion rotation, Vector3 velocity);
    private void RpcLogic___SetTransformData_Server_4062762274(string guid, Vector3 position, Quaternion rotation, Vector3 velocity);
    private void RpcReader___Server_SetTransformData_Server_4062762274(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetTransformData_Client_3831223955(NetworkConnection conn, string guid, Vector3 position, Quaternion rotation, Vector3 velocity);
    private void RpcLogic___SetTransformData_Client_3831223955(NetworkConnection conn, string guid, Vector3 position, Quaternion rotation, Vector3 velocity);
    private void RpcReader___Observers_SetTransformData_Client_3831223955(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetTransformData_Client_3831223955(NetworkConnection conn, string guid, Vector3 position, Quaternion rotation, Vector3 velocity);
    private void RpcReader___Target_SetTransformData_Client_3831223955(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}