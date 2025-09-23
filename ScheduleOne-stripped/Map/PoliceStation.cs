using System;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.Law;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Police;
using ScheduleOne.Vehicles;
using UnityEngine;

namespace ScheduleOne.Map;
public class PoliceStation : NPCEnterableBuilding
{
    public enum EDispatchType
    {
        Auto,
        UseVehicle,
        OnFoot
    }

    public static List<PoliceStation> PoliceStations;
    public int VehicleLimit;
    [Header("References")]
    public Transform SpawnPoint;
    public Transform[] VehicleSpawnPoints;
    public Transform[] PossessedVehicleSpawnPoints;
    [Header("Prefabs")]
    public LandVehicle[] PoliceVehiclePrefabs;
    public List<PoliceOfficer> OfficerPool;
    [SerializeField]
    private List<LandVehicle> deployedVehicles;
    public float TimeSinceLastDispatch { get; private set; }
    private int deployedVehicleCount => deployedVehicles.Where(default).Count();

    protected override void Awake();
    private void OnDestroy();
    private void Update();
    private void CleanVehicleList();
    public void Dispatch(int requestedOfficerCount, Player targetPlayer, EDispatchType type = EDispatchType.Auto, bool beginAsSighted = false);
    public PoliceOfficer PullOfficer();
    public LandVehicle CreateVehicle();
    public override void NPCEnteredBuilding(NPC npc);
    public override void NPCExitedBuilding(NPC npc);
    public static PoliceStation GetClosestPoliceStation(Vector3 point);
}