using System;
using System.Collections.Generic;
using FishNet;
using FishNet.Component.Transforming;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.Growing;
[RequireComponent(typeof(NetworkTransform))]
public class ShroomColony : NetworkBehaviour
{
    public const float MaxTemperatureForGrowth;
    private const float MinSoilMoistureForGrowth;
    private const float RandomRotationRange;
    private const float RandomVerticalShift;
    [SerializeField]
    private ShroomSpawnDefinition _spawnDefinition;
    [SerializeField]
    private int _growTime;
    [SerializeField]
    private Transform[] _shroomAlignments;
    [SerializeField]
    private GrowingMushroom[] _growingShroomPrefabs;
    [SerializeField]
    private AudioSourceController _snipSound;
    [SerializeField]
    private ParticleSystem _fullyGrownParticles;
    public Action onFullyHarvested;
    private List<GrowingMushroom> _growingShrooms;
    private Dictionary<GrowingMushroom, int> _growingShroomPositions;
    private List<int> _takenAlignmentIndices;
    private MushroomBed _parentBed;
    private bool _shroomsInitiallySpawned;
    private bool NetworkInitialize___EarlyScheduleOne_002EGrowing_002EShroomColonyAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EGrowing_002EShroomColonyAssembly_002DCSharp_002Edll_Excuted;
    [field: SerializeField]
    public int BaseShroomYield { get; private set; } = 12;
    public float GrowthProgress { get; private set; }
    public bool IsFullyGrown => GrowthProgress >= 1f;
    public bool IsTooHotToGrow { get; }
    public int GrownMushroomCount => _growingShrooms.Count;
    public AudioSourceController SnipSound => _snipSound;
    public float NormalizedQuality { get; private set; } = 0.5f;

    public override void OnSpawnServer(NetworkConnection connection);
    public override void OnStartClient();
    private void OnDestroy();
    private void OnMinPass();
    private void OnTimeSkipped(int mins);
    public void SetColonyVisible(bool visible);
    private float GetCurrentGrowthRate();
    private void ChangeGrowthPercentage(float change);
    [ServerRpc(RequireOwnership = false)]
    public void SetFullyGrown();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetGrowthPercentage_Local(NetworkConnection conn, float percent);
    private void SetGrowthPercentage(float percent);
    private void ChangeQuality(float change);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void AddShroomAtPosition_Server(int alignmentIndex);
    [ObserversRpc(RunLocally = true)]
    private void AddShroomAtPosition_Local(int alignmentIndex);
    private void AddShroomAtPosition(int alignmentIndex);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void RemoveShroom_Server(int alignmentIndex);
    public void RemoveRandomShroom();
    [ObserversRpc(RunLocally = true)]
    private void RemoveShoom_Client(int alignmentIndex);
    private void RemoveShroom(int alignmentIndex);
    private void RemoveShroom(GrowingMushroom shroom);
    public void SetFullyHarvested();
    private int GetRandomAvailableAlignmentIndex();
    public ShroomInstance GetHarvestedShroom(int quantity = 1);
    public void AdditiveApplied(AdditiveDefinition additive, bool isInitialApplication);
    [TargetRpc]
    public void SetColonyState(NetworkConnection conn, int[] _activeMushroomIndices, float growthProgress, float quality);
    public ShroomColonyData GetSaveData();
    public void Load(ShroomColonyData data);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetFullyGrown_2166136261();
    public void RpcLogic___SetFullyGrown_2166136261();
    private void RpcReader___Server_SetFullyGrown_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetGrowthPercentage_Local_530160725(NetworkConnection conn, float percent);
    private void RpcLogic___SetGrowthPercentage_Local_530160725(NetworkConnection conn, float percent);
    private void RpcReader___Observers_SetGrowthPercentage_Local_530160725(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetGrowthPercentage_Local_530160725(NetworkConnection conn, float percent);
    private void RpcReader___Target_SetGrowthPercentage_Local_530160725(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_AddShroomAtPosition_Server_3316948804(int alignmentIndex);
    public void RpcLogic___AddShroomAtPosition_Server_3316948804(int alignmentIndex);
    private void RpcReader___Server_AddShroomAtPosition_Server_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_AddShroomAtPosition_Local_3316948804(int alignmentIndex);
    private void RpcLogic___AddShroomAtPosition_Local_3316948804(int alignmentIndex);
    private void RpcReader___Observers_AddShroomAtPosition_Local_3316948804(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_RemoveShroom_Server_3316948804(int alignmentIndex);
    public void RpcLogic___RemoveShroom_Server_3316948804(int alignmentIndex);
    private void RpcReader___Server_RemoveShroom_Server_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_RemoveShoom_Client_3316948804(int alignmentIndex);
    private void RpcLogic___RemoveShoom_Client_3316948804(int alignmentIndex);
    private void RpcReader___Observers_RemoveShoom_Client_3316948804(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetColonyState_4288818029(NetworkConnection conn, int[] _activeMushroomIndices, float growthProgress, float quality);
    public void RpcLogic___SetColonyState_4288818029(NetworkConnection conn, int[] _activeMushroomIndices, float growthProgress, float quality);
    private void RpcReader___Target_SetColonyState_4288818029(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}