using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Object;
using ScheduleOne.Doors;
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
    [Header("References")]
    public Transform SpawnPoint;
    public Transform[] VehicleSpawnPoints;
    public Transform[] PossessedVehicleSpawnPoints;
    public ParkingLot PoliceVehicleParkingLot;
    public LandVehicle[] PoliceVehicles;
    private List<LandVehicle> deployedVehicles;
    public List<PoliceOfficer> OfficerPool { get; private set; } = new List<PoliceOfficer>();
    public float TimeSinceLastDispatch { get; private set; }
    public int AvailableVehicleCount => PoliceVehicles.Length - deployedVehicleCount;
    private int deployedVehicleCount => deployedVehicles.Where(default).Count();

    protected override void Awake();
    private void OnDestroy();
    private void Update();
    public void Dispatch(int requestedOfficerCount, Player targetPlayer, EDispatchType type = EDispatchType.Auto, bool beginAsSighted = false);
    public PoliceOfficer PullOfficer();
    public LandVehicle DeployVehicle();
    public bool TryDeployVehicle(out LandVehicle vehicle, Transform spawnPoint);
    public void ReturnVehicle(LandVehicle vehicle);
    public override void NPCEnteredBuilding(NPC npc, StaticDoor door);
    public override void NPCExitedBuilding(NPC npc, StaticDoor door);
    public static PoliceStation GetClosestPoliceStation(Vector3 point);
}