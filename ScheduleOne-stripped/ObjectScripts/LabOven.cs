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
using ScheduleOne.StationFramework;
using ScheduleOne.Storage;
using ScheduleOne.Tiles;
using ScheduleOne.Tools;
using ScheduleOne.UI.Compass;
using ScheduleOne.UI.Management;
using ScheduleOne.UI.Stations;
using TMPro;
using UnityEngine;

namespace ScheduleOne.ObjectScripts;
public class LabOven : GridItem, IUsable, IItemSlotOwner, ITransitEntity, IConfigurable
{
    public enum ELightMode
    {
        Off,
        On,
        Flash
    }

    public enum EState
    {
        CanBegin,
        MissingItems,
        InsufficentProduct,
        OutputSlotFull,
        Mismatch
    }

    public const int SOLID_INGREDIENT_COOK_LIMIT;
    public const float FOV_OVERRIDE;
    public ELightMode LightMode;
    [Header("References")]
    public Transform CameraPosition_Default;
    public Transform CameraPosition_Pour;
    public Transform CameraPosition_PlaceItems;
    public Transform CameraPosition_Breaking;
    public InteractableObject IntObj;
    public LabOvenDoor Door;
    public LabOvenWireTray WireTray;
    public ToggleableLight OvenLight;
    public LabOvenButton Button;
    public TextMeshPro TimerLabel;
    public ToggleableLight Light;
    public Transform PourableContainer;
    public Transform ItemContainer;
    public Animation PourAnimation;
    public SkinnedMeshRenderer LiquidMesh;
    public StorageVisualizer InputVisuals;
    public StorageVisualizer OutputVisuals;
    public MeshRenderer CookedLiquidMesh;
    public Animation RemoveTrayAnimation;
    public Transform SquareTray;
    public Transform HammerSpawnPoint;
    public Transform HammerContainer;
    public Transform OafBastard;
    public Transform DecalContainer;
    public Transform DecalMaxBounds;
    public Transform DecalMinBounds;
    public BoxCollider CookedLiquidCollider;
    public Transform[] ShardSpawnPoints;
    public ParticleSystem ShatterParticles;
    public Transform uiPoint;
    public Transform[] accessPoints;
    public ConfigurationReplicator configReplicator;
    public Transform[] SolidIngredientSpawnPoints;
    public BoxCollider TrayDetectionArea;
    [Header("Sounds")]
    public AudioSourceController ButtonSound;
    public AudioSourceController DingSound;
    public AudioSourceController RunLoopSound;
    public AudioSourceController ImpactSound;
    public AudioSourceController ShatterSound;
    [Header("UI")]
    public LabOvenUIElement WorldspaceUIPrefab;
    public Sprite typeIcon;
    [Header("Prefabs")]
    public LabOvenHammer HammerPrefab;
    public GameObject SmashDecalPrefab;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public NetworkObject _003CNPCUserObject_003Ek__BackingField;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public NetworkObject _003CPlayerUserObject_003Ek__BackingField;
    public ItemSlot IngredientSlot;
    public ItemSlot OutputSlot;
    [CompilerGenerated]
    [SyncVar]
    public NetworkObject _003CCurrentPlayerConfigurer_003Ek__BackingField;
    private Vector3 pourableContainerDefaultPos;
    private Quaternion pourableContainerDefaultRot;
    private Vector3 squareTrayDefaultPos;
    private Quaternion squareTrayDefaultRot;
    private List<GameObject> decals;
    private List<GameObject> shards;
    public SyncVar<NetworkObject> syncVar____003CNPCUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CPlayerUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002ELabOvenAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002ELabOvenAssembly_002DCSharp_002Edll_Excuted;
    public bool isOpen { get; }
    public OvenCookOperation CurrentOperation { get; private set; }
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
    public Transform LinkOrigin => UIPoint;
    public Transform[] AccessPoints => accessPoints;
    public bool Selectable { get; } = true;
    public bool IsAcceptingItems { get; set; } = true;
    public EntityConfiguration Configuration => ovenConfiguration;
    protected LabOvenConfiguration ovenConfiguration { get; set; }
    public ConfigurationReplicator ConfigReplicator => configReplicator;
    public EConfigurableType ConfigurableType => EConfigurableType.LabOven;
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
    public override void OnSpawnServer(NetworkConnection connection);
    public void SendConfigurationToClient(NetworkConnection conn);
    private void Update();
    private void MinPass();
    private void TimeSkipped(int minsSkippped);
    private void UpdateOvenAppearance();
    private void Exit(ExitAction action);
    public override bool CanBeDestroyed(out string reason);
    public override void DestroyItem(bool callOnServer = true);
    public void SetOvenLit(bool lit);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetPlayerUser(NetworkObject playerObject);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetNPCUser(NetworkObject npcObject);
    public void Hovered();
    public void Interacted();
    public void Open();
    public void Close();
    public bool IsIngredientCookable();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendCookOperation(OvenCookOperation operation);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SetCookOperation(NetworkConnection conn, OvenCookOperation operation, bool playButtonPress);
    public bool IsReadyToStart();
    public bool IsReadyForHarvest();
    public bool CanOutputSpaceFitCurrentOperation();
    public void SetLiquidColor(Color col);
    private void UpdateLiquid();
    public StationItem[] CreateStationItems(int quantity = 1);
    public void ResetPourableContainer();
    public void ResetSquareTray();
    public LabOvenHammer CreateHammer();
    public void CreateImpactEffects(Vector3 point, bool playSound = true);
    public void Shatter(int shardQuantity, GameObject shardPrefab);
    public void ClearShards();
    public void ClearDecals();
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
    private void RpcWriter___Server_SetPlayerUser_3323014238(NetworkObject playerObject);
    public void RpcLogic___SetPlayerUser_3323014238(NetworkObject playerObject);
    private void RpcReader___Server_SetPlayerUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SetNPCUser_3323014238(NetworkObject npcObject);
    public void RpcLogic___SetNPCUser_3323014238(NetworkObject npcObject);
    private void RpcReader___Server_SetNPCUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SendCookOperation_3708012700(OvenCookOperation operation);
    public void RpcLogic___SendCookOperation_3708012700(OvenCookOperation operation);
    private void RpcReader___Server_SendCookOperation_3708012700(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetCookOperation_2611294368(NetworkConnection conn, OvenCookOperation operation, bool playButtonPress);
    public void RpcLogic___SetCookOperation_2611294368(NetworkConnection conn, OvenCookOperation operation, bool playButtonPress);
    private void RpcReader___Observers_SetCookOperation_2611294368(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetCookOperation_2611294368(NetworkConnection conn, OvenCookOperation operation, bool playButtonPress);
    private void RpcReader___Target_SetCookOperation_2611294368(PooledReader PooledReader0, Channel channel);
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
    public override bool ReadSyncVar___ScheduleOne_002EObjectScripts_002ELabOven(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002EObjectScripts_002ELabOven_Assembly_002DCSharp_002Edll();
}