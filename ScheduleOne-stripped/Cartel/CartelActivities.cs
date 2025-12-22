using System;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using GameKit.Utilities;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Map;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Cartel;
public class CartelActivities : NetworkBehaviour
{
    public const int MAX_COOLDOWN_HOURS;
    public const int MIN_COOLDOWN_HOURS;
    [Header("References")]
    public List<CartelActivity> GlobalActivities;
    public CartelRegionActivities[] RegionalActivities;
    private bool NetworkInitialize___EarlyScheduleOne_002ECartel_002ECartelActivitiesAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ECartel_002ECartelActivitiesAssembly_002DCSharp_002Edll_Excuted;
    public CartelActivity CurrentGlobalActivity { get; private set; }
    public int HoursUntilNextGlobalActivity { get; set; } = 12;

    private void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    public CartelRegionActivities GetRegionalActivities(EMapRegion region);
    private void HourPass();
    private void TryStartActivity();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void StartGlobalActivity(NetworkConnection conn, EMapRegion region, int activityIndex);
    private void ActivityEnded();
    private bool CanNewActivityBegin();
    private List<CartelActivity> GetActivitiesReadyToStart();
    private List<EMapRegion> GetValidRegionsForActivity();
    public static int GetNewCooldown();
    private static float GetInfluenceFraction();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_StartGlobalActivity_1796582335(NetworkConnection conn, EMapRegion region, int activityIndex);
    private void RpcLogic___StartGlobalActivity_1796582335(NetworkConnection conn, EMapRegion region, int activityIndex);
    private void RpcReader___Observers_StartGlobalActivity_1796582335(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_StartGlobalActivity_1796582335(NetworkConnection conn, EMapRegion region, int activityIndex);
    private void RpcReader___Target_StartGlobalActivity_1796582335(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}