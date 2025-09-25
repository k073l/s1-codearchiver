using System.Collections.Generic;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Doors;
[RequireComponent(typeof(Rigidbody))]
public class DoorSensor : MonoBehaviour
{
    public const float ActivationDistance;
    public EDoorSide DetectorSide;
    public DoorController Door;
    private Collider collider;
    private List<Collider> exclude;
    private List<NPC> npcsInContact;
    private List<Player> playersInContact;
    private void Awake();
    private void UpdateCollider();
    private void OnTriggerEnter(Collider other);
    private void OnTriggerExit(Collider other);
    private void FixedUpdate();
}