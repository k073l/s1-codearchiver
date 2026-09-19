using System;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Networking;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;

namespace ScheduleOne.Trash;
public class TrashManager : NetworkSingleton<TrashManager>, IBaseSaveable, ISaveable
{
    [Serializable]
    public class TrashItemData
    {
        public TrashItem Item;
        [Range(0f, 1f)]
        public float GenerationChance;
    }

    private const float MinimumYPosition;
    private const int TrashItemLimit;
    public TrashItem[] TrashPrefabs;
    public TrashItem TrashBagPrefab;
    public TrashItemData[] GenerateableTrashItems;
    private List<TrashItem> _trashItems;
    private TrashLoader loader;
    private bool NetworkInitialize___EarlyScheduleOne_002ETrash_002ETrashManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ETrash_002ETrashManagerAssembly_002DCSharp_002Edll_Excuted;
    public string SaveFolderName => "Trash";
    public string SaveFileName => "Trash";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; } = true;
    public int LoadOrder { get; }

    protected override void Start();
    protected override void OnDestroy();
    public virtual void InitializeSaveable();
    private void OnTick();
    [Server]
    private void CheckTrashOutOfBounds();
    public override void OnSpawnServer(NetworkConnection connection);
    public TrashItem CreateTrashItem(string id, Vector3 posiiton, Quaternion rotation, Vector3 initialVelocity = default(Vector3), string guid = "");
    [ServerRpc(RequireOwnership = false)]
    private void CreateTrashItem_Server(string id, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnection sender, string guid);
    [ObserversRpc]
    [TargetRpc]
    private void CreateTrashItem_Client(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnection sender, string guid);
    private TrashItem CreateTrashItemInternal(string id, Vector3 position, Quaternion rotation, Vector3 velocity, string guid);
    public TrashItem CreateTrashBag(string id, Vector3 posiiton, Quaternion rotation, TrashContentData content, Vector3 initialVelocity = default(Vector3), string guid = "");
    [ServerRpc(RequireOwnership = false)]
    private void SendTrashBag(string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid);
    [ObserversRpc]
    [TargetRpc]
    private void CreateTrashBag(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid);
    private TrashItem CreateAndReturnTrashBag(string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, string guid);
    public void DestroyAllTrash();
    public void DestroyTrash(TrashItem trash);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    private void DestroyTrash_Server(string guid);
    [ObserversRpc(RunLocally = true)]
    private void DestroyTrash_Client(string guid);
    public TrashItem GetTrashPrefab(string id);
    public TrashItem GetRandomGeneratableTrashPrefab();
    public virtual string GetSaveString();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_CreateTrashItem_Server_856160079(string id, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnection sender, string guid);
    private void RpcLogic___CreateTrashItem_Server_856160079(string id, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnection sender, string guid);
    private void RpcReader___Server_CreateTrashItem_Server_856160079(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_CreateTrashItem_Client_673753684(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnection sender, string guid);
    private void RpcLogic___CreateTrashItem_Client_673753684(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnection sender, string guid);
    private void RpcReader___Observers_CreateTrashItem_Client_673753684(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_CreateTrashItem_Client_673753684(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnection sender, string guid);
    private void RpcReader___Target_CreateTrashItem_Client_673753684(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendTrashBag_3197724538(string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid);
    private void RpcLogic___SendTrashBag_3197724538(string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid);
    private void RpcReader___Server_SendTrashBag_3197724538(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_CreateTrashBag_632312601(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid);
    private void RpcLogic___CreateTrashBag_632312601(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid);
    private void RpcReader___Observers_CreateTrashBag_632312601(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_CreateTrashBag_632312601(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid);
    private void RpcReader___Target_CreateTrashBag_632312601(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_DestroyTrash_Server_3615296227(string guid);
    private void RpcLogic___DestroyTrash_Server_3615296227(string guid);
    private void RpcReader___Server_DestroyTrash_Server_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_DestroyTrash_Client_3615296227(string guid);
    private void RpcLogic___DestroyTrash_Client_3615296227(string guid);
    private void RpcReader___Observers_DestroyTrash_Client_3615296227(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}