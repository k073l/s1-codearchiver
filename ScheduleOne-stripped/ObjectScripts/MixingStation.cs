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
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.GameTime;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.Misc;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.Product;
using ScheduleOne.StationFramework;
using ScheduleOne.Storage;
using ScheduleOne.Tiles;
using ScheduleOne.Tools;
using ScheduleOne.UI.Compass;
using ScheduleOne.UI.Management;
using ScheduleOne.UI.Stations;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.ObjectScripts;
public class MixingStation : GridItem, IUsable, IItemSlotOwner, ITransitEntity, IConfigurable
{
    public ItemSlot ProductSlot;
    public ItemSlot MixerSlot;
    public ItemSlot OutputSlot;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public NetworkObject _003CNPCUserObject_003Ek__BackingField;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public NetworkObject _003CPlayerUserObject_003Ek__BackingField;
    public bool RequiresIngredientInsertion;
    [CompilerGenerated]
    [SyncVar]
    public NetworkObject _003CCurrentPlayerConfigurer_003Ek__BackingField;
    [Header("Settings")]
    public int MixTimePerItem;
    public int MaxMixQuantity;
    [Header("Prefabs")]
    public GameObject JugPrefab;
    [Header("References")]
    public InteractableObject IntObj;
    public Transform CameraPosition;
    public Transform CameraPosition_CombineIngredients;
    public Transform CameraPosition_StartMachine;
    public StorageVisualizer InputVisuals;
    public StorageVisualizer OutputVisuals;
    public DigitalAlarm Clock;
    public ToggleableLight Light;
    public NewMixDiscoveryBox DiscoveryBox;
    public Transform ItemContainer;
    public Transform[] IngredientTransforms;
    public Fillable BowlFillable;
    public Clickable StartButton;
    public Transform JugAlignment;
    public Rigidbody Anchor;
    public BoxCollider TrashSpawnVolume;
    public Transform uiPoint;
    public Transform[] accessPoints;
    public ConfigurationReplicator configReplicator;
    [Header("Sounds")]
    public StartLoopStopAudio MachineSound;
    public AudioSourceController StartSound;
    public AudioSourceController StopSound;
    [Header("Mix Timing")]
    [Header("UI")]
    public MixingStationUIElement WorldspaceUIPrefab;
    public Sprite typeIcon;
    public UnityEvent onMixStart;
    public UnityEvent onMixDone;
    public UnityEvent onOutputCollected;
    public UnityEvent onStartButtonClicked;
    public SyncVar<NetworkObject> syncVar____003CNPCUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CPlayerUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002EMixingStationAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002EMixingStationAssembly_002DCSharp_002Edll_Excuted;
    public bool IsOpen { get; private set; }
    public MixOperation CurrentMixOperation { get; set; }
    public bool IsMixingDone { get; }
    public int CurrentMixTime { get; protected set; }
    public List<ItemSlot> ItemSlots { get; set; } = new List<ItemSlot>();
    public NetworkObject NPCUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public NetworkObject PlayerUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public string Name => base.ItemInstance.Name;
    public List<ItemSlot> InputSlots { get; set; } = new List<ItemSlot>();
    public List<ItemSlot> OutputSlots { get; set; } = new List<ItemSlot>();
    public Transform LinkOrigin => uiPoint;
    public Transform[] AccessPoints => accessPoints;
    public bool Selectable { get; } = true;
    public bool IsAcceptingItems { get; set; } = true;
    public EntityConfiguration Configuration => stationConfiguration;
    protected MixingStationConfiguration stationConfiguration { get; set; }
    public ConfigurationReplicator ConfigReplicator => configReplicator;
    public EConfigurableType ConfigurableType => EConfigurableType.MixingStation;
    public WorldspaceUIElement WorldspaceUI { get; set; }
    public NetworkObject CurrentPlayerConfigurer {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public Sprite TypeIcon => typeIcon;
    public Transform Transform => ((Component)this).transform;
    public Transform UIPoint => uiPoint;
    public bool CanBeSelected => true;
    public Vector3 DiscoveryBoxOffset { get; private set; }
    public Quaternion DiscoveryBoxRotation { get; private set; }
    public NetworkObject SyncAccessor__003CNPCUserObject_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CPlayerUserObject_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CCurrentPlayerConfigurer_003Ek__BackingField { get; set; }

    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetConfigurer(NetworkObject player);
    public override void Awake();
    protected override void Start();
    public override void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID);
    public override void OnSpawnServer(NetworkConnection connection);
    public void SendConfigurationToClient(NetworkConnection conn);
    public override bool CanBeDestroyed(out string reason);
    public override void DestroyItem(bool callOnServer = true);
    private void TimeSkipped(int minsPassed);
    protected virtual void MinPass();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendMixingOperation(MixOperation operation, int mixTime);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public virtual void SetMixOperation(NetworkConnection conn, MixOperation operation, int mixTIme);
    public virtual void MixingStart();
    [ObserversRpc]
    public void MixingDone_Networked();
    public virtual void MixingDone();
    public bool DoesOutputHaveSpace(StationRecipe recipe);
    public List<ItemInstance> GetIngredients();
    public int GetMixQuantity();
    public bool CanStartMix();
    public ProductDefinition GetProduct();
    public PropertyItemDefinition GetMixer();
    public int GetMixTimeForCurrentOperation();
    [ServerRpc(RequireOwnership = false)]
    public void TryCreateOutputItems();
    public void SetStartButtonClickable(bool clickable);
    private void OutputChanged();
    private void StartButtonClicked(RaycastHit hit);
    public void Open();
    public void Close();
    public void Hovered();
    public void Interacted();
    public WorldspaceUIElement CreateWorldspaceUI();
    public void DestroyWorldspaceUI();
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetStoredInstance(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc(RunLocally = true)]
    private void SetStoredInstance_Internal(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetItemSlotQuantity(int itemSlotIndex, int quantity);
    [ObserversRpc(RunLocally = true)]
    private void SetItemSlotQuantity_Internal(int itemSlotIndex, int quantity);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetSlotLocked(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    [TargetRpc(RunLocally = true)]
    [ObserversRpc(RunLocally = true)]
    private void SetSlotLocked_Internal(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetSlotFilter(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc(RunLocally = true)]
    private void SetSlotFilter_Internal(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetPlayerUser(NetworkObject playerObject);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetNPCUser(NetworkObject npcObject);
    public override BuildableItemData GetBaseData();
    public override DynamicSaveData GetSaveData();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetConfigurer_3323014238(NetworkObject player);
    public void RpcLogic___SetConfigurer_3323014238(NetworkObject player);
    private void RpcReader___Server_SetConfigurer_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SendMixingOperation_2669582547(MixOperation operation, int mixTime);
    public void RpcLogic___SendMixingOperation_2669582547(MixOperation operation, int mixTime);
    private void RpcReader___Server_SendMixingOperation_2669582547(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetMixOperation_1073078804(NetworkConnection conn, MixOperation operation, int mixTIme);
    public virtual void RpcLogic___SetMixOperation_1073078804(NetworkConnection conn, MixOperation operation, int mixTIme);
    private void RpcReader___Observers_SetMixOperation_1073078804(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetMixOperation_1073078804(NetworkConnection conn, MixOperation operation, int mixTIme);
    private void RpcReader___Target_SetMixOperation_1073078804(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_MixingDone_Networked_2166136261();
    public void RpcLogic___MixingDone_Networked_2166136261();
    private void RpcReader___Observers_MixingDone_Networked_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_TryCreateOutputItems_2166136261();
    public void RpcLogic___TryCreateOutputItems_2166136261();
    private void RpcReader___Server_TryCreateOutputItems_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
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
    private void RpcWriter___Server_SetPlayerUser_3323014238(NetworkObject playerObject);
    public void RpcLogic___SetPlayerUser_3323014238(NetworkObject playerObject);
    private void RpcReader___Server_SetPlayerUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SetNPCUser_3323014238(NetworkObject npcObject);
    public void RpcLogic___SetNPCUser_3323014238(NetworkObject npcObject);
    private void RpcReader___Server_SetNPCUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override bool ReadSyncVar___ScheduleOne_002EObjectScripts_002EMixingStation(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002EObjectScripts_002EMixingStation_Assembly_002DCSharp_002Edll();
}