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
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.GameTime;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.Misc;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using ScheduleOne.StationFramework;
using ScheduleOne.Storage;
using ScheduleOne.Tiles;
using ScheduleOne.Tools;
using ScheduleOne.Trash;
using ScheduleOne.UI.Compass;
using ScheduleOne.UI.Management;
using ScheduleOne.UI.Stations;
using ScheduleOne.Variables;
using UnityEngine;

namespace ScheduleOne.ObjectScripts;
public class ChemistryStation : GridItem, IUsable, IItemSlotOwner, ITransitEntity, IConfigurable
{
    public enum EStep
    {
        CombineIngredients,
        Stir,
        LowerBoilingFlask,
        PourIntoBoilingFlask,
        RaiseBoilingFlask,
        StartHeat,
        Cook,
        LowerBoilingFlaskAgain,
        PourThroughFilter
    }

    public const float FOV_OVERRIDE;
    public const int INPUT_SLOT_COUNT;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public NetworkObject _003CNPCUserObject_003Ek__BackingField;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public NetworkObject _003CPlayerUserObject_003Ek__BackingField;
    public ItemSlot[] IngredientSlots;
    public ItemSlot OutputSlot;
    [Header("References")]
    public InteractableObject IntObj;
    public Transform CameraPosition_Default;
    public Transform CameraPosition_Stirring;
    public Transform StaticBeaker;
    public Transform StaticFunnel;
    public Transform StaticStirringRod;
    public Transform ItemContainer;
    public LabStand LabStand;
    public StorageVisualizer InputVisuals;
    public StorageVisualizer OutputVisuals;
    public Rigidbody AnchorRb;
    public BunsenBurner Burner;
    public BoilingFlask BoilingFlask;
    public DigitalAlarm Alarm;
    public Transform uiPoint;
    public Transform[] accessPoints;
    public ConfigurationReplicator configReplicator;
    public BoxCollider TrashSpawnVolume;
    public Transform ExplosionPoint;
    [Header("Slot Display Points")]
    public Transform InputSlotsPosition;
    public Transform OutputSlotPosition;
    [Header("Transforms")]
    public Transform[] IngredientTransforms;
    public Transform BeakerAlignmentTransform;
    [Header("Prefabs")]
    public GameObject BeakerPrefab;
    public StirringRod StirringRodPrefab;
    [Header("UI")]
    public ChemistryStationUIElement WorldspaceUIPrefab;
    public Sprite typeIcon;
    [CompilerGenerated]
    [SyncVar]
    public NetworkObject _003CCurrentPlayerConfigurer_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CNPCUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CPlayerUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002EChemistryStationAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002EChemistryStationAssembly_002DCSharp_002Edll_Excuted;
    public bool isOpen => (Object)(object)SyncAccessor__003CPlayerUserObject_003Ek__BackingField == (Object)(object)((NetworkBehaviour)Player.Local).NetworkObject;
    public List<ItemSlot> ItemSlots { get; set; } = new List<ItemSlot>();
    public NetworkObject NPCUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public NetworkObject PlayerUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public ChemistryCookOperation CurrentCookOperation { get; set; }
    public string Name => GetManagementName();
    public List<ItemSlot> InputSlots { get; set; } = new List<ItemSlot>();
    public List<ItemSlot> OutputSlots { get; set; } = new List<ItemSlot>();
    public Transform LinkOrigin => UIPoint;
    public Transform[] AccessPoints => accessPoints;
    public bool Selectable { get; } = true;
    public bool IsAcceptingItems { get; set; } = true;
    public EntityConfiguration Configuration => stationConfiguration;
    protected ChemistryStationConfiguration stationConfiguration { get; set; }
    public ConfigurationReplicator ConfigReplicator => configReplicator;
    public EConfigurableType ConfigurableType => EConfigurableType.ChemistryStation;
    public WorldspaceUIElement WorldspaceUI { get; set; }
    public NetworkObject CurrentPlayerConfigurer {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public Sprite TypeIcon => typeIcon;
    public Transform Transform => ((Component)this).transform;
    public Transform UIPoint => uiPoint;
    public bool CanBeSelected => true;
    public NetworkObject SyncAccessor__003CNPCUserObject_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CPlayerUserObject_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CCurrentPlayerConfigurer_003Ek__BackingField { get; set; }

    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetConfigurer(NetworkObject player);
    public override void Awake();
    public override void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID);
    public override string GetManagementName();
    public override void OnSpawnServer(NetworkConnection connection);
    public void SendConfigurationToClient(NetworkConnection conn);
    public override bool CanBeDestroyed(out string reason);
    protected override void Destroy();
    protected virtual void OnMinPass();
    private void OnTimePass(int minutes);
    private void UpdateClock();
    protected virtual void Update();
    public Beaker CreateBeaker();
    public StirringRod CreateStirringRod();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendCookOperation(ChemistryCookOperation op);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SetCookOperation(NetworkConnection conn, ChemistryCookOperation operation);
    [ObserversRpc]
    private void FinalizeOperation();
    public void ResetStation();
    public bool DoesOutputHaveSpace(StationRecipe recipe);
    public List<ItemInstance> GetIngredients();
    public bool HasIngredientsForRecipe(StationRecipe recipe);
    public void CreateTrash(List<StationItem> mixerItems);
    public void Hovered();
    public void Interacted();
    private void Exit(ExitAction action);
    public void Open();
    public void Close();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetPlayerUser(NetworkObject playerObject);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetNPCUser(NetworkObject npcObject);
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
    public WorldspaceUIElement CreateWorldspaceUI();
    public void DestroyWorldspaceUI();
    public override BuildableItemData GetBaseData();
    public override DynamicSaveData GetSaveData();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetConfigurer_3323014238(NetworkObject player);
    public void RpcLogic___SetConfigurer_3323014238(NetworkObject player);
    private void RpcReader___Server_SetConfigurer_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SendCookOperation_3552222198(ChemistryCookOperation op);
    public void RpcLogic___SendCookOperation_3552222198(ChemistryCookOperation op);
    private void RpcReader___Server_SendCookOperation_3552222198(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetCookOperation_1024887225(NetworkConnection conn, ChemistryCookOperation operation);
    public void RpcLogic___SetCookOperation_1024887225(NetworkConnection conn, ChemistryCookOperation operation);
    private void RpcReader___Observers_SetCookOperation_1024887225(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetCookOperation_1024887225(NetworkConnection conn, ChemistryCookOperation operation);
    private void RpcReader___Target_SetCookOperation_1024887225(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_FinalizeOperation_2166136261();
    private void RpcLogic___FinalizeOperation_2166136261();
    private void RpcReader___Observers_FinalizeOperation_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetPlayerUser_3323014238(NetworkObject playerObject);
    public void RpcLogic___SetPlayerUser_3323014238(NetworkObject playerObject);
    private void RpcReader___Server_SetPlayerUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SetNPCUser_3323014238(NetworkObject npcObject);
    public void RpcLogic___SetNPCUser_3323014238(NetworkObject npcObject);
    private void RpcReader___Server_SetNPCUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
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
    public override bool ReadSyncVar___ScheduleOne_002EObjectScripts_002EChemistryStation(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002EObjectScripts_002EChemistryStation_Assembly_002DCSharp_002Edll();
}