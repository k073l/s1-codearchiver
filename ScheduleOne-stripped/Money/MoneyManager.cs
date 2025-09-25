using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.Money;
public class MoneyManager : NetworkSingleton<MoneyManager>, IBaseSaveable, ISaveable
{
    public class FloatContainer
    {
        public float value { get; private set; }

        public void ChangeValue(float value);
    }

    public const string MONEY_TEXT_COLOR;
    public const string MONEY_TEXT_COLOR_DARKER;
    public const string ONLINE_BALANCE_COLOR;
    public List<Transaction> ledger;
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public float onlineBalance;
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public float lifetimeEarnings;
    [SerializeField]
    protected AudioSourceController CashSound;
    [Header("Prefabs")]
    [SerializeField]
    protected GameObject moneyChangePrefab;
    [SerializeField]
    protected GameObject cashChangePrefab;
    public Sprite LaunderingNotificationIcon;
    public Action<FloatContainer> onNetworthCalculation;
    private MoneyLoader loader;
    public SyncVar<float> syncVar___onlineBalance;
    public SyncVar<float> syncVar___lifetimeEarnings;
    private bool NetworkInitialize___EarlyScheduleOne_002EMoney_002EMoneyManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EMoney_002EMoneyManagerAssembly_002DCSharp_002Edll_Excuted;
    public float LifetimeEarnings => SyncAccessor_lifetimeEarnings;
    public float LastCalculatedNetworth { get; protected set; }
    public float cashBalance => cashInstance.Balance;
    protected CashInstance cashInstance => PlayerSingleton<PlayerInventory>.Instance.cashInstance;
    public string SaveFolderName => "Money";
    public string SaveFileName => "Money";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder { get; }
    public float SyncAccessor_onlineBalance { get; set; }
    public float SyncAccessor_lifetimeEarnings { get; set; }

    public static string ApplyMoneyTextColor(string text);
    public static string ApplyMoneyTextColorDarker(string text);
    public static string ApplyOnlineBalanceColor(string text);
    public override void Awake();
    public virtual void InitializeSaveable();
    protected override void Start();
    public override void OnStartServer();
    public override void OnStartClient();
    protected override void OnDestroy();
    private void Loaded();
    private void Update();
    private void MinPass();
    public CashInstance GetCashInstance(float amount);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void CreateOnlineTransaction(string _transaction_Name, float _unit_Amount, float _quantity, string _transaction_Note);
    [ObserversRpc]
    private void ReceiveOnlineTransaction(string _transaction_Name, float _unit_Amount, float _quantity, string _transaction_Note);
    protected IEnumerator ShowOnlineBalanceChange(RectTransform changeDisplay);
    [ServerRpc(RequireOwnership = false)]
    public void ChangeLifetimeEarnings(float change);
    public void PlayCashSound();
    public void ChangeCashBalance(float change, bool visualizeChange = true, bool playCashSound = false);
    protected IEnumerator ShowCashChange(RectTransform changeDisplay);
    public static string FormatAmount(float amount, bool showDecimals = false, bool includeColor = false);
    public virtual string GetSaveString();
    public void Load(MoneyData data);
    public void CheckNetworthAchievements();
    public float GetNetWorth();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_CreateOnlineTransaction_1419830531(string _transaction_Name, float _unit_Amount, float _quantity, string _transaction_Note);
    public void RpcLogic___CreateOnlineTransaction_1419830531(string _transaction_Name, float _unit_Amount, float _quantity, string _transaction_Note);
    private void RpcReader___Server_CreateOnlineTransaction_1419830531(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ReceiveOnlineTransaction_1419830531(string _transaction_Name, float _unit_Amount, float _quantity, string _transaction_Note);
    private void RpcLogic___ReceiveOnlineTransaction_1419830531(string _transaction_Name, float _unit_Amount, float _quantity, string _transaction_Note);
    private void RpcReader___Observers_ReceiveOnlineTransaction_1419830531(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ChangeLifetimeEarnings_431000436(float change);
    public void RpcLogic___ChangeLifetimeEarnings_431000436(float change);
    private void RpcReader___Server_ChangeLifetimeEarnings_431000436(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override bool ReadSyncVar___ScheduleOne_002EMoney_002EMoneyManager(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002EMoney_002EMoneyManager_Assembly_002DCSharp_002Edll();
}