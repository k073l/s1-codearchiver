using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using FishNet;
using FishNet.Component.Ownership;
using FishNet.Component.Transforming;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using Pathfinding;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Map;
using ScheduleOne.Money;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Storage;
using ScheduleOne.Tools;
using ScheduleOne.UI;
using ScheduleOne.Vehicles.AI;
using ScheduleOne.Vehicles.Modification;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace ScheduleOne.Vehicles;
[RequireComponent(typeof(NetworkTransform))]
[RequireComponent(typeof(PredictedOwner))]
[RequireComponent(typeof(PhysicsDamageable))]
public class LandVehicle : NetworkBehaviour, IGUIDRegisterable, ISaveable
{
    public const float KINEMATIC_THRESHOLD_DISTANCE;
    public const float MAX_TURNOVER_SPEED;
    public const float TURNOVER_FORCE;
    public const bool USE_WHEEL;
    public const float SPEED_DISPLAY_MULTIPLIER;
    public bool DEBUG;
    [Header("Settings")]
    [SerializeField]
    protected string vehicleName;
    [SerializeField]
    protected string vehicleCode;
    [SerializeField]
    protected float vehiclePrice;
    public bool UseHumanoidCollider;
    public bool SpawnAsPlayerOwned;
    [Header("References")]
    [SerializeField]
    protected GameObject vehicleModel;
    [SerializeField]
    protected WheelCollider[] driveWheels;
    [SerializeField]
    protected WheelCollider[] steerWheels;
    [SerializeField]
    protected WheelCollider[] handbrakeWheels;
    [HideInInspector]
    public List<Wheel> wheels;
    [SerializeField]
    protected InteractableObject intObj;
    [SerializeField]
    protected List<Transform> exitPoints;
    public Rigidbody Rb;
    public VehicleColor Color;
    public VehicleSeat[] Seats;
    public BoxCollider boundingBox;
    public VehicleAgent Agent;
    public SmoothedVelocityCalculator VelocityCalculator;
    public StorageDoorAnimation Trunk;
    public NavMeshObstacle NavMeshObstacle;
    public NavmeshCut NavmeshCut;
    public VehicleHumanoidCollider HumanoidColliderContainer;
    public POI POI;
    private List<PlayerPusher> pushers;
    [SerializeField]
    protected Transform centerOfMass;
    [SerializeField]
    protected Transform cameraOrigin;
    [SerializeField]
    protected VehicleLights lights;
    [Header("Steer settings")]
    [SerializeField]
    protected float maxSteeringAngle;
    [SerializeField]
    protected float steerRate;
    [SerializeField]
    protected bool flipSteer;
    [Header("Drive settings")]
    [SerializeField]
    protected AnimationCurve motorTorque;
    public float TopSpeed;
    [Range(2f, 16f)]
    [SerializeField]
    protected float diffGearing;
    [SerializeField]
    protected float handBrakeForce;
    [SerializeField]
    protected AnimationCurve brakeForce;
    [SerializeField]
    [Range(0.1f, 3f)]
    protected float BrakeForceMultiplier;
    [Range(0.5f, 10f)]
    [SerializeField]
    protected float downforce;
    [Range(0f, 1f)]
    [SerializeField]
    protected float reverseMultiplier;
    [Header("Control overrides")]
    public bool overrideControls;
    public float throttleOverride;
    public float steerOverride;
    [Header("Storage settings")]
    public StorageEntity Storage;
    private VehicleSeat localPlayerSeat;
    private bool _isOccupied;
    private RollingAverage<float> previousSpeeds;
    private const int previousSpeedsSampleSize;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public float _003CCurrentSteerAngle_003Ek__BackingField;
    private float lastFrameSteerAngle;
    private float lastReplicatedSteerAngle;
    private bool justExitedVehicle;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public bool _003CBrakesApplied_003Ek__BackingField;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public bool _003CIsReversing_003Ek__BackingField;
    private Vector3 lastFramePosition;
    private Transform closestExitPoint;
    private float timeOnSpawn;
    private float timeOnLastOccupied;
    [HideInInspector]
    public ParkData CurrentParkData;
    private VehicleLoader loader;
    public Action onVehicleStart;
    public Action onVehicleStop;
    public Action onHandbrakeApplied;
    public Action<Collision> onCollision;
    public SyncVar<float> syncVar____003CCurrentSteerAngle_003Ek__BackingField;
    public SyncVar<bool> syncVar____003CBrakesApplied_003Ek__BackingField;
    public SyncVar<bool> syncVar____003CIsReversing_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EVehicles_002ELandVehicleAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EVehicles_002ELandVehicleAssembly_002DCSharp_002Edll_Excuted;
    public string VehicleName => vehicleName;
    public string VehicleCode => vehicleCode;
    public float VehiclePrice => vehiclePrice;
    public bool IsPlayerOwned { get; protected set; }
    public bool IsVisible { get; protected set; } = true;
    public Guid GUID { get; protected set; }
    public Vector3 BoundingBoxDimensions => new Vector3(boundingBox.size.x * ((Component)boundingBox).transform.localScale.x, boundingBox.size.y * ((Component)boundingBox).transform.localScale.y, boundingBox.size.z * ((Component)boundingBox).transform.localScale.z);
    public Transform driverEntryPoint => exitPoints[0];
    public float ActualMaxSteeringAngle { get; }
    public bool MaxSteerAngleOverridden { get; private set; }
    public float OverriddenMaxSteerAngle { get; private set; }
    public int Capacity => Seats.Length;
    public int CurrentPlayerOccupancy => Seats.Count(default);
    public bool LocalPlayerIsDriver { get; protected set; }
    public bool LocalPlayerIsInVehicle { get; protected set; }
    public bool IsOccupied { get; set; }
    public Player DriverPlayer { get; }
    public List<Player> OccupantPlayers => (
        from s in Seats
        where s.isOccupied
        select s.Occupant).ToList();
    public NPC[] OccupantNPCs { get; protected set; } = new NPC[0];
    public float Speed_Kmh { get; protected set; }
    public float Speed_Ms => Speed_Kmh / 3.6f;
    public float Speed_Mph => Speed_Kmh * 0.621371f;
    public bool IsPhysicallySimulated { get; protected set; }
    public float currentThrottle { get; protected set; }
    public float CurrentSteerAngle {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }

