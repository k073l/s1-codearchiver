using ScheduleOne.Vehicles;
using UnityEngine;

namespace ScheduleOne.Map;
public class ParkingSpot : MonoBehaviour
{
    public Transform AlignmentPoint;
    public EParkingAlignment Alignment;
    private ParkingLot _parentParentLot;
    private bool _isUsable;
    public LandVehicle OccupantVehicle { get; protected set; }
    public bool IsUsable => _isUsable;

    private void Awake();
    private void Init();
    public void SetOccupant(LandVehicle vehicle);
    public void SetIsUsable(bool isUsable);
}