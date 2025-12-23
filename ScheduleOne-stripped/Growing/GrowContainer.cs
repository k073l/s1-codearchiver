using System;
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
using ScheduleOne.Heatmap;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Lighting;
using ScheduleOne.Management;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Property;
using ScheduleOne.Tiles;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Growing;
public abstract class GrowContainer : GridItem, IUsable, ITransitEntity
{
    public const float DryThreshold;
    [SerializeField]
    private float _moistureDrainPerHour;
    [SerializeField]
    public SoilDefinition[] AllowedSoils;
    [SerializeField]
    public AdditiveDefinition[] AllowedAdditives;
    [Header("Grow Container References")]
    [SerializeField]
    private GrowContainerInteraction _interactionHandler;
    [SerializeField]
    protected MeshRenderer[] _soilMeshRenderers;
    [SerializeField]
    protected Transform _soilMinTransform;
    [SerializeField]
    protected Transform _soilMaxTransform;
    [SerializeField]
    private MeshRenderer _additiveDisplayTemplate;
    [SerializeField]
    protected Transform _pourTarget;
    [SerializeField]
    protected Transform _uiPoint;
    [SerializeField]
    protected Transform[] _accessPoints;
    [SerializeField]
    private ParticleSystem[] _soilClearedParticles;
    [SerializeField]
    private AudioSourceController _soilClearedSound;
    [Header("Optional References")]
    [SerializeField]
    private UsableLightSource _lightSourceOverride;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public NetworkObject _003CNPCUserObject_003Ek__BackingField;
    [CompilerGenerated]
    [HideInInspector]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public NetworkObject _003CPlayerUserObject_003Ek__BackingField;
    protected float _currentSoilAmount;
    protected float _currentMoistureAmount;
    protected int _remainingSoilUses;
    private List<MeshRenderer> _activeAdditiveDisplays;
    public SyncVar<NetworkObject> syncVar____003CNPCUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CPlayerUserObject_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EGrowing_002EGrowContainerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EGrowing_002EGrowContainerAssembly_002DCSharp_002Edll_Excuted;
    [field: Header("Grow Container Settings")]
    [field: SerializeField]
    public float SoilCapacity { get; private set; } = 30f;

    [field: SerializeField]
    public float MoistureCapacity { get; private set; } = 5f;

    [field: SerializeField]
    public bool HidePlantDuringPourTasks { get; private set; } = true;

    [field: SerializeField]
    public Transform SoilContainer { get; private set; }

    [field: SerializeField]
    public Transform PourableStartPoint { get; private set; }

    [field: SerializeField]
    public GrowContainerSurfaceCover SurfaceCover { get; private set; }

    [field: SerializeField]
    public GrowContainerCameraHandler CameraHandler { get; private set; }

    [field: SerializeField]
    public TemperatureDisplay TemperatureDisplay { get; private set; }
    public float NormalizedSoilAmount => _currentSoilAmount / SoilCapacity;
    public bool IsFullyFilledWithSoil { get; }
    public float NormalizedMoistureAmount => _currentMoistureAmount / MoistureCapacity;
    public SoilDefinition CurrentSoil { get; private set; }
    public List<AdditiveDefinition> AppliedAdditives { get; private set; } = new List<AdditiveDefinition>();
    public NetworkObject NPCUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public NetworkObject PlayerUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public string Name => base.ItemInstance.Name;
    public List<ItemSlot> InputSlots { get; set; } = new List<ItemSlot>();
    public List<ItemSlot> OutputSlots { get; set; } = new List<ItemSlot>();
    public Transform LinkOrigin => _uiPoint;
    public Transform[] AccessPoints => _accessPoints;
    public bool Selectable { get; }
    public bool IsAcceptingItems { get; set; } = true;
    public NetworkObject SyncAccessor__003CNPCUserObject_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CPlayerUserObject_003Ek__BackingField { get; set; }

