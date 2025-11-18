using System;
using UnityEngine;

namespace ScheduleOne.Vehicles;
public class VehicleFX : MonoBehaviour
{
    public ParticleSystem[] exhaustFX;
    protected virtual void Awake();
    public virtual void OnVehicleStart();
    public virtual void OnVehicleStop();
}