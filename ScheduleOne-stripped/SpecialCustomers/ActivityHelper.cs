using System.Collections.Generic;
using ScheduleOne.Core;
using ScheduleOne.NPCs;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers;
public class ActivityHelper : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private SpecialCustomerActivity _activity;
    [SerializeField]
    private SpecialCustomerActivities _activities;
    [Header("NPCs")]
    [SerializeField]
    private List<SpecialCustomer> _npcs;
    [Button]
    public void StartActivity();
    [Button]
    public void StopAndReassign();
}