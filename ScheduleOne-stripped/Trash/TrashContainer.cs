using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Trash;
public class TrashContainer : NetworkBehaviour
{
    [Header("Settings")]
    [Range(1f, 50f)]
    public int TrashCapacity;
    [Header("Settings")]
    public Transform TrashBagDropLocation;
    public UnityEvent<string> onTrashAdded;
    public UnityEvent onTrashLevelChanged;
    private bool NetworkInitialize___EarlyScheduleOne_002ETrash_002ETrashContainerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ETrash_002ETrashContainerAssembly_002DCSharp_002Edll_Excuted;
    public TrashContent Content { get; protected set; } = new TrashContent();
    public int TrashLevel => Content.GetTotalSize();
    public float NormalizedTrashLevel => (float)Content.GetTotalSize() / (float)TrashCapacity;

    public virtual void AddTrash(TrashItem item);
    public override void OnSpawnServer(NetworkConnection connection);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    private void SendTrash(string trashID, int quantity);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void AddTrash(NetworkConnection conn, string trashID, int quantity);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    private void SendClear();
    [ObserversRpc(RunLocally = true)]
    private void Clear();
    [TargetRpc]
    private void LoadContent(NetworkConnection conn, TrashContentData data);
    public void TriggerEnter(Collider other);
    public bool CanBeBagged();
    public void BagTrash();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SendTrash_3643459082(string trashID, int quantity);
    private void RpcLogic___SendTrash_3643459082(string trashID, int quantity);
    private void RpcReader___Server_SendTrash_3643459082(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_AddTrash_3905681115(NetworkConnection conn, string trashID, int quantity);
    private void RpcLogic___AddTrash_3905681115(NetworkConnection conn, string trashID, int quantity);
    private void RpcReader___Observers_AddTrash_3905681115(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_AddTrash_3905681115(NetworkConnection conn, string trashID, int quantity);
    private void RpcReader___Target_AddTrash_3905681115(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendClear_2166136261();
    private void RpcLogic___SendClear_2166136261();
    private void RpcReader___Server_SendClear_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_Clear_2166136261();
    private void RpcLogic___Clear_2166136261();
    private void RpcReader___Observers_Clear_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_LoadContent_189522235(NetworkConnection conn, TrashContentData data);
    private void RpcLogic___LoadContent_189522235(NetworkConnection conn, TrashContentData data);
    private void RpcReader___Target_LoadContent_189522235(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}