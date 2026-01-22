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
using UnityEngine;

namespace ScheduleOne.Vehicles;
[RequireComponent(typeof(LandVehicle))]
public class VehicleLights : NetworkBehaviour
{
    [SerializeField]
    private bool _debug;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public bool _003CHeadlightsOn_003Ek__BackingField;
    [Header("Headlights")]
    public MeshRenderer[] headLightMeshes;
    public OptimizedLight[] headLightSources;
    public Material headlightMat_On;
    public Material headLightMat_Off;
    private bool headLightsApplied;
    [Header("Brake lights")]
    public MeshRenderer[] brakeLightMeshes;
    public Light[] brakeLightSources;
    public Material brakeLightMat_On;
    public Material brakeLightMat_Off;
    private bool brakeLightsApplied;
    [Header("Reverse lights")]
    public bool hasReverseLights;
    public MeshRenderer[] reverseLightMeshes;
    public Light[] reverseLightSources;
    public Material reverseLightMat_On;
    public Material reverseLightMat_Off;
    private bool reverseLightsApplied;
    private LandVehicle vehicle;
    public SyncVar<bool> syncVar____003CHeadlightsOn_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EVehicles_002EVehicleLightsAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EVehicles_002EVehicleLightsAssembly_002DCSharp_002Edll_Excuted;
    public bool HeadlightsOn {[CompilerGenerated]
        get; [CompilerGenerated]
        [ServerRpc(RunLocally = true, RequireOwnership = false)]
        set; }
    public bool SyncAccessor__003CHeadlightsOn_003Ek__BackingField { get; set; }

    public override void Awake();
    protected virtual void Update();
    private void UpdateVisuals();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_set_HeadlightsOn_1140765316(bool value);
    [SpecialName]
    public void RpcLogic___set_HeadlightsOn_1140765316(bool value);
    private void RpcReader___Server_set_HeadlightsOn_1140765316(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override bool ReadSyncVar___ScheduleOne_002EVehicles_002EVehicleLights(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    private void Awake_UserLogic_ScheduleOne_002EVehicles_002EVehicleLights_Assembly_002DCSharp_002Edll();
}