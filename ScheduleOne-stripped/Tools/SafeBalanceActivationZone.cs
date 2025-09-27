using System.Collections.Generic;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Storage;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Tools;
public class SafeBalanceActivationZone : MonoBehaviour
{
    public const float ActivationDistance;
    public Safe Safe;
    private List<Collider> exclude;
    private Collider[] colliders;
    private bool active;
    private void Awake();
    private void UpdateCollider();
    private void Activate();
    private void OnTriggerStay(Collider other);
}