using System.Collections;
using System.Collections.Generic;
using FishNet;
using Pathfinding;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.Vehicles;
using UnityEngine;

namespace ScheduleOne.Map;
public class WaterCollider : MonoBehaviour
{
    private bool localPlayerBeingWarped;
    private List<LandVehicle> warpedVehicles;
    public AudioSourceController SplashSound;
    public Transform OverrideWarpPoint;
    private void OnTriggerEnter(Collider other);
    private IEnumerator WarpPlayer();
    private IEnumerator WarpVehicle(LandVehicle veh);
}