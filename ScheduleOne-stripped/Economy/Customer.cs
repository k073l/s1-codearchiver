using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.Cartel;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.Effects;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Law;
using ScheduleOne.Levelling;
using ScheduleOne.Map;
using ScheduleOne.Messaging;
using ScheduleOne.Money;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Relation;
using ScheduleOne.NPCs.Responses;
using ScheduleOne.NPCs.Schedules;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.Quests;
using ScheduleOne.UI;
using ScheduleOne.UI.Handover;
using ScheduleOne.UI.Phone.Messages;
using ScheduleOne.Variables;
using ScheduleOne.VoiceOver;
using ScheduleOne.Weather;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Economy;
[DisallowMultipleComponent]
[RequireComponent(typeof(NPC))]
public class Customer : NetworkBehaviour, ISaveable
{
    [Serializable]
    public class ScheduleGroupPair
    {
        public GameObject NormalScheduleGroup;
        public GameObject CurfewScheduleGroup;
    }

    [Serializable]
    public class CustomerPreference
    {
        public EDrugType DrugType;
        [Header("Optionally, a specific product")]
        public ProductDefinition Definition;
        public EQuality MinimumQuality;
    }

    [Serializable]
    public class ProductPurchaseRecord
    {
        public string ProductID;
        public int Quantity;
        public float TotalSpent;
    }

    public enum ESampleFeedback
    {
        WrongProduct,
        WrongQuality,
        Correct
    }

    public static Action<Customer> onCustomerUnlocked;
    public static List<Customer> LockedCustomers;
    public static List<Customer> UnlockedCustomers;
    public const int QualityTierTolerance;
    public const int MaxOrderQuantityPerProduct;
    public const float AFFINITY_MAX_EFFECT;
    public const float PROPERTY_MAX_EFFECT;
    public const float QUALITY_MAX_EFFECT;
    public const float DEAL_REJECTED_RELATIONSHIP_CHANGE;
    public const int ATTACK_DEAL_COOLDOWN;
    public const float RELATIONSHIP_THRESHOLD_TO_GIVE_DEAL_TO_CARTEL;
    public const float CUSTOMER_UNLOCKED_CARTEL_INFLUENCE_CHANGE;
    public bool DEBUG;
    public const float APPROACH_MIN_ADDICTION;
    public const float APPROACH_CHANCE_PER_DAY_MAX;
    public const float APPROACH_MIN_COOLDOWN;
    public const float APPROACH_MAX_COOLDOWN;
    public const int DEAL_COOLDOWN;
    public static string[] PlayerAcceptMessages;
    public static string[] PlayerRejectMessages;
    public const int DEAL_ATTENDANCE_TOLERANCE;
    public const int MIN_TRAVEL_TIME;
    public const int MAX_TRAVEL_TIME;
    public const int OFFER_EXPIRY_TIME_MINS;
    public const float MIN_ORDER_APPEAL;
    public const float ADDICTION_DRAIN_PER_DAY;
    public const bool SAMPLE_REQUIRES_RECOMMENDATION;
    public const float MIN_NORMALIZED_RELATIONSHIP_FOR_RECOMMENDATION;
    public const float RELATIONSHIP_FOR_GUARANTEED_DEALER_RECOMMENDATION;
    public const float RELATIONSHIP_FOR_GUARANTEED_SUPPLIER_RECOMMENDATION;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public float _003CCurrentAddiction_003Ek__BackingField;
    private ContractInfo offeredContractInfo;
    [CompilerGenerated]
    [SyncVar]
    public bool _003CHasBeenRecommended_003Ek__BackingField;
    public NPCSignal_WaitForDelivery DealSignal;
    [Header("Settings")]
    public bool AvailableInDemo;
    [SerializeField]
    protected CustomerData customerData;
    public DeliveryLocation DefaultDeliveryLocation;
    [Header("Events")]
    public UnityEvent onUnlocked;
    public UnityEvent onDealCompleted;
    public UnityEvent<Contract> onContractAssigned;
    private bool awaitingSample;
    private DialogueController.DialogueChoice sampleChoice;
    private DialogueController.DialogueChoice completeContractChoice;
    private DialogueController.DialogueChoice offerDealChoice;
    private DialogueController.GreetingOverride awaitingDealGreeting;
    private int minsSinceUnlocked;
    private bool sampleOfferedToday;
    private CustomerAffinityData currentAffinityData;
    private bool pendingInstantDeal;
    private ProductItemInstance consumedSample;
    public SyncVar<float> syncVar____003CCurrentAddiction_003Ek__BackingField;
    public SyncVar<bool> syncVar____003CHasBeenRecommended_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EEconomy_002ECustomerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EEconomy_002ECustomerAssembly_002DCSharp_002Edll_Excuted;
    public float CurrentAddiction {[CompilerGenerated]
        get; [CompilerGenerated]
        protected set; }
    public ContractInfo OfferedContractInfo { get; protected set; }
    public GameDateTime OfferedContractTime { get; protected set; }
    public Contract CurrentContract { get; protected set; }
    public bool IsAwaitingDelivery { get; protected set; }
    public int TimeSinceLastDealCompleted { get; protected set; } = 1000000;
    public int TimeSinceLastDealOffered { get; protected set; } = 1000000;
    public int TimeSincePlayerApproached { get; protected set; } = 1000000;
    public int TimeSinceInstantDealOffered { get; protected set; } = 1000000;
    public int OfferedDeals { get; protected set; }
    public int CompletedDeliveries { get; protected set; }
    public List<ProductPurchaseRecord> WeeklyPurchaseRecord { get; protected set; } = new List<ProductPurchaseRecord>();
    public bool HasBeenRecommended {[CompilerGenerated]
        get; [CompilerGenerated]
        protected set; }
    public NPC NPC { get; protected set; }
    public Dealer AssignedDealer { get; protected set; }
    public CustomerData CustomerData => customerData;
    private DialogueDatabase dialogueDatabase => NPC.DialogueHandler.Database;
    public NPCPoI potentialCustomerPoI { get; private set; }
    public string SaveFolderName => "CustomerData";
    public string SaveFileName => "CustomerData";
    public Loader Loader => null;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public float SyncAccessor__003CCurrentAddiction_003Ek__BackingField { get; set; }
    public bool SyncAccessor__003CHasBeenRecommended_003Ek__BackingField { get; set; }

