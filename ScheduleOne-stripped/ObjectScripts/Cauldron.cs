using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
using ScheduleOne.GameTime;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.Misc;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.StationFramework;
using ScheduleOne.Storage;
using ScheduleOne.Tiles;
using ScheduleOne.Tools;
using ScheduleOne.Trash;
using ScheduleOne.UI.Compass;
using ScheduleOne.UI.Management;
using ScheduleOne.UI.Stations;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.ObjectScripts;
public class Cauldron : GridItem, IUsable, IItemSlotOwner, ITransitEntity, IConfigurable
{
    public enum EState
    {
        MissingIngredients,
        Ready,
        Cooking,
        OutputFull
    }

    public const int INGREDIENT_SLOT_COUNT;
    public const int COCA_LEAF_REQUIRED;
    public ItemSlot[] IngredientSlots;
    public ItemSlot LiquidSlot;
    public ItemSlot OutputSlot;
    public int CookTime;
    [Header("References")]
    public Transform CameraPosition;
    public Transform CameraPosition_CombineIngredients;
    public Transform CameraPosition_StartMachine;
    public InteractableObject IntObj;
    public Transform[] accessPoints;
    public Transform StandPoint;
    public Transform uiPoint;
    public StorageVisualizer LiquidVisuals;
    public StorageVisualizer OutputVisuals;
    public CauldronDisplayTub PrimaryTub;
    public CauldronDisplayTub SecondaryTub;
    public Transform ItemContainer;
    public Transform GasolineSpawnPoint;
    public Transform TubSpawnPoint;
    public Transform[] LeafSpawns;
    public Light OverheadLight;
    public Fillable CauldronFillable;
    public Clickable StartButtonClickable;
    public DigitalAlarm Alarm;
    public ToggleableLight Light;
    public ConfigurationReplicator configReplicator;
    public BoxCollider TrashSpawnVolume;
    public Transform LeafDragProjectionPlane;
    [Header("Prefabs")]
    public StationItem CocaLeafPrefab;
    public StationItem GasolinePrefab;
    public Draggable TubPrefab;
    public QualityItemDefinition CocaineBaseDefinition;
    [Header("UI")]
    public CauldronUIElement WorldspaceUIPrefab;
    public Sprite typeIcon;
    public UnityEvent onStartButtonClicked;
    public UnityEvent onCookStart;
    public UnityEvent onCookEnd;
    public int RemainingCookTime;
    public EQuality InputQuality;
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
    public NetworkObject _003CCurrentPlayerConfigurer_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CNPCUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CPlayerUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002ECauldronAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002ECauldronAssembly_002DCSharp_002Edll_Excuted;
    public bool isOpen { get; }
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
    public Transform LinkOrigin => UIPoint;
    public Transform[] AccessPoints => accessPoints;
    public bool Selectable { get; } = true;
    public bool IsAcceptingItems { get; set; } = true;
    public EntityConfiguration Configuration => cauldronConfiguration;
    protected CauldronConfiguration cauldronConfiguration { get; set; }
    public ConfigurationReplicator ConfigReplicator => configReplicator;
    public EConfigurableType ConfigurableType => EConfigurableType.Cauldron;
    public WorldspaceUIElement WorldspaceUI { get; set; }
    public NetworkObject CurrentPlayerConfigurer {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public Sprite TypeIcon => typeIcon;
    public Transform Transform => ((Component)this).transform;
    public Transform UIPoint => uiPoint;
    public bool CanBeSelected => true;
    private bool isCooking => RemainingCookTime > 0;
    public NetworkObject SyncAccessor__003CNPCUserObject_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CPlayerUserObject_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CCurrentPlayerConfigurer_003Ek__BackingField { get; set; }

    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetConfigurer(NetworkObject player);
    public override void Awake();
    public override void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID);
    public override string GetManagementName();
    protected override void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    public void SendConfigurationToClient(NetworkConnection conn);
    protected override void Destroy();
    private void OnMinPass();
    private void OnTimePass(int minutes);
    private void Exit(ExitAction action);
    public void Hovered();
    public void Interacted();
    public void Open();
    public void Close();
    public override bool CanBeDestroyed(out string reason);
    private void UpdateIngredientVisuals();
    public void GetMainInputs(out ItemInstance primaryItem, out int primaryItemQuantity, out ItemInstance secondaryItem, out int secondaryItemQuantity);
    public EState GetState();
    public bool HasOutputSpace();
    public EQuality RemoveIngredients();
    public bool HasIngredients();
    [ServerRpc(RequireOwnership = false)]
    public void SendCookOperation(int remainingCookTime, EQuality quality);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void StartCookOperation(NetworkConnection conn, int remainingCookTime, EQuality quality);
    [ObserversRpc]
    public void FinishCookOperation();
    private void ButtonClicked(RaycastHit hit);
    public void CreateTrash(List<StationItem> mixerItems);
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
    private void RpcWriter___Server_SendCookOperation_3536682170(int remainingCookTime, EQuality quality);
    public void RpcLogic___SendCookOperation_3536682170(int remainingCookTime, EQuality quality);
    private void RpcReader___Server_SendCookOperation_3536682170(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_StartCookOperation_4210838825(NetworkConnection conn, int remainingCookTime, EQuality quality);
    public void RpcLogic___StartCookOperation_4210838825(NetworkConnection conn, int remainingCookTime, EQuality quality);
    private void RpcReader___Observers_StartCookOperation_4210838825(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_StartCookOperation_4210838825(NetworkConnection conn, int remainingCookTime, EQuality quality);
    private void RpcReader___Target_StartCookOperation_4210838825(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_FinishCookOperation_2166136261();
    public void RpcLogic___FinishCookOperation_2166136261();
    private void RpcReader___Observers_FinishCookOperation_2166136261(PooledReader PooledReader0, Channel channel);
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
    public override bool ReadSyncVar___ScheduleOne_002EObjectScripts_002ECauldron(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002EObjectScripts_002ECauldron_Assembly_002DCSharp_002Edll();
}