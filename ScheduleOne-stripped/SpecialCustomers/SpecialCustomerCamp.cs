using System;
using System.Collections.Generic;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Props;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.SpecialCustomers;
[RequireComponent(typeof(NetworkObject))]
public class SpecialCustomerCamp : NetworkBehaviour
{
    [Header("Components")]
    [SerializeField]
    private SpecialCustomerCutscene _cutscene;
    [SerializeField]
    private SpecialCustomerActivities _activities;
    [Header("Container")]
    [SerializeField]
    private Transform _container;
    [Header("Locations")]
    [SerializeField]
    private Transform _leaderLocation;
    [SerializeField]
    private Transform _npcSpawnPoint;
    [Header("Monitored Props")]
    [SerializeField]
    private float _monitorRange;
    [Tooltip("Props that required monitoring to be reset / repositioned when players no longer around. Must implement IProp to be considered")]
    [SerializeField]
    private List<GameObject> _monitoredPropObjs;
    [Header("Events")]
    [SerializeField]
    protected UnityEvent _onInitialArrival;
    [Header("Debugging and Development")]
    [SerializeField]
    private bool _showGizmos;
    private string _id;
    private List<IProp> _monitoredProps;
    private bool _withinCampRange;
    private bool _isActive;
    private bool NetworkInitialize___EarlyScheduleOne_002ESpecialCustomers_002ESpecialCustomerCampAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ESpecialCustomers_002ESpecialCustomerCampAssembly_002DCSharp_002Edll_Excuted;
    public string Id => _id;
    public Transform LeaderLocation => _leaderLocation;
    public Transform NpcSpawnPoint => _npcSpawnPoint;
    public Transform Container => _container;
    public SpecialCustomerCutscene Cutscene => _cutscene;
    public SpecialCustomerActivities Activities => _activities;

    public void Start();
    private void OnDestroy();
    public void ValidateCamp();
    public void SetId(string id);
    public void SetActive(bool active);
    public virtual void NotifyInitialArrival();
    private void CheckMonitoredProps();
    private void ResetMonitoredProps();
    public void OnDrawGizmos();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}