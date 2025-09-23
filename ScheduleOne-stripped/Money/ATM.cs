using System;
using System.Collections;
using EasyButtons;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.UI.ATM;
using ScheduleOne.Vision;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace ScheduleOne.Money;
public class ATM : NetworkBehaviour, IGUIDRegisterable, IGenericSaveable
{
    public const bool DepositLimitEnabled;
    public const float WEEKLY_DEPOSIT_LIMIT;
    public const float IMPACT_THRESHOLD_BREAK;
    public const int REPAIR_TIME_DAYS;
    public const int MIN_CASH_DROP;
    public const int MAX_CASH_DROP;
    public static float WeeklyDepositSum;
    public CashPickup CashPrefab;
    [Header("References")]
    [SerializeField]
    protected InteractableObject intObj;
    [SerializeField]
    protected Transform camPos;
    [SerializeField]
    protected ATMInterface interfaceATM;
    public Transform AccessPoint;
    public Transform CashSpawnPoint;
    public PhysicsDamageable Damageable;
    [Header("Settings")]
    public static float viewLerpTime;
    [SerializeField]
    protected string BakedGUID;
    public UnityEvent onBreak;
    public UnityEvent onRepair;
    private bool NetworkInitialize___EarlyScheduleOne_002EMoney_002EATMAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EMoney_002EATMAssembly_002DCSharp_002Edll_Excuted;
    public bool IsBroken { get; protected set; }
    public int DaysUntilRepair { get; protected set; }
    public bool isInUse { get; protected set; }
    public Guid GUID { get; protected set; }

    [Button]
    public void RegenerateGUID();
    public override void Awake();
    protected virtual void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    public void SetGUID(Guid guid);
    public void DayPass();
    public void WeekPass();
    public void Hovered();
    public void Interacted();
    public void Enter();
    public void Exit();
    private void Impacted(Impact impact);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    private void SendBreak();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void Break(NetworkConnection conn);
    [ObserversRpc]
    private void Repair();
    [ServerRpc(RequireOwnership = false)]
    private void DropCash();
    public void Load(GenericSaveData data);
    public GenericSaveData GetSaveData();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SendBreak_2166136261();
    private void RpcLogic___SendBreak_2166136261();
    private void RpcReader___Server_SendBreak_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_Break_328543758(NetworkConnection conn);
    private void RpcLogic___Break_328543758(NetworkConnection conn);
    private void RpcReader___Observers_Break_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Break_328543758(NetworkConnection conn);
    private void RpcReader___Target_Break_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_Repair_2166136261();
    private void RpcLogic___Repair_2166136261();
    private void RpcReader___Observers_Repair_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_DropCash_2166136261();
    private void RpcLogic___DropCash_2166136261();
    private void RpcReader___Server_DropCash_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void Awake_UserLogic_ScheduleOne_002EMoney_002EATM_Assembly_002DCSharp_002Edll();
}