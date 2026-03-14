using System;
using System.Collections;
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
using ScheduleOne.Management;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Tiles;
using ScheduleOne.UI;
using ScheduleOne.UI.Management;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScheduleOne.ObjectScripts;
public class MushroomBed : GrowContainer, IConfigurable
{
    public enum EMushroomBedSoilAppearance
    {
        NoSpores,
        MaskedSpores,
        FullSpores
    }

    [Header("Mushroom Bed")]
    [SerializeField]
    private float _internalSideLength;
    [SerializeField]
    private ConfigurationReplicator _configurationReplicator;
    [SerializeField]
    private Sprite _typeIcon;
    [SerializeField]
    private MushroomBedUIElement _worldspaceUIPrefab;
    [SerializeField]
    private ParticleSystem _poofParticles;
    [SerializeField]
    private AudioSourceController _poofSound;
    [SerializeField]
    private Transform _colonyAlignment;
    [SerializeField]
    private Transform _mixFXContainer;
    [SerializeField]
    private ParticleSystem[] _mixParticles;
    [SerializeField]
    private AudioSourceController _mixSound;
    [CompilerGenerated]
    [SyncVar]
    [HideInInspector]
    public NetworkObject _003CCurrentPlayerConfigurer_003Ek__BackingField;
    private Material _soilMaterialInstance;
    private EMushroomBedSoilAppearance _currentSoilAppearance;
    private bool _mushroomBedColdAtLeastOnce;
    public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002EMushroomBedAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002EMushroomBedAssembly_002DCSharp_002Edll_Excuted;
    public ShroomColony CurrentColony { get; set; }
    public EntityConfiguration Configuration => _configuration;
    public ConfigurationReplicator ConfigReplicator => _configurationReplicator;
    public EConfigurableType ConfigurableType => EConfigurableType.MushroomBed;
    public WorldspaceUIElement WorldspaceUI { get; set; }
    public NetworkObject CurrentPlayerConfigurer {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public Sprite TypeIcon => _typeIcon;
    public Transform Transform => ((Component)this).transform;
    public Transform UIPoint => _uiPoint;
    public bool CanBeSelected => true;
    protected MushroomBedConfiguration _configuration { get; set; }
    public NetworkObject SyncAccessor__003CCurrentPlayerConfigurer_003Ek__BackingField { get; set; }

    public override void OnSpawnServer(NetworkConnection connection);
    public void SendConfigurationToClient(NetworkConnection conn);
    public override void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID);
    public override string GetManagementName();
    protected override void Destroy();
    public override bool CanBeDestroyed(out string reason);
    public override bool IsPointAboveGrowSurface(Vector3 point);
    public override void SetGrowableVisible(bool visible);
    public override bool CanApplyAdditive(AdditiveDefinition additiveDef, out string invalidReason);
    protected override Vector3 GetRandomPourTargetPosition();
    public override float GetGrowSurfaceSideLength();
    protected override Material GetSoilMaterial();
    public override void SetSoil(SoilDefinition soil);
    public override void SetMoistureAmount(float amount);
    public void ConfigureSoilAppearance(EMushroomBedSoilAppearance appearance, Texture2D sporeMask = null);
    public bool IsReadyForHarvest(out string reason);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetConfigurer(NetworkObject player);
    protected override AdditiveDefinition ApplyAdditive(string additiveID, bool isInitialApplication);
    public void PlayMixFXAtPoint(Vector3 point);
    protected override void OnTileTemperatureChanged(Tile tile, float newTemp);
    public override bool ContainsGrowable();
    public override float GetGrowthProgressNormalized();
    [ServerRpc(RequireOwnership = false)]
    public void CreateAndAssignColony_Server(string shroomSpawnID);
    private void CreateAndAssignColony(ShroomSpawnDefinition shroomSpawn);
    public void AssignColony(ShroomColony colony);
    private void OnColonyFullyHarvested();
    protected override void ClearSoil();
    public void CheckShowTemperatureHint();
    public WorldspaceUIElement CreateWorldspaceUI();
    public void DestroyWorldspaceUI();
    public override BuildableItemData GetBaseData();
    public override DynamicSaveData GetSaveData();
    public virtual void Load(MushroomBedData mushroomBedData);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetConfigurer_3323014238(NetworkObject player);
    public void RpcLogic___SetConfigurer_3323014238(NetworkObject player);
    private void RpcReader___Server_SetConfigurer_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_CreateAndAssignColony_Server_3615296227(string shroomSpawnID);
    public void RpcLogic___CreateAndAssignColony_Server_3615296227(string shroomSpawnID);
    private void RpcReader___Server_CreateAndAssignColony_Server_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override bool ReadSyncVar___ScheduleOne_002EObjectScripts_002EMushroomBed(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    public override void Awake();
}