using System.Collections.Generic;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Tools;
public class OnlineBalanceActivationZone : MonoBehaviour
{
    public const float ActivationDistance;
    private List<Collider> exclude;
    private Collider collider;
    private void Awake();
    private void UpdateCollider();
    private void OnTriggerStay(Collider other);
}