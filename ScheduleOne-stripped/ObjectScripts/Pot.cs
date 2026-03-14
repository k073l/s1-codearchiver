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
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Levelling;
using ScheduleOne.Management;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Tiles;
using ScheduleOne.UI.Management;
using ScheduleOne.Variables;
using UnityEngine;

namespace ScheduleOne.ObjectScripts;
public class Pot : GrowContainer, IConfigurable
{
    public enum ESoilState
    {
        Flat,
        Parted,
        Packed
    }

    public const float MaxWarmthGrowthMultiplier;
    public const float WarmthMinThreshold;
    public const float WarmthMaxThreshold;
    public const float RotationSpeed;
    [Header("References")]
    public Transform ModelTransform;
    public Transform SeedStartPoint;
    public Transform SeedRestingPoint;
    public Transform LookAtPoint;
    public Transform PlantContainer;
    public Transform TaskBounds;
    public Transform LeafDropPoint;
    public ParticleSystem PoofParticles;
    public AudioSourceController PoofSound;
    public ConfigurationReplicator ConfigurationReplicator;
    public Transform Dirt_Flat;
    public Transform Dirt_Parted;
    public SoilChunk[] SoilChunks;
    [Header("UI")]
    public PotUIElement WorldspaceUIPrefab;
    public Sprite typeIcon;
    [Header("Pot Settings")]
    public float PotRadius;
    [Range(0.2f, 2f)]
    public float YieldMultiplier;
    [Range(0.2f, 2f)]
    public float GrowSpeedMultiplier;
    [CompilerGenerated]
    [SyncVar]
    [HideInInspector]
    public NetworkObject _003CCurrentPlayerConfigurer_003Ek__BackingField;
    private float rotation;
    private bool rotationOverridden;
    public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002EPotAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002EPotAssembly_002DCSharp_002Edll_Excuted;
    public Plant Plant { get; protected set; }
    public EntityConfiguration Configuration => potConfiguration;
    protected PotConfiguration potConfiguration { get; set; }
    public ConfigurationReplicator ConfigReplicator => ConfigurationReplicator;
    public EConfigurableType ConfigurableType => EConfigurableType.Pot;
    public WorldspaceUIElement WorldspaceUI { get; set; }
    public NetworkObject CurrentPlayerConfigurer {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public Sprite TypeIcon => typeIcon;
    public Transform Transform => ((Component)this).transform;
    public Transform UIPoint => _uiPoint;
    public bool CanBeSelected => true;
    public NetworkObject SyncAccessor__003CCurrentPlayerConfigurer_003Ek__BackingField { get; set; }

    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetConfigurer(NetworkObject player);
    public override void Awake();
    protected override void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    public void SendConfigurationToClient(NetworkConnection conn);
    public override void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID);
    public override string GetManagementName();
    public override string GetDefaultManagementName();
    protected override void Destroy();
    protected virtual void LateUpdate();
    private void UpdateRotation();
    protected override void OnMinPass();
    protected override void OnTimeSkipped(int minsSkipped);
    public bool CanAcceptSeed(out string reason);
    public bool IsReadyForHarvest(out string reason);
    public override bool CanBeDestroyed(out string reason);
    public void OverrideRotation(float angle);
    protected override AdditiveDefinition ApplyAdditive(string additiveID, bool isInitialApplication);
    public override bool CanApplyAdditive(AdditiveDefinition additiveDef, out string invalidReason);
    public override bool IsPointAboveGrowSurface(Vector3 point);
    public override void SetGrowableVisible(bool visible);
    protected override Vector3 GetRandomPourTargetPosition();
    public override float GetGrowSurfaceSideLength();
    public override float GetTemperatureGrowthMultiplier();
    public override bool ContainsGrowable();
    public override float GetGrowthProgressNormalized();
    public void SetSoilState(ESoilState state);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void PlantSeed_Server(string seedID, float normalizedSeedProgress);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void PlantSeed_Client(NetworkConnection conn, string seedID, float normalizedSeedProgress);
    [ServerRpc(RequireOwnership = false)]
    public void SetGrowthProgress_Server(float progress);
    [ObserversRpc]
    private void SetGrowthProgress_Client(float progress);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetHarvestableActive_Server(int harvestableIndex, bool active);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetHarvestableActive_Client(NetworkConnection conn, int harvestableIndex, bool active);
    private void OnPlantFullyHarvested();
    public WorldspaceUIElement CreateWorldspaceUI();
    public void DestroyWorldspaceUI();
    public override BuildableItemData GetBaseData();
    public override DynamicSaveData GetSaveData();
    public virtual void Load(PotData potData);
    private void LoadPlant(PlantData data);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetConfigurer_3323014238(NetworkObject player);
    public void RpcLogic___SetConfigurer_3323014238(NetworkObject player);
    private void RpcReader___Server_SetConfigurer_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_PlantSeed_Server_606697822(string seedID, float normalizedSeedProgress);
    public void RpcLogic___PlantSeed_Server_606697822(string seedID, float normalizedSeedProgress);
    private void RpcReader___Server_PlantSeed_Server_606697822(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_PlantSeed_Client_4077118173(NetworkConnection conn, string seedID, float normalizedSeedProgress);
    private void RpcLogic___PlantSeed_Client_4077118173(NetworkConnection conn, string seedID, float normalizedSeedProgress);
    private void RpcReader___Observers_PlantSeed_Client_4077118173(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_PlantSeed_Client_4077118173(NetworkConnection conn, string seedID, float normalizedSeedProgress);
    private void RpcReader___Target_PlantSeed_Client_4077118173(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetGrowthProgress_Server_431000436(float progress);
    public void RpcLogic___SetGrowthProgress_Server_431000436(float progress);
    private void RpcReader___Server_SetGrowthProgress_Server_431000436(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetGrowthProgress_Client_431000436(float progress);
    private void RpcLogic___SetGrowthProgress_Client_431000436(float progress);
    private void RpcReader___Observers_SetGrowthProgress_Client_431000436(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetHarvestableActive_Server_3658436649(int harvestableIndex, bool active);
    public void RpcLogic___SetHarvestableActive_Server_3658436649(int harvestableIndex, bool active);
    private void RpcReader___Server_SetHarvestableActive_Server_3658436649(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetHarvestableActive_Client_338960014(NetworkConnection conn, int harvestableIndex, bool active);
    private void RpcLogic___SetHarvestableActive_Client_338960014(NetworkConnection conn, int harvestableIndex, bool active);
    private void RpcReader___Observers_SetHarvestableActive_Client_338960014(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetHarvestableActive_Client_338960014(NetworkConnection conn, int harvestableIndex, bool active);
    private void RpcReader___Target_SetHarvestableActive_Client_338960014(PooledReader PooledReader0, Channel channel);
    public override bool ReadSyncVar___ScheduleOne_002EObjectScripts_002EPot(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002EObjectScripts_002EPot_Assembly_002DCSharp_002Edll();
}