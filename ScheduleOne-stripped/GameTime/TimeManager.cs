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
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.GameTime;
public class TimeManager : NetworkSingleton<TimeManager>, IBaseSaveable, ISaveable
{
    private const float DefaultCycleDuration;
    public const float TickDuration;
    public const int EndOfDay;
    private static float CycleDuration;
    [SerializeField]
    private EDay _defaultDay;
    private float _lastMinWaitExcess;
    private bool _stopMinPassWait;
    private float _secondsOnCurrentMinute;
    private Coroutine _tickLoop;
    private Coroutine _timeLoop;
    public ActionList onMinutePass;
    public ActionList onUncappedMinutePass;
    public ActionList onTick;
    public Action onTimeChanged;
    public Action<int> onTimeSkip;
    public Action onTimeSet;
    public Action onHourPass;
    public Action onDayPass;
    public Action onWeekPass;
    public Action onUpdate;
    public Action onFixedUpdate;
    private TimeLoader loader;
    private bool NetworkInitialize___EarlyScheduleOne_002EGameTime_002ETimeManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EGameTime_002ETimeManagerAssembly_002DCSharp_002Edll_Excuted;
    public static float MinuteDuration => CycleDuration / 24f;

    [field: SerializeField]
    public int DefaultTime { get; private set; } = 900;
    public int CurrentTime { get; private set; }
    public EDay CurrentDay => (EDay)DayIndex;
    public int ElapsedDays { get; private set; }
    public bool IsEndOfDay => CurrentTime == 400;
    public bool IsNight { get; }
    public float NormalizedTimeOfDay => (Mathf.Clamp01(_secondsOnCurrentMinute / MinuteDuration) + (float)DailyMinSum) / 1440f;
    public int DayIndex => ElapsedDays % 7;
    public float Playtime { get; private set; }
    public float TimeSpeedMultiplier { get; private set; } = 1f;
    public int DailyMinSum { get; private set; }
    private float _minuteStaggerTime => MinuteDuration / (Time.timeScale * 0.9f);
    private float _tickStaggerTime => 0.45f;
    public string SaveFolderName => "Time";
    public string SaveFileName => "Time";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder { get; }

    public override void Awake();
    protected override void Start();
    public virtual void InitializeSaveable();
    public override void OnSpawnServer(NetworkConnection connection);
    public override void OnStartServer();
    public override void OnStartClient();
    private void Clean();
    [ObserversRpc(RunLocally = true, ExcludeServer = true)]
    [TargetRpc]
    private void SetTimeData_Client(NetworkConnection conn, int elapsedDays, int time, uint serverTick);
    protected virtual void Update();
    protected virtual void FixedUpdate();
    private IEnumerator TickLoop();
    private IEnumerator TimeLoop();
    private bool ShouldMinutePass();
    private void PassMinute();
    [ObserversRpc(RunLocally = true, ExcludeServer = true)]
    private void PassMinute_Client(int oldTime);
    public void SetTime_Server(int time);
    public void SkipToTimeAndSync(int newTime);
    [ObserversRpc(RunLocally = true)]
    private void OnTimeSkip_Client(int oldTime, int newTime);
    private void SetTime(int time);
    public bool IsCurrentTimeWithinRange(int min, int max);
    public bool IsCurrentDateWithinRange(GameDateTime start, GameDateTime end);
    public GameDateTime GetDateTime();
    public int GetTotalMinSum();
    public void SetTimeSpeedMultiplier(float multiplier);
    public void SetCycleDuration(float time);
    public static float Normalized24HourTime(int time);
    public static bool IsGivenTimeWithinRange(int givenTime, int min, int max);
    public static bool IsValid24HourTime(string input);
    public static bool IsValid24HourTime(int time);
    public static string Get12HourTime(float _time, bool appendDesignator = true);
    public static int Get24HourTimeFromMinSum(int minSum);
    public static int GetMinSumFrom24HourTime(int _time);
    public static string GetMinutesToDisplayTime(int minutes);
    public static int AddMinutesTo24HourTime(int time, int minsToAdd);
    public virtual string GetSaveString();
    public void Load(TimeData timeData);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_SetTimeData_Client_1794730778(NetworkConnection conn, int elapsedDays, int time, uint serverTick);
    private void RpcLogic___SetTimeData_Client_1794730778(NetworkConnection conn, int elapsedDays, int time, uint serverTick);
    private void RpcReader___Observers_SetTimeData_Client_1794730778(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetTimeData_Client_1794730778(NetworkConnection conn, int elapsedDays, int time, uint serverTick);
    private void RpcReader___Target_SetTimeData_Client_1794730778(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_PassMinute_Client_3316948804(int oldTime);
    private void RpcLogic___PassMinute_Client_3316948804(int oldTime);
    private void RpcReader___Observers_PassMinute_Client_3316948804(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_OnTimeSkip_Client_1692629761(int oldTime, int newTime);
    private void RpcLogic___OnTimeSkip_Client_1692629761(int oldTime, int newTime);
    private void RpcReader___Observers_OnTimeSkip_Client_1692629761(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002EGameTime_002ETimeManager_Assembly_002DCSharp_002Edll();
}