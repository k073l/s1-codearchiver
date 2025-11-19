using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.Networking;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.GameTime;
public class TimeManager : NetworkSingleton<TimeManager>, IBaseSaveable, ISaveable
{
    public const float CYCLE_DURATION_MINS;
    public const float MINUTE_TIME;
    public const int DEFAULT_WAKE_TIME;
    public const int END_OF_DAY;
    public int DefaultTime;
    public EDay DefaultDay;
    public float TimeProgressionMultiplier;
    private int savedTime;
    public ActionList onMinutePass;
    public Action onHourPass;
    public Action onDayPass;
    public Action onWeekPass;
    public Action onUpdate;
    public Action onFixedUpdate;
    public Action<int> onTimeSkip;
    public Action onTick;
    public Action onTimeChanged;
    public Action onSleepStart;
    public Action onSleepEnd;
    public UnityEvent onFirstNight;
    public const int SelectedWakeTime;
    private GameDateTime sleepStartTime;
    private int sleepEndTime;
    private float defaultFixedTimeScale;
    private TimeLoader loader;
    private bool NetworkInitialize___EarlyScheduleOne_002EGameTime_002ETimeManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EGameTime_002ETimeManagerAssembly_002DCSharp_002Edll_Excuted;
    public bool IsEndOfDay => CurrentTime == 400;
    public bool SleepInProgress { get; protected set; }
    public int ElapsedDays { get; protected set; }
    public int CurrentTime { get; protected set; }
    public float TimeOnCurrentMinute { get; protected set; }
    public int DailyMinTotal { get; protected set; }
    public bool IsNight { get; }
    public int DayIndex => ElapsedDays % 7;
    public float NormalizedTime => (float)DailyMinTotal / 1440f;
    public float Playtime { get; protected set; }
    public EDay CurrentDay => (EDay)DayIndex;
    public bool TimeOverridden { get; protected set; }
    public bool HostDailySummaryDone { get; private set; }
    public string SaveFolderName => "Time";
    public string SaveFileName => "Time";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder { get; }

    public override void Awake();
    public virtual void InitializeSaveable();
    public override void OnSpawnServer(NetworkConnection connection);
    public override void OnStartClient();
    private void Clean();
    public void SendTimeData(NetworkConnection connection);
    [ObserversRpc(RunLocally = true, ExcludeServer = true)]
    [TargetRpc]
    private void SetData(NetworkConnection conn, int _elapsedDays, int _time, float sendTime);
    protected virtual void Update();
    protected virtual void FixedUpdate();
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void ResetHostSleepDone();
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void MarkHostSleepDone();
    [ObserversRpc(RunLocally = true)]
    private void SetHostSleepDone(bool done);
    private IEnumerator TickLoop();
    private IEnumerator TimeLoop();
    private IEnumerator StaggeredMinPass(float staggerTime);
    private void PassMinute();
    private void Tick();
    public void SetTime(int _time, bool local = false);
    public void SetElapsedDays(int days);
    public static string Get12HourTime(float _time, bool appendDesignator = true);
    public static int Get24HourTimeFromMinSum(int minSum);
    public static int GetMinSumFrom24HourTime(int _time);
    public bool IsCurrentTimeWithinRange(int min, int max);
    public static bool IsGivenTimeWithinRange(int givenTime, int min, int max);
    public static bool IsValid24HourTime(string input);
    public bool IsCurrentDateWithinRange(GameDateTime start, GameDateTime end);
    [ObserversRpc]
    private void InvokeDayPassClientSide();
    [ObserversRpc]
    private void InvokeWeekPassClientSide();
    public void FastForwardToWakeTime();
    public GameDateTime GetDateTime();
    public int GetTotalMinSum();
    public static int AddMinutesTo24HourTime(int time, int minsToAdd);
    public static List<int> GetAllTimeInRange(int min, int max);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetWakeTime(int amount);
    public void ForceSleep();
    [ObserversRpc(RunLocally = true)]
    private void StartSleep();
    [ObserversRpc(RunLocally = true)]
    private void EndSleep();
    public virtual string GetSaveString();
    public void SetPlaytime(float time);
    public void SetTimeOverridden(bool overridden, int time = 1200);
    private void SetRandomTime();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_SetData_2661156041(NetworkConnection conn, int _elapsedDays, int _time, float sendTime);
    private void RpcLogic___SetData_2661156041(NetworkConnection conn, int _elapsedDays, int _time, float sendTime);
    private void RpcReader___Observers_SetData_2661156041(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetData_2661156041(NetworkConnection conn, int _elapsedDays, int _time, float sendTime);
    private void RpcReader___Target_SetData_2661156041(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ResetHostSleepDone_2166136261();
    public void RpcLogic___ResetHostSleepDone_2166136261();
    private void RpcReader___Server_ResetHostSleepDone_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_MarkHostSleepDone_2166136261();
    public void RpcLogic___MarkHostSleepDone_2166136261();
    private void RpcReader___Server_MarkHostSleepDone_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetHostSleepDone_1140765316(bool done);
    private void RpcLogic___SetHostSleepDone_1140765316(bool done);
    private void RpcReader___Observers_SetHostSleepDone_1140765316(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_InvokeDayPassClientSide_2166136261();
    private void RpcLogic___InvokeDayPassClientSide_2166136261();
    private void RpcReader___Observers_InvokeDayPassClientSide_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_InvokeWeekPassClientSide_2166136261();
    private void RpcLogic___InvokeWeekPassClientSide_2166136261();
    private void RpcReader___Observers_InvokeWeekPassClientSide_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetWakeTime_3316948804(int amount);
    public void RpcLogic___SetWakeTime_3316948804(int amount);
    private void RpcReader___Server_SetWakeTime_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_StartSleep_2166136261();
    private void RpcLogic___StartSleep_2166136261();
    private void RpcReader___Observers_StartSleep_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_EndSleep_2166136261();
    private void RpcLogic___EndSleep_2166136261();
    private void RpcReader___Observers_EndSleep_2166136261(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002EGameTime_002ETimeManager_Assembly_002DCSharp_002Edll();
}