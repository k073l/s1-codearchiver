using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Vehicles;
public class VehicleHumanoidCollider : MonoBehaviour
{
    public LandVehicle Vehicle { get; set; }

    private void Start();
    private void LateUpdate();
    private void OnCollisionStay(Collision collision);
}