    public static int MinsSinceLastDealOfferedAllCustomers();
    public override void Awake();
    private void Start();
    public override void OnStartClient();
    public override void OnSpawnServer(NetworkConnection connection);
    private void OnDestroy();
    private void SetUpDialogue();
    private void SetupPoI();
    public virtual void InitializeSaveable();
    protected virtual void OnMinPass();
    protected virtual void OnTick();
    private void OfferContractToDealer(ContractInfo info, Dealer dealer);
    protected virtual void OnSleepStart();
    public static void GetContractTimings(QuestWindowConfig dealWindow, out int softStartTime, out int hardStartTime, out int endTime);
    private void UpdateDealAttendance();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void ConfigureDealSignal(NetworkConnection conn, int startTime, bool active);
    private void UpdateOfferExpiry();
    [Button]
    public void ForceDealOffer();
    private List<ProductDefinition> GetOrderableProducts(Dealer dealer = null);
    private List<Tuple<ProductDefinition, int>> GetOrderableProductsWithQuantities(Dealer dealer = null);
    private ContractInfo TryGenerateContract(Dealer dealer);
    private ProductDefinition GetWeightedRandomProduct(Dealer dealer, out float appeal, out int orderableQuantity);
    protected virtual void OnCustomerUnlocked(NPCRelationData.EUnlockType unlockType, bool notify);
    public void SetHasBeenRecommended();
    public virtual void OfferContract(ContractInfo info);
    [ObserversRpc]
    private void SetOfferedContract(ContractInfo info, GameDateTime offerTime);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public virtual void ExpireOffer();
    public virtual void AssignContract(Contract contract);
    protected virtual void NotifyPlayerOfContract(ContractInfo contract, MessageChain offerMessage, bool canAccept, bool canReject, bool canCounterOffer = true);
    [ObserversRpc(RunLocally = true)]
    private void SetUpResponseCallbacks();
    protected virtual void AcceptContractClicked();
    protected virtual void CounterOfferClicked();
    protected virtual void SendCounteroffer(ProductDefinition product, int quantity, float price);
    [ServerRpc(RequireOwnership = false)]
    private void ProcessCounterOfferServerSide(string productID, int quantity, float price);
    [ObserversRpc(RunLocally = true)]
    private void SetContractIsCounterOffer();
    protected virtual void PlayerAcceptedContract(EDealWindow window);
    [ServerRpc(RequireOwnership = false)]
    private void SendContractAccepted(EDealWindow window, bool trackContract);
    public Contract ContractAccepted(EDealWindow window, bool trackContract, Dealer dealer);
    [ObserversRpc(RunLocally = true)]
    private void ReceiveContractAccepted();
    protected virtual void PlayContractAcceptedReaction();
    protected virtual bool EvaluateCounteroffer(ProductDefinition product, int quantity, float price);
    public static float GetValueProposition(ProductDefinition product, float price);
    protected virtual void ContractRejected();
    [ObserversRpc(RunLocally = true)]
    private void ReceiveContractRejected();
    protected virtual void PlayContractRejectedReaction();
    public virtual void SetIsAwaitingDelivery(bool awaiting);
    public bool IsAtDealLocation();
    private void UpdatePotentialCustomerPoI();
    public void SetPotentialCustomerPoIEnabled(bool enabled);
    protected virtual bool ShouldTryGenerateDeal();
    private bool IsDealTime();
    public virtual void OfferDealItems(List<ItemInstance> items, bool offeredByPlayer, out bool accepted);
    public virtual void CustomerRejectedDeal(bool offeredByPlayer);
    public virtual void ProcessHandover(HandoverScreen.EHandoverOutcome outcome, Contract contract, List<ItemInstance> items, bool handoverByPlayer, bool giveBonuses = true);
    [ServerRpc(RequireOwnership = false)]
    private void ProcessHandoverServerSide(HandoverScreen.EHandoverOutcome outcome, List<ItemInstance> items, bool handoverByPlayer, float totalPayment, ProductList productList, float satisfaction, NetworkObject dealerObject);
    [ObserversRpc]
    private void ProcessHandoverClient(float satisfaction, bool handoverByPlayer, string npcToRecommend, HandoverScreen.EHandoverOutcome outcome);
    public void ContractWellReceived(string npcToRecommend);
    private void RecommendDealer(Dealer dealer);
    private void RecommendSupplier(Supplier supplier);
    private void RecommendCustomer(Customer friend);
    public virtual void CurrentContractEnded(EQuestState outcome);
    public virtual float EvaluateDelivery(Contract contract, List<ItemInstance> providedItems, out float highestAddiction, out EDrugType mainTypeType, out int matchedProductCount, out float qualityDifference);
    public void CalculateTopWeeklyPurchases(out List<StringIntPair> mostPurchasedProducts, out float totalSpent);
    [ServerRpc(RequireOwnership = false)]
    public void ChangeAddiction(float change);
    private void ConsumeProduct(ItemInstance item);
    protected virtual bool ShowOfferDealOption(bool enabled);
    protected virtual bool OfferDealValid(out string invalidReason);
    protected virtual void InstantDealOffered();
    public float GetOfferSuccessChance(List<ItemInstance> items, float askingPrice);
    protected virtual bool ShouldTryApproachPlayer();
    [Button]
    public void RequestProduct();
    public void RequestProduct(Player target);
    public void PlayerRejectedProductRequest();
    [ServerRpc(RequireOwnership = false)]
    public void RejectProductRequestOffer();
    [ObserversRpc(RunLocally = true)]
    private void RejectProductRequestOffer_Local();
    public void AssignDealer(Dealer dealer);
    public virtual string GetSaveString();
    public ScheduleOne.Persistence.Datas.CustomerData GetCustomerData();
    public virtual List<string> WriteData(string parentFolderPath);
    [TargetRpc]
    private void ReceiveCustomerData(NetworkConnection conn, ScheduleOne.Persistence.Datas.CustomerData data);
    public virtual void Load(ScheduleOne.Persistence.Datas.CustomerData data);
    protected virtual bool IsReadyForHandover(bool enabled);
    protected virtual bool IsHandoverChoiceValid(out string invalidReason);
    public void HandoverChosen();
    protected virtual bool ShowDirectApproachOption(bool enabled);
    public virtual bool IsUnlockable();
    protected virtual bool SampleOptionValid(out string invalidReason);
    public bool KnownAndRecommended();
    public void SampleOffered();
    protected virtual float GetSampleRequestSuccessChance();
    protected virtual void SampleAccepted();
    private float GetSampleSuccess(List<ItemInstance> items, float price);
    private void ProcessSample(HandoverScreen.EHandoverOutcome outcome, List<ItemInstance> items, float price);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    private void ProcessSampleServerSide(List<ItemInstance> items);
    [ObserversRpc(RunLocally = true)]
    private void ProcessSampleClient();
    private void SampleConsumed();
    private void EndWait();
    protected virtual void DirectApproachRejected();
    [ObserversRpc]
    private void SampleWasSufficient();
    [ObserversRpc]
    private void SampleWasInsufficient();
    public float GetProductEnjoyment(ProductDefinition product, EQuality quality);
    public List<EDrugType> GetOrderedDrugTypes();
    [ServerRpc(RequireOwnership = false)]
    public void AdjustAffinity(EDrugType drugType, float change);
    [Button]
    public void AutocreateCustomerSettings();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_ConfigureDealSignal_338960014(NetworkConnection conn, int startTime, bool active);
    private void RpcLogic___ConfigureDealSignal_338960014(NetworkConnection conn, int startTime, bool active);
    private void RpcReader___Observers_ConfigureDealSignal_338960014(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_ConfigureDealSignal_338960014(NetworkConnection conn, int startTime, bool active);
    private void RpcReader___Target_ConfigureDealSignal_338960014(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetOfferedContract_4277245194(ContractInfo info, GameDateTime offerTime);
    private void RpcLogic___SetOfferedContract_4277245194(ContractInfo info, GameDateTime offerTime);
    private void RpcReader___Observers_SetOfferedContract_4277245194(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ExpireOffer_2166136261();
    public virtual void RpcLogic___ExpireOffer_2166136261();
    private void RpcReader___Server_ExpireOffer_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetUpResponseCallbacks_2166136261();
    private void RpcLogic___SetUpResponseCallbacks_2166136261();
    private void RpcReader___Observers_SetUpResponseCallbacks_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ProcessCounterOfferServerSide_900355577(string productID, int quantity, float price);
    private void RpcLogic___ProcessCounterOfferServerSide_900355577(string productID, int quantity, float price);
    private void RpcReader___Server_ProcessCounterOfferServerSide_900355577(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetContractIsCounterOffer_2166136261();
    private void RpcLogic___SetContractIsCounterOffer_2166136261();
    private void RpcReader___Observers_SetContractIsCounterOffer_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendContractAccepted_507093020(EDealWindow window, bool trackContract);
    private void RpcLogic___SendContractAccepted_507093020(EDealWindow window, bool trackContract);
    private void RpcReader___Server_SendContractAccepted_507093020(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ReceiveContractAccepted_2166136261();
    private void RpcLogic___ReceiveContractAccepted_2166136261();
    private void RpcReader___Observers_ReceiveContractAccepted_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ReceiveContractRejected_2166136261();
    private void RpcLogic___ReceiveContractRejected_2166136261();
    private void RpcReader___Observers_ReceiveContractRejected_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ProcessHandoverServerSide_3760244802(HandoverScreen.EHandoverOutcome outcome, List<ItemInstance> items, bool handoverByPlayer, float totalPayment, ProductList productList, float satisfaction, NetworkObject dealerObject);
    private void RpcLogic___ProcessHandoverServerSide_3760244802(HandoverScreen.EHandoverOutcome outcome, List<ItemInstance> items, bool handoverByPlayer, float totalPayment, ProductList productList, float satisfaction, NetworkObject dealerObject);
    private void RpcReader___Server_ProcessHandoverServerSide_3760244802(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ProcessHandoverClient_2441224929(float satisfaction, bool handoverByPlayer, string npcToRecommend, HandoverScreen.EHandoverOutcome outcome);
    private void RpcLogic___ProcessHandoverClient_2441224929(float satisfaction, bool handoverByPlayer, string npcToRecommend, HandoverScreen.EHandoverOutcome outcome);
    private void RpcReader___Observers_ProcessHandoverClient_2441224929(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ChangeAddiction_431000436(float change);
    public void RpcLogic___ChangeAddiction_431000436(float change);
    private void RpcReader___Server_ChangeAddiction_431000436(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_RejectProductRequestOffer_2166136261();
    public void RpcLogic___RejectProductRequestOffer_2166136261();
    private void RpcReader___Server_RejectProductRequestOffer_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_RejectProductRequestOffer_Local_2166136261();
    private void RpcLogic___RejectProductRequestOffer_Local_2166136261();
    private void RpcReader___Observers_RejectProductRequestOffer_Local_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_ReceiveCustomerData_2280244125(NetworkConnection conn, ScheduleOne.Persistence.Datas.CustomerData data);
    private void RpcLogic___ReceiveCustomerData_2280244125(NetworkConnection conn, ScheduleOne.Persistence.Datas.CustomerData data);
    private void RpcReader___Target_ReceiveCustomerData_2280244125(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ProcessSampleServerSide_3704012609(List<ItemInstance> items);
    private void RpcLogic___ProcessSampleServerSide_3704012609(List<ItemInstance> items);
    private void RpcReader___Server_ProcessSampleServerSide_3704012609(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ProcessSampleClient_2166136261();
    private void RpcLogic___ProcessSampleClient_2166136261();
    private void RpcReader___Observers_ProcessSampleClient_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SampleWasSufficient_2166136261();
    private void RpcLogic___SampleWasSufficient_2166136261();
    private void RpcReader___Observers_SampleWasSufficient_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SampleWasInsufficient_2166136261();
    private void RpcLogic___SampleWasInsufficient_2166136261();
    private void RpcReader___Observers_SampleWasInsufficient_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_AdjustAffinity_3036964899(EDrugType drugType, float change);
    public void RpcLogic___AdjustAffinity_3036964899(EDrugType drugType, float change);
    private void RpcReader___Server_AdjustAffinity_3036964899(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override bool ReadSyncVar___ScheduleOne_002EEconomy_002ECustomer(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected virtual void Awake_UserLogic_ScheduleOne_002EEconomy_002ECustomer_Assembly_002DCSharp_002Edll();
}