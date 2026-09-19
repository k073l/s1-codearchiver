using System;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Connection;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.NPCs;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers;
public class SpecialCustomerActivities : MonoBehaviour
{
    [Header("Acivities")]
    [SerializeField]
    protected List<SpecialCustomerActivity> _activities;
    [Header("Settings")]
    [SerializeField]
    protected int _activityReassignCycleTime;
    protected List<SpecialCustomer> _specialCustomers;
    protected int _timeUntilNextActivityReassign;
    protected IActivityHandler _activityHandler;
    protected Dictionary<string, List<SpecialCustomer>> _npcsToReassign;
    public void ValidateActivities();
    public void Initialise(IActivityHandler activityHandler);
    private void OnDestroy();
    public void AssignCustomers(List<SpecialCustomer> specialCustomers);
    private void AssignAcivities(List<SpecialCustomer> specialCustomers, int activityMinParticipantRequirement = 1, List<string> activitiesToExclude = null);
    public void Run();
    public void Stop();
    public SpecialCustomerActivity GetActivity(string name);
    public void ReassignCustomer(SpecialCustomer customer);
    public void ReassignNPCs(List<SpecialCustomer> specialCustomers, string previousActivity);
    private void OnUncappedMinPass();
    private void UpdatePriorities();
    private SpecialCustomerActivity GetRandomActivity(List<string> excludedActivities);
    public void OnClientJoin(NetworkConnection connection);
}