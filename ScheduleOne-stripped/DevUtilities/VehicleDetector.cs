using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.GameTime;
using ScheduleOne.Vehicles;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
[RequireComponent(typeof(Rigidbody))]
public class VehicleDetector : MonoBehaviour
{
    public const float ACTIVATION_DISTANCE_SQ;
    public List<LandVehicle> vehicles;
    public LandVehicle closestVehicle;
    private bool ignoreExit;
    private Collider[] detectionColliders;
    private bool collidersEnabled;
    public bool IgnoreNewDetections { get; protected set; }

    private void Awake();
    private void Start();
    private void OnDestroy();
    private void OnTriggerEnter(Collider other);
    private void OnTick();
    private void OnTriggerExit(Collider other);
    private void SortVehicles();
    public void SetIgnoreNewCollisions(bool ignore);
    public bool AreAnyVehiclesOccupied();
    public void Clear();
}