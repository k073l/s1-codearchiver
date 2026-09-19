using System;
using System.Collections;
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
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.Effects;
using ScheduleOne.Events;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Levelling;
using ScheduleOne.Money;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.Product;
using ScheduleOne.UI.SleepMessage;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScheduleOne.SpecialCustomers;
public class SpecialCustomerManager : NetworkSingleton<SpecialCustomerManager>, IBaseSaveable, ISaveable, IActivityHandler
{
    private class SpecialCustomerEvent
    {
        public SpecialCustomerData CustomerGroup;
        public int ArrivalDay;
        public int DepartureDay;
    }

    private const int MaxSpecialCustomersInGroup;
    public const int WaitForArrivalDuration;
    private const int StayDuration;
    private const int DaysUntilNextEventMin;
    private const int DaysUntilNextEventMax;
    private const float ArrivalMessageDuration;
    private const int MaxDesiredEffects;
    private const int InitialPhaseWaitPeriod;
    private const float BonusPaymentPerDesiredEffectMultiplier;
    private const float ProductQualityPriceMultiplierBase;
    private const float ProductQualityPriceMultiplierPerTier;
    [Header("Customer Data")]
    [SerializeField]
    private List<SpecialCustomerData> _specialCustomerGroups;
    [Header("NPCs")]
    [SerializeField]
    private SpecialCustomer _standardPrefab;
    [SerializeField]
    private SpecialCustomerLeader _leaderPrefab;
    [Header("World Containers")]
    [SerializeField]
    private Transform _campContainer;
    [SerializeField]
    private Transform _npcContainer;
    [Header("References")]
    [SerializeField]
    private SpecialCustomerGroupPOI _campPoIPrefab;
    [SerializeField]
    [HideInInspector]
    private bool _debugMode;
    [SerializeField]
    [HideInInspector]
    private string _debugGroupId;
    [SerializeField]
    [HideInInspector]
    private SpecialCustomerPhase _debugPhase;
    [SerializeField]
    [HideInInspector]
    private int _debugDaysLeft;
    [SerializeField]
    private float penaltyPerVisit;
    [SerializeField]
    private float bonusPerDayUnseen;
    private SpecialCustomerSaveData _currentData;
    private SpecialCustomerCamp _currentCamp;
    private SpecialCustomerData _currentCustomerGroup;
    private SpecialCustomerLeader _leaderInstance;
    private List<SpecialCustomer> _customerInstances;
    private ObjectPool<SpecialCustomer> _customerPool;
    private List<Effect> _currentDesiredEffects;
    private bool _inPhaseTransition;
    private bool _forceGroupCleanUp;
    private bool NetworkInitialize___EarlyScheduleOne_002ESpecialCustomers_002ESpecialCustomerManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ESpecialCustomers_002ESpecialCustomerManagerAssembly_002DCSharp_002Edll_Excuted;
    public string SaveFolderName => "SpecialCustomers";
    public string SaveFileName => "SpecialCustomers";
    public Loader Loader => new SpecialCustomerLoader();
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder => 10;
    public Effect[] CurrentDesiredEffects => _currentDesiredEffects.ToArray();
    public SpecialCustomerData CurrentGroupData => _currentCustomerGroup;

