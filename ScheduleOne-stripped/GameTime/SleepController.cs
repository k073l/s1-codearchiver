using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FishNet;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using ScheduleOne.UI;
using ScheduleOne.UI.SleepMessage;
using ScheduleOne.Variables;
using UnityEngine;

namespace ScheduleOne.GameTime;
public class SleepController : NetworkSingleton<SleepController>
{
    public enum EPhase
    {
        None,
        Starting,
        RunningSleepEvents,
        WaitingForHost
    }

    public const int WakeTime;
    private const float SleepEventSpacing;
    [Header("References")]
    [SerializeField]
    private MonoStateMachine _sleepingState;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    [HideInInspector]
    public bool _003CIsHostReadyToProceed_003Ek__BackingField;
    private List<ISleepEvent> sleepEventQueue;
    private List<ISleepEvent> postSleepEventQueue;
    public SyncVar<bool> syncVar____003CIsHostReadyToProceed_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EGameTime_002ESleepControllerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EGameTime_002ESleepControllerAssembly_002DCSharp_002Edll_Excuted;
    public MonoStateMachine SleepingState => _sleepingState;
    public EPhase CurrentPhase { get; private set; }
    public bool IsSleepInProgress => CurrentPhase != EPhase.None;
    private bool IsHostReadyToProceed {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public bool SyncAccessor__003CIsHostReadyToProceed_003Ek__BackingField { get; set; }

    public event Action OnSleepStart;
    public event Action OnSleepEnd;
    public event Action OnPostSleepEventsComplete;
    public override void Awake();
    private void Update();
    private void CheckSleepStart();
    [ObserversRpc(RunLocally = true)]
    public void StartSleep();
    public void AddSleepEvent(ISleepEvent sleepEvent);
    public void AddPostSleepEvent(ISleepEvent sleepEvent);
    private IEnumerator RunSleepEvents(List<ISleepEvent> events);
    private int GetWakeTime();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_StartSleep_2166136261();
    public void RpcLogic___StartSleep_2166136261();
    private void RpcReader___Observers_StartSleep_2166136261(PooledReader PooledReader0, Channel channel);
    public override bool ReadSyncVar___ScheduleOne_002EGameTime_002ESleepController(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002EGameTime_002ESleepController_Assembly_002DCSharp_002Edll();
}