    public void ConfigureInteraction(string labelText, InteractableObject.EInteractableState interactionState);
    public void ConfigureInteraction(string labelText, InteractableObject.EInteractableState interactionState, Vector3 labelPosition);
    public override void Awake();
    public override void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID);
    private void HeatmapVisibilityChanged(ScheduleOne.Property.Property property, bool visible);
    protected override void Destroy();
    public override void OnSpawnServer(NetworkConnection connection);
    protected virtual void OnMinPass();
    protected virtual void OnTimeSkipped(int minsSkipped);
    private void DrainMoisture(int minutes);
    public float GetAverageLightExposure(out float growSpeedMultiplier);
    public abstract bool IsPointAboveGrowSurface(Vector3 point);
    public abstract void SetGrowableVisible(bool visible);
    public abstract float GetGrowSurfaceSideLength();
    public abstract bool ContainsGrowable();
    public abstract float GetGrowthProgressNormalized();
    public virtual void SetSoil(SoilDefinition soil);
    public void ChangeSoilAmount(float amount);
    public void SetSoilAmount(float amount);
    public void SetRemainingSoilUses(int uses);
    public void SyncSoilData();
    [ServerRpc(RequireOwnership = false)]
    private void SetSoilData_Server(string soilID, float amount, int uses);
    [ObserversRpc]
    [TargetRpc]
    private void SetSoilData_Client(NetworkConnection conn, string soilID, float amount, int uses);
    protected virtual void RefreshSoilVisuals();
    protected virtual void ClearSoil();
    public bool IsSoilAllowed(SoilDefinition soil);
    protected virtual Material GetSoilMaterial();
    public void ChangeMoistureAmount(float amount);
    public virtual void SetMoistureAmount(float amount);
    public void SyncMoistureData();
    [ServerRpc(RequireOwnership = false)]
    private void SetMoistureData_Server(float amount);
    [ObserversRpc]
    [TargetRpc]
    private void SetMoistureData_Client(NetworkConnection conn, float amount);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void ApplyAdditive_Server(string additiveID);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void ApplyAdditive_Client(NetworkConnection conn, string additiveID, bool initialApplication);
    protected virtual AdditiveDefinition ApplyAdditive(string additiveID, bool isInitialApplication);
    public virtual float GetTemperatureGrowthMultiplier();
    public bool IsAdditiveApplied(string additiveID);
    protected void ClearAdditives();
    public virtual bool CanApplyAdditive(AdditiveDefinition additiveDef, out string invalidReason);
    public void SetPourTargetActive(bool active);
    public void RandomizePourTargetPosition();
    public Vector3 GetCurrentTargetPosition();
    protected abstract Vector3 GetRandomPourTargetPosition();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetPlayerUser(NetworkObject playerObject);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetNPCUser(NetworkObject npcObject);
    protected void Load(GrowContainerData data);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetSoilData_Server_3104499779(string soilID, float amount, int uses);
    private void RpcLogic___SetSoilData_Server_3104499779(string soilID, float amount, int uses);
    private void RpcReader___Server_SetSoilData_Server_3104499779(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetSoilData_Client_433593356(NetworkConnection conn, string soilID, float amount, int uses);
    private void RpcLogic___SetSoilData_Client_433593356(NetworkConnection conn, string soilID, float amount, int uses);
    private void RpcReader___Observers_SetSoilData_Client_433593356(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetSoilData_Client_433593356(NetworkConnection conn, string soilID, float amount, int uses);
    private void RpcReader___Target_SetSoilData_Client_433593356(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetMoistureData_Server_431000436(float amount);
    private void RpcLogic___SetMoistureData_Server_431000436(float amount);
    private void RpcReader___Server_SetMoistureData_Server_431000436(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetMoistureData_Client_530160725(NetworkConnection conn, float amount);
    private void RpcLogic___SetMoistureData_Client_530160725(NetworkConnection conn, float amount);
    private void RpcReader___Observers_SetMoistureData_Client_530160725(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetMoistureData_Client_530160725(NetworkConnection conn, float amount);
    private void RpcReader___Target_SetMoistureData_Client_530160725(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ApplyAdditive_Server_3615296227(string additiveID);
    public void RpcLogic___ApplyAdditive_Server_3615296227(string additiveID);
    private void RpcReader___Server_ApplyAdditive_Server_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ApplyAdditive_Client_619441887(NetworkConnection conn, string additiveID, bool initialApplication);
    private void RpcLogic___ApplyAdditive_Client_619441887(NetworkConnection conn, string additiveID, bool initialApplication);
    private void RpcReader___Observers_ApplyAdditive_Client_619441887(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_ApplyAdditive_Client_619441887(NetworkConnection conn, string additiveID, bool initialApplication);
    private void RpcReader___Target_ApplyAdditive_Client_619441887(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetPlayerUser_3323014238(NetworkObject playerObject);
    public void RpcLogic___SetPlayerUser_3323014238(NetworkObject playerObject);
    private void RpcReader___Server_SetPlayerUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SetNPCUser_3323014238(NetworkObject npcObject);
    public void RpcLogic___SetNPCUser_3323014238(NetworkObject npcObject);
    private void RpcReader___Server_SetNPCUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override bool ReadSyncVar___ScheduleOne_002EGrowing_002EGrowContainer(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002EGrowing_002EGrowContainer_Assembly_002DCSharp_002Edll();
}