    [HideInInspector]
    public bool BrakesApplied {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }

    [HideInInspector]
    public bool IsReversing {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public bool handbrakeApplied { get; protected set; }
    public float boundingBaseOffset => ((Component)this).transform.InverseTransformPoint(((Component)boundingBox).transform.position).y + boundingBox.size.y * 0.5f;
    private float timeSinceSpawn => Time.timeSinceLevelLoad - timeOnSpawn;
    public float timeSinceLastOccupied => Time.timeSinceLevelLoad - timeOnLastOccupied;
    public EVehicleColor OwnedColor { get; private set; } = EVehicleColor.White;
    public bool isParked => (Object)(object)CurrentParkingLot != (Object)null;
    public ParkingLot CurrentParkingLot { get; protected set; }
    public ParkingSpot CurrentParkingSpot { get; protected set; }
    public string SaveFolderName => vehicleCode + "_" + GUID.ToString().Substring(0, 6);
    public string SaveFileName => "Vehicle";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; } = true;
    public float SyncAccessor__003CCurrentSteerAngle_003Ek__BackingField { get; set; }
    public bool SyncAccessor__003CBrakesApplied_003Ek__BackingField { get; set; }
    public bool SyncAccessor__003CIsReversing_003Ek__BackingField { get; set; }

    public override void Awake();
    public virtual void InitializeSaveable();
    public override void OnStartServer();
    public override void OnSpawnServer(NetworkConnection connection);
    public override void OnStartClient();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SetIsPlayerOwned(NetworkConnection conn, bool playerOwned);
    private void RefreshPoI();
    public void SetGUID(Guid guid);
    protected virtual void Start();
    private void Exit(ExitAction action);
    protected virtual void OnDestroy();
    private void GetNetworth(MoneyManager.FloatContainer container);
    protected virtual void Update();
    protected virtual void FixedUpdate();
    private void UpdateSpeedCalculation();
    private void UpdateOutOfBounds();
    private void OnCollisionEnter(Collision collision);
    [ServerRpc(RequireOwnership = false)]
    protected virtual void SetOwner(NetworkConnection conn);
    [ObserversRpc]
    protected virtual void OnOwnerChanged();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetTransform_Server(Vector3 pos, Quaternion rot);
    [ObserversRpc(RunLocally = true)]
    public void SetTransform(Vector3 pos, Quaternion rot);
    public void DestroyVehicle();
    protected virtual void UpdateThrottle();
    protected virtual void ApplyThrottle();
    public void ApplyHandbrake();
    private void ApplyDownForce();
    private void UpdateTurnOver();
    protected virtual void UpdateSteerAngle();
    [ServerRpc(RequireOwnership = false)]
    private void SetSteeringAngle(float sa);
    protected virtual void ApplySteerAngle();
    public void AlignTo(Transform target, EParkingAlignment type, bool network = false);
    public Tuple<Vector3, Quaternion> GetAlignmentTransform(Transform target, EParkingAlignment type);
    public float GetVehicleValue();
    public void OverrideMaxSteerAngle(float maxAngle);
    public void ResetMaxSteerAngle();
    public void SetObstaclesActive(bool active);
    private void UpdatePhysicallySimulated(bool forceApply = false);
    private bool ShouldBePhysicallySimulated();
    public VehicleSeat GetFirstFreeSeat();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetSeatOccupant(NetworkConnection conn, int seatIndex, NetworkConnection occupant);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    private void SetSeatOccupant_Server(int seatIndex, NetworkConnection conn);
    private void Hovered();
    private void Interacted();
    private void StartVehicle();
    private void StopVehicle();
    private void EnterVehicle();
    public void ExitVehicle();
    private void EndJustExited();
    public Transform GetExitPoint(int seatIndex = 0);
    private Transform GetClosestExitPoint(Vector3 pos);
    private Transform GetValidExitPoint(List<Transform> possibleExitPoints);
    public void AddNPCOccupant(NPC npc);
    public void RemoveNPCOccupant(NPC npc);
    public virtual bool CanBeRecovered();
    public virtual void RecoverVehicle();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendOwnedColor(EVehicleColor col);
    [TargetRpc]
    [ObserversRpc(RunLocally = true)]
    protected virtual void SetOwnedColor(NetworkConnection conn, EVehicleColor col);
    public void ApplyColor(EVehicleColor col);
    public void ApplyOwnedColor();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void Park_Networked(NetworkConnection conn, ParkData parkData);
    public void Park(NetworkConnection conn, ParkData parkData, bool network);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void ExitPark_Networked(NetworkConnection conn, bool moveToExitPoint = true);
    public void ExitPark(bool moveToExitPoint = true);
    public void SetVisible(bool vis);
    public void RegisterPusher(PlayerPusher pusher);
    public void DeregisterPusher(PlayerPusher pusher);
    public List<ItemInstance> GetContents();
    public virtual VehicleData GetVehicleData();
    public string GetSaveString();
    private ItemSet GetContentsSet();
    public virtual void Load(VehicleData data, string containerPath);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_SetIsPlayerOwned_214505783(NetworkConnection conn, bool playerOwned);
    public void RpcLogic___SetIsPlayerOwned_214505783(NetworkConnection conn, bool playerOwned);
    private void RpcReader___Observers_SetIsPlayerOwned_214505783(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetIsPlayerOwned_214505783(NetworkConnection conn, bool playerOwned);
    private void RpcReader___Target_SetIsPlayerOwned_214505783(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetOwner_328543758(NetworkConnection conn);
    protected virtual void RpcLogic___SetOwner_328543758(NetworkConnection conn);
    private void RpcReader___Server_SetOwner_328543758(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_OnOwnerChanged_2166136261();
    protected virtual void RpcLogic___OnOwnerChanged_2166136261();
    private void RpcReader___Observers_OnOwnerChanged_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetTransform_Server_3848837105(Vector3 pos, Quaternion rot);
    public void RpcLogic___SetTransform_Server_3848837105(Vector3 pos, Quaternion rot);
    private void RpcReader___Server_SetTransform_Server_3848837105(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetTransform_3848837105(Vector3 pos, Quaternion rot);
    public void RpcLogic___SetTransform_3848837105(Vector3 pos, Quaternion rot);
    private void RpcReader___Observers_SetTransform_3848837105(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetSteeringAngle_431000436(float sa);
    private void RpcLogic___SetSteeringAngle_431000436(float sa);
    private void RpcReader___Server_SetSteeringAngle_431000436(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetSeatOccupant_3428404692(NetworkConnection conn, int seatIndex, NetworkConnection occupant);
    private void RpcLogic___SetSeatOccupant_3428404692(NetworkConnection conn, int seatIndex, NetworkConnection occupant);
    private void RpcReader___Observers_SetSeatOccupant_3428404692(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetSeatOccupant_3428404692(NetworkConnection conn, int seatIndex, NetworkConnection occupant);
    private void RpcReader___Target_SetSeatOccupant_3428404692(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetSeatOccupant_Server_3266232555(int seatIndex, NetworkConnection conn);
    private void RpcLogic___SetSeatOccupant_Server_3266232555(int seatIndex, NetworkConnection conn);
    private void RpcReader___Server_SetSeatOccupant_Server_3266232555(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SendOwnedColor_911055161(EVehicleColor col);
    public void RpcLogic___SendOwnedColor_911055161(EVehicleColor col);
    private void RpcReader___Server_SendOwnedColor_911055161(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Target_SetOwnedColor_1679996372(NetworkConnection conn, EVehicleColor col);
    protected virtual void RpcLogic___SetOwnedColor_1679996372(NetworkConnection conn, EVehicleColor col);
    private void RpcReader___Target_SetOwnedColor_1679996372(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetOwnedColor_1679996372(NetworkConnection conn, EVehicleColor col);
    private void RpcReader___Observers_SetOwnedColor_1679996372(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_Park_Networked_2633993806(NetworkConnection conn, ParkData parkData);
    private void RpcLogic___Park_Networked_2633993806(NetworkConnection conn, ParkData parkData);
    private void RpcReader___Observers_Park_Networked_2633993806(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Park_Networked_2633993806(NetworkConnection conn, ParkData parkData);
    private void RpcReader___Target_Park_Networked_2633993806(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ExitPark_Networked_214505783(NetworkConnection conn, bool moveToExitPoint = true);
    public void RpcLogic___ExitPark_Networked_214505783(NetworkConnection conn, bool moveToExitPoint = true);
    private void RpcReader___Observers_ExitPark_Networked_214505783(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_ExitPark_Networked_214505783(NetworkConnection conn, bool moveToExitPoint = true);
    private void RpcReader___Target_ExitPark_Networked_214505783(PooledReader PooledReader0, Channel channel);
    public override bool ReadSyncVar___ScheduleOne_002EVehicles_002ELandVehicle(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected virtual void Awake_UserLogic_ScheduleOne_002EVehicles_002ELandVehicle_Assembly_002DCSharp_002Edll();
}