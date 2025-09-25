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
using FishNet.Transporting;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.GameTime;
using ScheduleOne.Growing;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Levelling;
using ScheduleOne.Lighting;
using ScheduleOne.Management;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tiles;
using ScheduleOne.Tools;
using ScheduleOne.UI.Management;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.ObjectScripts;
public class Pot : GridItem, IUsable, IConfigurable, ITransitEntity
{
    public enum ECameraPosition
    {
        Closeup,
        Midshot,
        Fullshot,
        BirdsEye
    }

    public enum ESoilState
    {
        Flat,
        Parted,
        Packed
    }

    public const float DryThreshold;
    public const float WaterloggedThreshold;
    public const float ROTATION_SPEED;
    public const float MAX_CAMERA_DISTANCE;
    public const float MIN_CAMERA_DISTANCE;
    [Header("References")]
    public Transform ModelTransform;
    public InteractableObject IntObj;
    public Transform PourableStartPoint;
    public Transform SeedStartPoint;
    public Transform SeedRestingPoint;
    public GameObject WaterLoggedVisuals;
    public Transform LookAtPoint;
    public Transform AdditivesContainer;
    public Transform PlantContainer;
    public Transform IntObjLabel_Low;
    public Transform IntObjLabel_High;
    public Transform uiPoint;
    [SerializeField]
    protected ConfigurationReplicator configReplicator;
    public Transform[] accessPoints;
    public Transform TaskBounds;
    public PotSoilCover SoilCover;
    public Transform LeafDropPoint;
    public ParticleSystem PoofParticles;
    public AudioSourceController PoofSound;
    [Header("UI")]
    public Transform WaterCanvasContainer;
    public Canvas WaterLevelCanvas;
    public CanvasGroup WaterLevelCanvasGroup;
    public Slider WaterLevelSlider;
    public GameObject NoWaterIcon;
    public PotUIElement WorldspaceUIPrefab;
    public Sprite typeIcon;
    [Header("Camera References")]
    public Transform CameraContainer;
    public Transform MidshotPosition;
    public Transform CloseupPosition;
    public Transform FullshotPosition;
    public Transform BirdsEyePosition;
    public bool AutoRotateCameraContainer;
    [Header("Dirt references")]
    public Transform Dirt_Flat;
    public Transform Dirt_Parted;
    public SoilChunk[] SoilChunks;
    public List<MeshRenderer> DirtRenderers;
    [Header("Pot Settings")]
    public float PotRadius;
    [Range(0.2f, 2f)]
    public float YieldMultiplier;
    [Range(0.2f, 2f)]
    public float GrowSpeedMultiplier;
    [Range(0.2f, 2f)]
    public float MoistureDrainMultiplier;
    public bool AlignLeafDropToPlayer;
    [Header("Capacity Settings")]
    public float SoilCapacity;
    public float WaterCapacity;
    public float WaterDrainPerHour;
    [Header("Dirt Settings")]
    [SerializeField]
    protected Vector3 DirtMinScale;
    [SerializeField]
    protected Vector3 DirtMaxScale;
    [Header("Pour Target")]
    public Transform Target;
    [Header("Lighting")]
    public UsableLightSource LightSourceOverride;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public float _003CSoilLevel_003Ek__BackingField;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public string _003CSoilID_003Ek__BackingField;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public int _003CRemainingSoilUses_003Ek__BackingField;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public float _003CWaterLevel_003Ek__BackingField;
    public List<Additive> AppliedAdditives;
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
    private bool intObjSetThisFrame;
    private ItemSlot outputSlot;
    private float rotation;
    private bool rotationOverridden;
    private SoilDefinition appliedSoilDefinition;
    private Material appliedSoilMaterial;
    public SyncVar<float> syncVar____003CSoilLevel_003Ek__BackingField;
    public SyncVar<string> syncVar____003CSoilID_003Ek__BackingField;
    public SyncVar<int> syncVar____003CRemainingSoilUses_003Ek__BackingField;
    public SyncVar<float> syncVar____003CWaterLevel_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CNPCUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CPlayerUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002EPotAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002EPotAssembly_002DCSharp_002Edll_Excuted;
    public float SoilLevel {[CompilerGenerated]
        get; [CompilerGenerated]
        protected set; }
    public string SoilID {[CompilerGenerated]
        get; [CompilerGenerated]
        protected set; } = string.Empty;
    public int RemainingSoilUses {[CompilerGenerated]
        get; [CompilerGenerated]
        protected set; }
    public float WaterLevel {[CompilerGenerated]
        get; [CompilerGenerated]
        protected set; }
    public float NormalizedWaterLevel => SyncAccessor__003CWaterLevel_003Ek__BackingField / WaterCapacity;
    public bool IsFilledWithSoil => SyncAccessor__003CSoilLevel_003Ek__BackingField >= SoilCapacity;
    public Plant Plant { get; protected set; }
    public NetworkObject NPCUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public NetworkObject PlayerUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public EntityConfiguration Configuration => potConfiguration;
    protected PotConfiguration potConfiguration { get; set; }
    public ConfigurationReplicator ConfigReplicator => configReplicator;
    public EConfigurableType ConfigurableType => EConfigurableType.Pot;
    public WorldspaceUIElement WorldspaceUI { get; set; }
    public NetworkObject CurrentPlayerConfigurer {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public Sprite TypeIcon => typeIcon;
    public Transform Transform => ((Component)this).transform;
    public Transform UIPoint => uiPoint;
    public bool CanBeSelected => true;
    public string Name => base.ItemInstance.Name;
    public List<ItemSlot> InputSlots { get; set; } = new List<ItemSlot>();
    public List<ItemSlot> OutputSlots { get; set; } = new List<ItemSlot>();
    public Transform LinkOrigin => UIPoint;
    public Transform[] AccessPoints => accessPoints;
    public bool Selectable { get; }
    public bool IsAcceptingItems { get; set; } = true;
    public float SyncAccessor__003CSoilLevel_003Ek__BackingField { get; set; }
    public string SyncAccessor__003CSoilID_003Ek__BackingField { get; set; }
    public int SyncAccessor__003CRemainingSoilUses_003Ek__BackingField { get; set; }
    public float SyncAccessor__003CWaterLevel_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CNPCUserObject_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CPlayerUserObject_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CCurrentPlayerConfigurer_003Ek__BackingField { get; set; }

    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetConfigurer(NetworkObject player);
    public override void Awake();
    protected override void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    public void SendConfigurationToClient(NetworkConnection conn);
    public override void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID);
    public override void DestroyItem(bool callOnServer = true);
    protected virtual void LateUpdate();
    protected void UpdateCanvas();
    private void OnMinPass();
    private void TimeSkipped(int minsSkippped);
    public void ConfigureInteraction(string message, InteractableObject.EInteractableState state, bool useHighLabelPos = false);
    public void PositionCameraContainer();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetPlayerUser(NetworkObject playerObject);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetNPCUser(NetworkObject npcObject);
    [ObserversRpc(RunLocally = true)]
    public virtual void ResetPot();
    public float GetAverageLightExposure(out float growSpeedMultiplier);
    public bool CanAcceptSeed(out string reason);
    public bool IsReadyForHarvest(out string reason);
    public override bool CanBeDestroyed(out string reason);
    public void OverrideRotation(float angle);
    public Transform GetCameraPosition(ECameraPosition pos);
    public virtual void AddSoil(float amount);
    private void SoilLevelChanged(float _prev, float _new, bool asServer);
    protected virtual void UpdateSoilScale();
    public virtual void SetSoilID(string id);
    public virtual void SetSoilUses(int uses);
    public void PushSoilDataToServer();
    [ServerRpc(RequireOwnership = false)]
    public void SendSoilData(string soilID, float soilLevel, int soilUses);
    public void SetSoilState(ESoilState state);
    protected virtual void UpdateSoilMaterial();
    public void ChangeWaterAmount(float change);
    public void PushWaterDataToServer();
    [ServerRpc(RequireOwnership = false)]
    public void SendWaterData(float waterLevel);
    private void WaterLevelChanged(float _prev, float _new, bool asServer);
    public void SetTargetActive(bool active);
    public void RandomizeTarget();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendAdditive(string additiveAssetPath, bool initial);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void ApplyAdditive(NetworkConnection conn, string additiveAssetPath, bool initial);
    public float GetAdditiveGrowthMultiplier();
    public float GetNetYieldChange();
    public float GetNetQualityChange();
    public Additive GetAdditive(string additiveName);
    [ObserversRpc(RunLocally = true)]
    public void FullyGrowPlant();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendPlantSeed(string seedID, float normalizedSeedProgress, float yieldLevel, float qualityLevel);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void PlantSeed(NetworkConnection conn, string seedID, float normalizedSeedProgress, float yieldLevel, float qualityLevel);
    [ObserversRpc]
    private void SetGrowProgress(float progress);
    private void PlantSeed(string seedID, float normalizedSeedProgress, float yieldLevel, float qualityLevel);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SetHarvestableActive(NetworkConnection conn, int harvestableIndex, bool active);
    public void SetHarvestableActive_Local(int harvestableIndex, bool active);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendHarvestableActive(int harvestableIndex, bool active);
    public void SendHarvestableActive_Local(int harvestableIndex, bool active);
    public WorldspaceUIElement CreateWorldspaceUI();
    public void DestroyWorldspaceUI();
    public override BuildableItemData GetBaseData();
    public override DynamicSaveData GetSaveData();
    public virtual void LoadPlant(PlantData data);
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
    private void RpcWriter___Observers_ResetPot_2166136261();
    public virtual void RpcLogic___ResetPot_2166136261();
    private void RpcReader___Observers_ResetPot_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendSoilData_3104499779(string soilID, float soilLevel, int soilUses);
    public void RpcLogic___SendSoilData_3104499779(string soilID, float soilLevel, int soilUses);
    private void RpcReader___Server_SendSoilData_3104499779(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SendWaterData_431000436(float waterLevel);
    public void RpcLogic___SendWaterData_431000436(float waterLevel);
    private void RpcReader___Server_SendWaterData_431000436(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SendAdditive_310431262(string additiveAssetPath, bool initial);
    public void RpcLogic___SendAdditive_310431262(string additiveAssetPath, bool initial);
    private void RpcReader___Server_SendAdditive_310431262(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ApplyAdditive_619441887(NetworkConnection conn, string additiveAssetPath, bool initial);
    public void RpcLogic___ApplyAdditive_619441887(NetworkConnection conn, string additiveAssetPath, bool initial);
    private void RpcReader___Observers_ApplyAdditive_619441887(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_ApplyAdditive_619441887(NetworkConnection conn, string additiveAssetPath, bool initial);
    private void RpcReader___Target_ApplyAdditive_619441887(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_FullyGrowPlant_2166136261();
    public void RpcLogic___FullyGrowPlant_2166136261();
    private void RpcReader___Observers_FullyGrowPlant_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendPlantSeed_2530605204(string seedID, float normalizedSeedProgress, float yieldLevel, float qualityLevel);
    public void RpcLogic___SendPlantSeed_2530605204(string seedID, float normalizedSeedProgress, float yieldLevel, float qualityLevel);
    private void RpcReader___Server_SendPlantSeed_2530605204(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_PlantSeed_709433087(NetworkConnection conn, string seedID, float normalizedSeedProgress, float yieldLevel, float qualityLevel);
    public void RpcLogic___PlantSeed_709433087(NetworkConnection conn, string seedID, float normalizedSeedProgress, float yieldLevel, float qualityLevel);
    private void RpcReader___Observers_PlantSeed_709433087(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_PlantSeed_709433087(NetworkConnection conn, string seedID, float normalizedSeedProgress, float yieldLevel, float qualityLevel);
    private void RpcReader___Target_PlantSeed_709433087(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetGrowProgress_431000436(float progress);
    private void RpcLogic___SetGrowProgress_431000436(float progress);
    private void RpcReader___Observers_SetGrowProgress_431000436(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetHarvestableActive_338960014(NetworkConnection conn, int harvestableIndex, bool active);
    public void RpcLogic___SetHarvestableActive_338960014(NetworkConnection conn, int harvestableIndex, bool active);
    private void RpcReader___Observers_SetHarvestableActive_338960014(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetHarvestableActive_338960014(NetworkConnection conn, int harvestableIndex, bool active);
    private void RpcReader___Target_SetHarvestableActive_338960014(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendHarvestableActive_3658436649(int harvestableIndex, bool active);
    public void RpcLogic___SendHarvestableActive_3658436649(int harvestableIndex, bool active);
    private void RpcReader___Server_SendHarvestableActive_3658436649(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override bool ReadSyncVar___ScheduleOne_002EObjectScripts_002EPot(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002EObjectScripts_002EPot_Assembly_002DCSharp_002Edll();
}