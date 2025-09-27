using ScheduleOne.DevUtilities;
using ScheduleOne.Vehicles;
using UnityEngine;

namespace ScheduleOne.Map;
public class Dealership : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public void SpawnVehicle(string vehicleCode);
}