using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.Employees;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Storage;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.ObjectScripts;
public class PlaceableStorageEntity : GridItem, ITransitEntity, IStorageEntity, IUsable
{
    [Header("Reference")]
    [SerializeField]
    protected Transform _storedItemContainer;
    public StorageEntity StorageEntity;
    [SerializeField]
    protected List<StorageGrid> storageGrids;
    public Transform[] accessPoints;
    protected Dictionary<StoredItem, Employee> _reservedItems;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public NetworkObject _003CNPCUserObject_003Ek__BackingField;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public NetworkObject _003CPlayerUserObject_003Ek__BackingField;
    private List<string> completedJobs;
    public SyncVar<NetworkObject> syncVar____003CNPCUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CPlayerUserObject_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002EPlaceableStorageEntityAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002EPlaceableStorageEntityAssembly_002DCSharp_002Edll_Excuted;
    public Transform storedItemContainer => _storedItemContainer;
    public Dictionary<StoredItem, Employee> reservedItems { get; set; }
    public string Name => base.ItemInstance.Name;
    public List<ItemSlot> InputSlots { get; set; } = new List<ItemSlot>();
    public List<ItemSlot> OutputSlots { get; set; } = new List<ItemSlot>();
    public Transform LinkOrigin => ((Component)this).transform;
    public NetworkObject NPCUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public NetworkObject PlayerUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public Transform[] AccessPoints => accessPoints;
    public bool Selectable { get; } = true;
    public bool IsAcceptingItems { get; set; } = true;
    public NetworkObject SyncAccessor__003CNPCUserObject_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CPlayerUserObject_003Ek__BackingField { get; set; }

    protected override void Start();
    public List<StoredItem> GetStoredItems();
    public List<StorageGrid> GetStorageGrids();
    [ObserversRpc(RunLocally = true)]
    public void DestroyStoredItem(int gridIndex, Coordinate coord, string jobID = "", bool network = true);
    [ServerRpc(RequireOwnership = false)]
    private void DestroyStoredItem_Server(int gridIndex, Coordinate coord, string jobID);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetPlayerUser(NetworkObject playerObject);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetNPCUser(NetworkObject npcObject);
    public override bool CanBeDestroyed(out string reason);
    public override BuildableItemData GetBaseData();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_DestroyStoredItem_3261517793(int gridIndex, Coordinate coord, string jobID = "", bool network = true);
    public void RpcLogic___DestroyStoredItem_3261517793(int gridIndex, Coordinate coord, string jobID = "", bool network = true);
    private void RpcReader___Observers_DestroyStoredItem_3261517793(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_DestroyStoredItem_Server_3952619116(int gridIndex, Coordinate coord, string jobID);
    private void RpcLogic___DestroyStoredItem_Server_3952619116(int gridIndex, Coordinate coord, string jobID);
    private void RpcReader___Server_DestroyStoredItem_Server_3952619116(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SetPlayerUser_3323014238(NetworkObject playerObject);
    public void RpcLogic___SetPlayerUser_3323014238(NetworkObject playerObject);
    private void RpcReader___Server_SetPlayerUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SetNPCUser_3323014238(NetworkObject npcObject);
    public void RpcLogic___SetNPCUser_3323014238(NetworkObject npcObject);
    private void RpcReader___Server_SetNPCUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override bool ReadSyncVar___ScheduleOne_002EObjectScripts_002EPlaceableStorageEntity(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    public override void Awake();
}