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
using ScheduleOne.StationFramework;
using ScheduleOne.UI.Management;
using UnityEngine;

namespace ScheduleOne.Employees;
public class Botanist : Employee, IConfigurable
{
    public const float CriticalWateringThreshold;
    public const float WateringThreshold;
    public const float MoistureLevelRandomMin;
    public const float MoistureLevelRandomMax;
    public const float SoilPourTime;
    public const float WaterPourTime;
    public const float AdditivePourTime;
    public const float SeedSowTime;
    public const float IndividualHarvestTime;
    public const float ApplySpawnTime;
    [Header("References")]
    public Sprite typeIcon;
    [SerializeField]
    protected ConfigurationReplicator configReplicator;
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
    private StartDryingRackBehaviour _startDryingRackBehaviour;
    private StopDryingRackBehaviour _stopDryingRackBehaviour;
    private UseSpawnStationBehaviour _useSpawnStationBehaviour;
    private AddSoilToGrowContainerBehaviour _addSoilToGrowContainerBehaviour;
    private ApplyAdditiveToGrowContainerBehaviour _applyAdditiveToGrowContainerBehaviour;
    private SowSeedInPotBehaviour _sowSeedInPotBehaviour;
    private WaterPotBehaviour _waterPotBehaviour;
    private HarvestPotBehaviour _harvestPotBehaviour;
    private MistMushroomBedBehaviour _mistMushroomBedBehaviour;
    private HarvestMushroomBedBehaviour _harvestMushroomBedBehaviour;
    private ApplySpawnToMushroomBedBehaviour _applySpawnToMushroomBedBehaviour;
    private List<Behaviour> _workBehaviours;
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
    public override void Awake();
    protected override void UpdateBehaviour();
    private bool IsEntityAccessible(ITransitEntity entity);
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
    protected override bool ShouldIdle();
    public override EmployeeHome GetHome();
    public ITransitEntity GetSuppliesAsTransitEntity();
    private Pot GetPotForWatering(float threshold);
    private List<GrowContainer> GetGrowContainersForSoilPour();
    private List<Pot> GetPotsReadyForSeed();
    private List<GrowContainer> GetGrowContainersForAdditives();
    private List<Pot> GetPotsForHarvest();
    private MushroomBed GetMushroomBedForMisting(float threshold);
    private List<MushroomBed> GetMushroomBedsForHarvest();
    private List<MushroomBed> GetBedsReadyForSpawn();
    private List<DryingRack> GetRacksToStart();
    private List<DryingRack> GetRacksToStop();
    private List<DryingRack> GetRacksReadyToMove();
    private List<MushroomSpawnStation> GetSpawnStationsReadyToUse();
    private List<MushroomSpawnStation> GetSpawnStationsReadyToMove();
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
    protected override void Awake_UserLogic_ScheduleOne_002EEmployees_002EBotanist_Assembly_002DCSharp_002Edll();
}