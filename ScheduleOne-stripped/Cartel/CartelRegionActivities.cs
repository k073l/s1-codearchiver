using System;
using System.Collections.Generic;
using EasyButtons;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using GameKit.Utilities;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.GameTime;
using ScheduleOne.Map;
using ScheduleOne.Persistence;
using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.Cartel;
public class CartelRegionActivities : NetworkBehaviour
{
    public const int MIN_COOLDOWN;
    public const int MAX_COOLDOWN;
    public bool TEST_MODE;
    [Header("Settings")]
    public bool Active;
    public EMapRegion Region;
    public List<CartelActivity> Activities;
    [Header("References")]
    public CartelAmbushLocation[] AmbushLocations;
    public CartelDealer CartelDealer;
    [Header("Development & Debugging")]
    public int _debugActivityIndex;
    private bool NetworkInitialize___EarlyScheduleOne_002ECartel_002ECartelRegionActivitiesAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ECartel_002ECartelRegionActivitiesAssembly_002DCSharp_002Edll_Excuted;
    public CartelActivity CurrentActivity { get; private set; }
    public int HoursUntilNextActivity { get; set; } = 12;

    protected override void OnValidate();
    private void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    public void HourPass();
    private void TryStartActivity();
    [Button]
    public void StartActivity();
    private void StartAcivity(int activityIndex);
    [Button]
    public void ActivateDeal();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void StartActivity(NetworkConnection conn, int activityIndex);
    private void ActivityEnded();
    public CartelRegionalActivityData GetData();
    public void Load(CartelRegionalActivityData data);
    public static int GetNewCooldown(EMapRegion region);
    private void CartelStatusChange(ECartelStatus oldStatus, ECartelStatus newStatus);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_StartActivity_2681120339(NetworkConnection conn, int activityIndex);
    private void RpcLogic___StartActivity_2681120339(NetworkConnection conn, int activityIndex);
    private void RpcReader___Observers_StartActivity_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_StartActivity_2681120339(NetworkConnection conn, int activityIndex);
    private void RpcReader___Target_StartActivity_2681120339(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}