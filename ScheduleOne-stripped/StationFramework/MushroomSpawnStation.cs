using System;
using System.Collections;
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
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Storage;
using ScheduleOne.Tiles;
using ScheduleOne.UI.Management;
using ScheduleOne.UI.Stations;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.StationFramework;
public class MushroomSpawnStation : GridItem, IUsable, IItemSlotOwner, ITransitEntity, IConfigurable
{
    [SerializeField]
    private Transform _uiPoint;
    [SerializeField]
    private Transform[] _accessPoints;
    [SerializeField]
    private ItemDefinition _grainBagDefinition;
    [SerializeField]
    private SporeSyringeDefinition[] _validSporeSyringeDefinitions;
    [SerializeField]
    private StorageVisualizer _grainBagVisualizer;
    [SerializeField]
    private StorageVisualizer _syringeVisualizer;
    [SerializeField]
    private StorageVisualizer _outputVisualizer;
    [SerializeField]
    private ConfigurationReplicator _configReplicator;
    [SerializeField]
    private Sprite _typeIcon;
    [SerializeField]
    private WorldspaceUIElement _worldspaceUIPrefab;
    [SerializeField]
    private UnityEvent onUse;
    [SerializeField]
    private UnityEvent onUseEnded;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public NetworkObject _003CNPCUserObject_003Ek__BackingField;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public NetworkObject _003CPlayerUserObject_003Ek__BackingField;
    [CompilerGenerated]
    [SyncVar]
    [HideInInspector]
    public NetworkObject _003CCurrentPlayerConfigurer_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CNPCUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CPlayerUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EStationFramework_002EMushroomSpawnStationAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EStationFramework_002EMushroomSpawnStationAssembly_002DCSharp_002Edll_Excuted;
    [field: SerializeField]
    public Transform CameraTransform { get; private set; }

    [field: SerializeField]
    public Transform TaskCameraTransform { get; private set; }

    [field: SerializeField]
    public Transform TaskContainer { get; private set; }

    [field: SerializeField]
    public Transform SyringeStartTransform { get; private set; }

    [field: SerializeField]
    public Transform GrainBagStartTransform { get; private set; }
    public ItemSlot GrainBagSlot { get; private set; }
    public ItemSlot SyringeSlot { get; private set; }
    public ItemSlot OutputSlot { get; private set; }
    public List<ItemSlot> ItemSlots { get; set; } = new List<ItemSlot>();
    public NetworkObject NPCUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public NetworkObject PlayerUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public string Name => GetManagementName();
    public List<ItemSlot> InputSlots { get; set; } = new List<ItemSlot>();
    public List<ItemSlot> OutputSlots { get; set; } = new List<ItemSlot>();
    public Transform LinkOrigin => _uiPoint;
    public Transform[] AccessPoints => _accessPoints;
    public bool Selectable { get; } = true;
    public bool IsAcceptingItems { get; set; } = true;
    public EntityConfiguration Configuration => _stationConfiguration;
    public ConfigurationReplicator ConfigReplicator => _configReplicator;
    public EConfigurableType ConfigurableType => EConfigurableType.SpawnStation;
    public WorldspaceUIElement WorldspaceUI { get; set; }
    public NetworkObject CurrentPlayerConfigurer {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public Sprite TypeIcon => _typeIcon;
    public Transform Transform => ((Component)this).transform;
    public Transform UIPoint => _uiPoint;
    public bool CanBeSelected => true;
    private SpawnStationConfiguration _stationConfiguration { get; set; }
    public NetworkObject SyncAccessor__003CNPCUserObject_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CPlayerUserObject_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CCurrentPlayerConfigurer_003Ek__BackingField { get; set; }

    public override void Awake();
    public override void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID);
    public override string GetManagementName();
    public override void OnSpawnServer(NetworkConnection connection);
    protected override void Destroy();
    public override bool CanBeDestroyed(out string reason);
    public void Use();
    private void OnInterfaceExited();
    public bool DoesStationContainRequiredItems();
    public bool DoesStationHaveOutputSpace();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetPlayerUser(NetworkObject playerObject);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetNPCUser(NetworkObject npcObject);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetConfigurer(NetworkObject player);
    public void SendConfigurationToClient(NetworkConnection conn);
    public WorldspaceUIElement CreateWorldspaceUI();
    public void DestroyWorldspaceUI();
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetStoredInstance(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetStoredInstance_Internal(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetItemSlotQuantity(int itemSlotIndex, int quantity);
    [ObserversRpc(RunLocally = true)]
    private void SetItemSlotQuantity_Internal(int itemSlotIndex, int quantity);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetSlotLocked(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    [TargetRpc]
    [ObserversRpc(RunLocally = true)]
    private void SetSlotLocked_Internal(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetSlotFilter(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetSlotFilter_Internal(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    public override BuildableItemData GetBaseData();
    public override DynamicSaveData GetSaveData();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetPlayerUser_3323014238(NetworkObject playerObject);
    public void RpcLogic___SetPlayerUser_3323014238(NetworkObject playerObject);
    private void RpcReader___Server_SetPlayerUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SetNPCUser_3323014238(NetworkObject npcObject);
    public void RpcLogic___SetNPCUser_3323014238(NetworkObject npcObject);
    private void RpcReader___Server_SetNPCUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SetConfigurer_3323014238(NetworkObject player);
    public void RpcLogic___SetConfigurer_3323014238(NetworkObject player);
    private void RpcReader___Server_SetConfigurer_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SetStoredInstance_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    public void RpcLogic___SetStoredInstance_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    private void RpcReader___Server_SetStoredInstance_2652194801(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetStoredInstance_Internal_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    private void RpcLogic___SetStoredInstance_Internal_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    private void RpcReader___Observers_SetStoredInstance_Internal_2652194801(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetStoredInstance_Internal_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    private void RpcReader___Target_SetStoredInstance_Internal_2652194801(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetItemSlotQuantity_1692629761(int itemSlotIndex, int quantity);
    public void RpcLogic___SetItemSlotQuantity_1692629761(int itemSlotIndex, int quantity);
    private void RpcReader___Server_SetItemSlotQuantity_1692629761(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetItemSlotQuantity_Internal_1692629761(int itemSlotIndex, int quantity);
    private void RpcLogic___SetItemSlotQuantity_Internal_1692629761(int itemSlotIndex, int quantity);
    private void RpcReader___Observers_SetItemSlotQuantity_Internal_1692629761(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetSlotLocked_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    public void RpcLogic___SetSlotLocked_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    private void RpcReader___Server_SetSlotLocked_3170825843(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Target_SetSlotLocked_Internal_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    private void RpcLogic___SetSlotLocked_Internal_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    private void RpcReader___Target_SetSlotLocked_Internal_3170825843(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetSlotLocked_Internal_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    private void RpcReader___Observers_SetSlotLocked_Internal_3170825843(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetSlotFilter_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    public void RpcLogic___SetSlotFilter_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    private void RpcReader___Server_SetSlotFilter_527532783(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetSlotFilter_Internal_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    private void RpcLogic___SetSlotFilter_Internal_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    private void RpcReader___Observers_SetSlotFilter_Internal_527532783(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetSlotFilter_Internal_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    private void RpcReader___Target_SetSlotFilter_Internal_527532783(PooledReader PooledReader0, Channel channel);
    public override bool ReadSyncVar___ScheduleOne_002EStationFramework_002EMushroomSpawnStation(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002EStationFramework_002EMushroomSpawnStation_Assembly_002DCSharp_002Edll();
}