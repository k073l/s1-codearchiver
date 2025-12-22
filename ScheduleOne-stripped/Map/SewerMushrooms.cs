using System;
using System.Collections.Generic;
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
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Map;
public class SewerMushrooms : NetworkBehaviour
{
    [Serializable]
    public class SewerMushroomSpawnSettings
    {
        public int MaxSpawnAmount;
        [Range(0f, 1f)]
        public float RespawnAmountPerdayAsPercentage;
    }

    [Header("Mushroom Spawning")]
    public ItemPickup MushroomObjectPrefab;
    public SewerMushroomSpawnSettings MushroomSpawnSettings;
    public List<Transform> MushroomAreas;
    public List<Transform> MushroomLocations;
    [Header("Development & Debugging")]
    [SerializeField]
    private bool _debugMode;
    [SyncObject]
    private readonly SyncList<int> _activeMushroomLocationIndices;
    private Dictionary<int, ItemPickup> _spawnedMushroomItems;
    private List<int> _availableMushroomSpawnLocationIndices;
    private List<int> _mushroomSpawnLocationAmountPerArea;
    private int _lastMushroomSpanwnLocationIndex;
    private bool NetworkInitialize___EarlyScheduleOne_002EMap_002ESewerMushroomsAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EMap_002ESewerMushroomsAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    public override void OnStartServer();
    private void SetupEvents();
    private void MushroomIndicesChanged(SyncListOperation op, int index, int oldItem, int newItem, bool asServer);
    private void SpawnMushroom(int locationIndex);
    private void DespawnMushroom(int locationIndex);
    [ServerRpc]
    private void SetMushroomSpawnLocationAvailable(int locationIndex);
    private void RegenerateMushrooms();
    public void Load(SewerData sewerData);
    public List<int> GetActiveMushroomLocationIndices();
    private int GetNextSpawnLocation();
    private bool AreLocationsInSameArea(int locationIndexA, int locationIndexB);
    private bool CanSpawnMushroom();
    private int GetLocationIndex(int index);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetMushroomSpawnLocationAvailable_3316948804(int locationIndex);
    private void RpcLogic___SetMushroomSpawnLocationAvailable_3316948804(int locationIndex);
    private void RpcReader___Server_SetMushroomSpawnLocationAvailable_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void Awake_UserLogic_ScheduleOne_002EMap_002ESewerMushrooms_Assembly_002DCSharp_002Edll();
}