    public event Action<string, SpecialCustomerPhase, int> OnPhaseUpdated;
    public event Action<string> OnGroupAdded;
    public event Action<string> OnGroupRemoved;
    public event BasicEvent<SpecialCustomerDealReceipt> OnDealCompleted;
    public static float GetDesiredEffectsPriceMultiplier(int desiredEffectCount);
    public static float GetProductQualityPriceMultiplier(EQuality itemQuality);
    public override void Awake();
    protected override void Start();
    public override void OnStartServer();
    public override void OnSpawnServer(NetworkConnection connection);
    private void SetVariables();
    private void SetEvents();
    [Server]
    private SpecialCustomerCamp SpawnCamp(SpecialCustomerData groupData);
    [Server]
    private void DespawnCamp(SpecialCustomerCamp camp);
    private void SetNPCs();
    private void SetData(SpecialCustomerSaveData data);
    public SpecialCustomerData GetSpecialCustomerData(string groupId);
    [Server]
    private void UpdatePhase(int days);
    [Server]
    private void RunWaitingForArrivalPhase();
    [Server]
    private void RunArrivalPhase();
    [Server]
    private void RunInactivePhase();
    [Server]
    private void RemoveCustomerGroup();
    [Server]
    private void UpdateDesiredEffects();
    [ObserversRpc]
    private void NotifyPhaseUpdate_Client(string groupId, SpecialCustomerPhase phase, int daysLeft);
    [ObserversRpc]
    [TargetRpc]
    private void DetermineDesiredEffects_Client(NetworkConnection connection, string groupId, List<string> desiredEffectIds);
    [ObserversRpc]
    [TargetRpc]
    private void AddCustomerGroup_Client(NetworkConnection connection, string groupId, SpecialCustomerCamp camp, bool inPhaseTransition, SpecialCustomerLeader leader, List<SpecialCustomer> customers, int visitCount);
    [ObserversRpc]
    private void RemoveCustomerGroup_Client(NetworkConnection connection, string groupId, SpecialCustomerLeader leader, List<SpecialCustomer> customers);
    [ObserversRpc]
    public void DealCompleted_Client(SpecialCustomerDealReceipt dealRecipe);
    private string GetNextCustomerGroupOrdered();
    private SpecialCustomerPhase GetNextPhase(SpecialCustomerPhase currentPhase);
    public SpecialCustomerActivity GetActivity(string name);
    public void ReassignNPCs(List<SpecialCustomer> npcs, string previousActivity);
    public bool HasProduct();
    public ProductItemInstance GetProduct();
    public int GetProductQauntity();
    public void Load(SpecialCustomerSaveData data);
    public List<SpecialCustomer> GetCustomers();
    public void InitializeSaveable();
    public string GetSaveString();
    private void OnSleepStart();
    private void OnMinPassed();
    public void QueueCustomerGroup(string groupId);
    [Button]
    public void ClearCurrentBuyQuantity();
    [Button]
    public void SimulateSpecialCustomerEvents();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_NotifyPhaseUpdate_Client_3969061075(string groupId, SpecialCustomerPhase phase, int daysLeft);
    private void RpcLogic___NotifyPhaseUpdate_Client_3969061075(string groupId, SpecialCustomerPhase phase, int daysLeft);
    private void RpcReader___Observers_NotifyPhaseUpdate_Client_3969061075(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_DetermineDesiredEffects_Client_2045540826(NetworkConnection connection, string groupId, List<string> desiredEffectIds);
    private void RpcLogic___DetermineDesiredEffects_Client_2045540826(NetworkConnection connection, string groupId, List<string> desiredEffectIds);
    private void RpcReader___Observers_DetermineDesiredEffects_Client_2045540826(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_DetermineDesiredEffects_Client_2045540826(NetworkConnection connection, string groupId, List<string> desiredEffectIds);
    private void RpcReader___Target_DetermineDesiredEffects_Client_2045540826(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_AddCustomerGroup_Client_3325487026(NetworkConnection connection, string groupId, SpecialCustomerCamp camp, bool inPhaseTransition, SpecialCustomerLeader leader, List<SpecialCustomer> customers, int visitCount);
    private void RpcLogic___AddCustomerGroup_Client_3325487026(NetworkConnection connection, string groupId, SpecialCustomerCamp camp, bool inPhaseTransition, SpecialCustomerLeader leader, List<SpecialCustomer> customers, int visitCount);
    private void RpcReader___Observers_AddCustomerGroup_Client_3325487026(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_AddCustomerGroup_Client_3325487026(NetworkConnection connection, string groupId, SpecialCustomerCamp camp, bool inPhaseTransition, SpecialCustomerLeader leader, List<SpecialCustomer> customers, int visitCount);
    private void RpcReader___Target_AddCustomerGroup_Client_3325487026(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_RemoveCustomerGroup_Client_4137291475(NetworkConnection connection, string groupId, SpecialCustomerLeader leader, List<SpecialCustomer> customers);
    private void RpcLogic___RemoveCustomerGroup_Client_4137291475(NetworkConnection connection, string groupId, SpecialCustomerLeader leader, List<SpecialCustomer> customers);
    private void RpcReader___Observers_RemoveCustomerGroup_Client_4137291475(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_DealCompleted_Client_1068999487(SpecialCustomerDealReceipt dealRecipe);
    public void RpcLogic___DealCompleted_Client_1068999487(SpecialCustomerDealReceipt dealRecipe);
    private void RpcReader___Observers_DealCompleted_Client_1068999487(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002ESpecialCustomers_002ESpecialCustomerManager_Assembly_002DCSharp_002Edll();
}