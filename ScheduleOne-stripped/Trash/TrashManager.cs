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
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.PlayerScripts;
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

    public const int TRASH_ITEM_LIMIT;
    public TrashItem[] TrashPrefabs;
    public TrashItem TrashBagPrefab;
    public TrashItemData[] GenerateableTrashItems;
    private List<TrashItem> trashItems;
    public float TrashForceMultiplier;
    private TrashLoader loader;
    private List<string> writtenItemFiles;
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
    public virtual void InitializeSaveable();
    public override void OnSpawnServer(NetworkConnection connection);
    public void ReplicateTransformData(TrashItem trash);
    [ServerRpc(RequireOwnership = false)]
    private void SendTransformData(string guid, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnection sender);
    [ObserversRpc]
    private void ReceiveTransformData(string guid, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnection sender);
    public TrashItem CreateTrashItem(string id, Vector3 posiiton, Quaternion rotation, Vector3 initialVelocity = default(Vector3), string guid = "", bool startKinematic = false);
    [ServerRpc(RequireOwnership = false)]
    private void SendTrashItem(string id, Vector3 position, Quaternion rotation, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    [ObserversRpc]
    [TargetRpc]
    private void CreateTrashItem(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    private TrashItem CreateAndReturnTrashItem(string id, Vector3 position, Quaternion rotation, Vector3 initialVelocity, string guid, bool startKinematic);
    public TrashItem CreateTrashBag(string id, Vector3 posiiton, Quaternion rotation, TrashContentData content, Vector3 initialVelocity = default(Vector3), string guid = "", bool startKinematic = false);
    [ServerRpc(RequireOwnership = false)]
    private void SendTrashBag(string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    [ObserversRpc]
    [TargetRpc]
    private void CreateTrashBag(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    private TrashItem CreateAndReturnTrashBag(string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, string guid, bool startKinematic);
    public void DestroyAllTrash();
    public void DestroyTrash(TrashItem trash);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    private void SendDestroyTrash(string guid);
    [ObserversRpc(RunLocally = true)]
    private void DestroyTrash(string guid);
    public TrashItem GetTrashPrefab(string id);
    public TrashItem GetRandomGeneratableTrashPrefab();
    public virtual string GetSaveString();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SendTransformData_2990100769(string guid, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnection sender);
    private void RpcLogic___SendTransformData_2990100769(string guid, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnection sender);
    private void RpcReader___Server_SendTransformData_2990100769(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ReceiveTransformData_2990100769(string guid, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnection sender);
    private void RpcLogic___ReceiveTransformData_2990100769(string guid, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnection sender);
    private void RpcReader___Observers_ReceiveTransformData_2990100769(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendTrashItem_478112418(string id, Vector3 position, Quaternion rotation, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    private void RpcLogic___SendTrashItem_478112418(string id, Vector3 position, Quaternion rotation, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    private void RpcReader___Server_SendTrashItem_478112418(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_CreateTrashItem_2385526393(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    private void RpcLogic___CreateTrashItem_2385526393(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    private void RpcReader___Observers_CreateTrashItem_2385526393(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_CreateTrashItem_2385526393(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    private void RpcReader___Target_CreateTrashItem_2385526393(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendTrashBag_3965031115(string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    private void RpcLogic___SendTrashBag_3965031115(string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    private void RpcReader___Server_SendTrashBag_3965031115(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_CreateTrashBag_680856992(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    private void RpcLogic___CreateTrashBag_680856992(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    private void RpcReader___Observers_CreateTrashBag_680856992(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_CreateTrashBag_680856992(NetworkConnection conn, string id, Vector3 position, Quaternion rotation, TrashContentData content, Vector3 initialVelocity, NetworkConnection sender, string guid, bool startKinematic = false);
    private void RpcReader___Target_CreateTrashBag_680856992(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendDestroyTrash_3615296227(string guid);
    private void RpcLogic___SendDestroyTrash_3615296227(string guid);
    private void RpcReader___Server_SendDestroyTrash_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_DestroyTrash_3615296227(string guid);
    private void RpcLogic___DestroyTrash_3615296227(string guid);
    private void RpcReader___Observers_DestroyTrash_3615296227(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}