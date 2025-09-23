using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Vehicles;
public class VehicleSeat : MonoBehaviour
{
    public bool isDriverSeat;
    public Player Occupant;
    public bool isOccupied => (Object)(object)Occupant != (Object)null;
}