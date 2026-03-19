using System;
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
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.Heatmap;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Property;
using ScheduleOne.Tiles;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Temperature;
public class AirConditioner : GridItem
{
    public enum EMode
    {
        Off,
        Cooling,
        Heating
    }

    private const float CoolingTemperature;
    private const float HeatingTemperature;
    [SerializeField]
    private Light _coolingLight;
    [SerializeField]
    private Light _heatingLight;
    [SerializeField]
    private AudioSourceController _beepSound;
    [SerializeField]
    private AudioSourceController _loopSound;
    [SerializeField]
    private ParticleSystem _heatParticles;
    [SerializeField]
    private ParticleSystem _coolParticles;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    [HideInInspector]
    public EMode _003CCurrentMode_003Ek__BackingField;
    public SyncVar<EMode> syncVar____003CCurrentMode_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002ETemperature_002EAirConditionerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ETemperature_002EAirConditionerAssembly_002DCSharp_002Edll_Excuted;
    [field: SerializeField]
    public TemperatureEmitter TemperatureEmitter { get; private set; }

    [field: SerializeField]
    public TemperatureDisplay TemperatureDisplay { get; private set; }
    public EMode CurrentMode {[CompilerGenerated]
        get; [CompilerGenerated]
        private set; }
    public EMode SyncAccessor__003CCurrentMode_003Ek__BackingField { get; set; }

    public override void Awake();
    public override void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID);
    private void HeatmapVisibilityChanged(ScheduleOne.Property.Property property, bool visible);
    protected override void Destroy();
    private void Update();
    private void UpdateLoopSound();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetMode_Server(EMode mode);
    public void SetMode(EMode mode);
    private void ApplyMode();
    private void OnModeChanged(EMode previous, EMode current, bool asServer);
    [Button]
    public void SetOff();
    [Button]
    public void SetCooling();
    [Button]
    public void SetHeating();
    public override BuildableItemData GetBaseData();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetMode_Server_3835190203(EMode mode);
    public void RpcLogic___SetMode_Server_3835190203(EMode mode);
    private void RpcReader___Server_SetMode_Server_3835190203(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override bool ReadSyncVar___ScheduleOne_002ETemperature_002EAirConditioner(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002ETemperature_002EAirConditioner_Assembly_002DCSharp_002Edll();
}