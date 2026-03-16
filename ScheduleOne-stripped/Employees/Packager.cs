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
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Property;
using ScheduleOne.UI.Management;
using UnityEngine;

namespace ScheduleOne.Employees;
public class Packager : Employee, IConfigurable
{
    [Header("References")]
    public Sprite typeIcon;
    [SerializeField]
    protected ConfigurationReplicator configReplicator;
    public PackagingStationBehaviour PackagingBehaviour;
    public BrickPressBehaviour BrickPressBehaviour;
    [Header("UI")]
    public PackagerUIElement WorldspaceUIPrefab;
    public Transform uiPoint;
    [Header("Settings")]
    public int MaxAssignedStations;
    [Header("Proficiency Settings")]
    public float PackagingSpeedMultiplier;
    [CompilerGenerated]
    [SyncVar]
    public NetworkObject _003CCurrentPlayerConfigurer_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EEmployees_002EPackagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EEmployees_002EPackagerAssembly_002DCSharp_002Edll_Excuted;
    public EntityConfiguration Configuration => configuration;
    protected PackagerConfiguration configuration { get; set; }
    public ConfigurationReplicator ConfigReplicator => configReplicator;
    public EConfigurableType ConfigurableType => EConfigurableType.Packager;
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
    private void StartPackaging(PackagingStation station);
    private void StartPress(BrickPress press);
    private void StartMoveItem(PackagingStation station);
    private void StartMoveItem(BrickPress press);
    protected PackagingStation GetStationToAttend();
    protected BrickPress GetBrickPress();
    protected PackagingStation GetStationMoveItems();
    protected BrickPress GetBrickPressMoveItems();
    protected AdvancedTransitRoute GetTransitRouteReady(out ItemInstance item);
    protected override bool ShouldIdle();
    public override EmployeeHome GetHome();
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
    public override bool ReadSyncVar___ScheduleOne_002EEmployees_002EPackager(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    public override void Awake();
}