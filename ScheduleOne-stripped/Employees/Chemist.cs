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
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Property;
using ScheduleOne.StationFramework;
using ScheduleOne.UI.Management;
using UnityEngine;

namespace ScheduleOne.Employees;
public class Chemist : Employee, IConfigurable
{
    public const int MAX_ASSIGNED_STATIONS;
    [Header("References")]
    public Sprite typeIcon;
    [SerializeField]
    protected ConfigurationReplicator configReplicator;
    [Header("Behaviours")]
    public StartChemistryStationBehaviour StartChemistryStationBehaviour;
    public StartLabOvenBehaviour StartLabOvenBehaviour;
    public FinishLabOvenBehaviour FinishLabOvenBehaviour;
    public StartCauldronBehaviour StartCauldronBehaviour;
    public StartMixingStationBehaviour StartMixingStationBehaviour;
    [Header("UI")]
    public ChemistUIElement WorldspaceUIPrefab;
    public Transform uiPoint;
    [CompilerGenerated]
    [SyncVar]
    public NetworkObject _003CCurrentPlayerConfigurer_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EEmployees_002EChemistAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EEmployees_002EChemistAssembly_002DCSharp_002Edll_Excuted;
    public EntityConfiguration Configuration => configuration;
    protected ChemistConfiguration configuration { get; set; }
    public ConfigurationReplicator ConfigReplicator => configReplicator;
    public EConfigurableType ConfigurableType => EConfigurableType.Chemist;
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
    protected override void AssignProperty(ScheduleOne.Property.Property prop, bool warp);
    protected override void UnassignProperty();
    protected override void ResetConfiguration();
    protected override void Fire();
    public override void OnSpawnServer(NetworkConnection connection);
    public void SendConfigurationToClient(NetworkConnection conn);
    protected override void UpdateBehaviour();
    private void TryStartNewTask();
    private bool AnyWorkInProgress();
    protected override bool ShouldIdle();
    private void StartChemistryStation(ChemistryStation station);
    private void StartCauldron(Cauldron cauldron);
    private void StartLabOven(LabOven oven);
    private void FinishLabOven(LabOven oven);
    private void StartMixingStation(MixingStation station);
    public override EmployeeHome GetHome();
    public List<LabOven> GetLabOvensReadyToFinish();
    public List<LabOven> GetLabOvensReadyToStart();
    public List<ChemistryStation> GetChemistryStationsReadyToStart();
    public List<Cauldron> GetCauldronsReadyToStart();
    public List<MixingStation> GetMixingStationsReadyToStart();
    protected List<LabOven> GetLabOvensReadyToMove();
    protected List<ChemistryStation> GetChemStationsReadyToMove();
    protected List<Cauldron> GetCauldronsReadyToMove();
    protected List<MixingStation> GetMixStationsReadyToMove();
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
    public override bool ReadSyncVar___ScheduleOne_002EEmployees_002EChemist(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    public override void Awake();
}