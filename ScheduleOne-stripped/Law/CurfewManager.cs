using System;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Law;
public class CurfewManager : NetworkSingleton<CurfewManager>
{
    private const string NORMAL_MESSAGE;
    private const string CURFEW_MESSAGE;
    private const string WARNING_MESSAGE;
    public const int HOUR_BEFORE_CURFEW;
    public const int WARNING_TIME;
    public const int CURFEW_START_TIME;
    public const int HARD_CURFEW_START_TIME;
    public const int CURFEW_END_TIME;
    [Header("References")]
    public VMSBoard[] VMSBoards;
    public AudioSourceController CurfewWarningSound;
    public AudioSourceController CurfewAlarmSound;
    public UnityEvent onCurfewEnabled;
    public UnityEvent onCurfewDisabled;
    public UnityEvent onCurfewHint;
    public UnityEvent onCurfewWarning;
    public UnityEvent onCurfewStart;
    public UnityEvent onCurfewHardStart;
    public UnityEvent onCurfewEnd;
    private bool NetworkInitialize___EarlyScheduleOne_002ELaw_002ECurfewManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ELaw_002ECurfewManagerAssembly_002DCSharp_002Edll_Excuted;
    public bool IsEnabled { get; protected set; }
    public bool IsCurrentlyActive { get; protected set; }
    public bool IsHardCurfewActive { get; protected set; }

    protected override void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    [ObserversRpc]
    [TargetRpc]
    public void Enable(NetworkConnection conn);
    [ObserversRpc]
    public void Disable();
    private void MinPass();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_Enable_328543758(NetworkConnection conn);
    public void RpcLogic___Enable_328543758(NetworkConnection conn);
    private void RpcReader___Observers_Enable_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Enable_328543758(NetworkConnection conn);
    private void RpcReader___Target_Enable_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_Disable_2166136261();
    public void RpcLogic___Disable_2166136261();
    private void RpcReader___Observers_Disable_2166136261(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}