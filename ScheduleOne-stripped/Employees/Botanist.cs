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
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.EntityFramework;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Property;
using ScheduleOne.UI.Management;
using UnityEngine;

namespace ScheduleOne.Employees;
public class Botanist : Employee, IConfigurable
{
    public float CRITICAL_WATERING_THRESHOLD;
    public float WATERING_THRESHOLD;
    public float TARGET_WATER_LEVEL_MIN;
    public float TARGET_WATER_LEVEL_MAX;
    public float SOIL_POUR_TIME;
    public float WATER_POUR_TIME;
    public float ADDITIVE_POUR_TIME;
    public float SEED_SOW_TIME;
    public float HARVEST_TIME;
    [Header("References")]
    public Sprite typeIcon;
    [SerializeField]
    protected ConfigurationReplicator configReplicator;
    public PotActionBehaviour PotActionBehaviour;
    public StartDryingRackBehaviour StartDryingRackBehaviour;
    public StopDryingRackBehaviour StopDryingRackBehaviour;
    [Header("UI")]
    public BotanistUIElement WorldspaceUIPrefab;
    public Transform uiPoint;
    [Header("Settings")]
    public int MaxAssignedPots;
    public DialogueContainer NoAssignedStationsDialogue;
    public DialogueContainer UnspecifiedPotsDialogue;
    public DialogueContainer NullDestinationPotsDialogue;
    public DialogueContainer MissingMaterialsDialogue;
    public DialogueContainer NoPotsRequireWorkDialogue;
    [CompilerGenerated]
    [SyncVar]
    public NetworkObject _003CCurrentPlayerConfigurer_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EEmployees_002EBotanistAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EEmployees_002EBotanistAssembly_002DCSharp_002Edll_Excuted;
    public EntityConfiguration Configuration => configuration;
    protected BotanistConfiguration configuration { get; set; }
    public ConfigurationReplicator ConfigReplicator => configReplicator;
    public EConfigurableType ConfigurableType => EConfigurableType.Botanist;
    public WorldspaceUIElement WorldspaceUI { get; set; }
    public NetworkObject CurrentPlayerConfigurer {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public Sprite TypeIcon => typeIcon;
    public Transform Transform => ((Component)this).transform;
    public Transform UIPoint => uiPoint;
    public bool CanBeSelected => true;
    public ScheduleOne.Property.Property ParentProperty => base.AssignedProperty;
    public NetworkObject SyncAccessor__003CCurrentPlayerConfigurer_003Ek__BackingField { get; set; }

    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetConfigurer(NetworkObject player);
    protected override void Start();
    protected override void UpdateBehaviour();
    private bool IsEntityAccessible(ITransitEntity entity);
    private void StartAction(Pot pot, PotActionBehaviour.EActionType actionType);
    private void StartDryingRack(DryingRack rack);
    private void StopDryingRack(DryingRack rack);
    public override void OnSpawnServer(NetworkConnection connection);
    public void SendConfigurationToClient(NetworkConnection conn);
    protected override void AssignProperty(ScheduleOne.Property.Property prop, bool warp);
    protected override void UnassignProperty();
    protected override void ResetConfiguration();
    protected override void Fire();
    private bool CanMoveDryableToRack(out QualityItemInstance dryable, out DryingRack destinationRack, out int moveQuantity);
    public QualityItemInstance GetDryableInSupplies();
    private DryingRack GetAssignedDryingRackFor(QualityItemInstance dryable, out int rackInputCapacity);
    public ItemInstance GetItemInSupplies(string id);
    public ItemInstance GetSeedInSupplies();
    protected override bool ShouldIdle();
    public override EmployeeHome GetHome();
    private bool AreThereUnspecifiedPots();
    private bool AreThereNullDestinationPots();
    private bool IsMissingRequiredMaterials();
    private Pot GetPotForWatering(float threshold, bool excludeFullyGrowm);
    private Pot GetPotForSoilSour();
    private List<Pot> GetPotsReadyForSeed();
    private T GetAccessableEntity<T>(T entity)
        where T : ITransitEntity;
    private List<T> GetAccessableEntities<T>(List<T> list)
        where T : ITransitEntity;
    private List<Pot> FilterPotsForSpecifiedSeed(List<Pot> pots);
    private Pot GetPotForAdditives(out int additiveNumber);
    private List<Pot> GetPotsForHarvest();
    private List<DryingRack> GetRacksToStart();
    private List<DryingRack> GetRacksToStop();
    private List<DryingRack> GetRacksReadyToMove();
    public WorldspaceUIElement CreateWorldspaceUI();
    public void DestroyWorldspaceUI();
    public override NPCData GetNPCData();
    public override DynamicSaveData GetSaveData();
    public override List<string> WriteData(string parentFolderPath);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetConfigurer_3323014238(NetworkObject player);
    public void RpcLogic___SetConfigurer_3323014238(NetworkObject player);
    private void RpcReader___Server_SetConfigurer_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override bool ReadSyncVar___ScheduleOne_002EEmployees_002EBotanist(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    public override void Awake();
}