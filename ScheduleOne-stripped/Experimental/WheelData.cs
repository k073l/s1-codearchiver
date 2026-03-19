using UnityEngine;

namespace ScheduleOne.Experimental;
[CreateAssetMenu(fileName = "WheelData", menuName = "ScriptableObjects/Vehicle/Wheel Data")]
public class WheelData : ScriptableObject
{
    public VehicleSettings Settings;
}