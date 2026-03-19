using System;
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
using ScheduleOne.AvatarFramework;
using ScheduleOne.Cartel;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Map;
using ScheduleOne.Messaging;
using ScheduleOne.Money;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.NPCs.Relation;
using ScheduleOne.NPCs.Schedules;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Product;
using ScheduleOne.Product.Packaging;
using ScheduleOne.Quests;
using ScheduleOne.UI;
using ScheduleOne.Variables;
using ScheduleOne.VoiceOver;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Economy;
public class Dealer : NPC, IItemSlotOwner
{
    private enum EAmountSortOrder
    {
        LowToHigh,
        HighToLow
    }

    public const int MAX_CUSTOMERS;
    public const int DEAL_ARRIVAL_DELAY;
    public const int MIN_TRAVEL_TIME;
    public const int MAX_TRAVEL_TIME;
    public const int OVERFLOW_SLOT_COUNT;
    public const float CASH_REMINDER_THRESHOLD;
    public const float RELATIONSHIP_CHANGE_PER_DEAL;
    public static Color32 DealerLabelColor;
    public const int NegativeQualityTolerance;
    public const int PositiveQualityTolerance;
    public static Action<Dealer> onDealerRecruited;
    public static List<Dealer> AllPlayerDealers;
    [CompilerGenerated]
    [SyncVar(OnChange = "UpdateCollectCashChoice")]
    public float _003CCash_003Ek__BackingField;
    public Action onContractAccepted;
    [Header("Dealer References")]
    public NPCEnterableBuilding Home;
    public NPCEvent_StayInBuilding HomeEvent;
    public DialogueController_Dealer DialogueController;
    [Header("Dialogue stuff")]
    public DialogueContainer RecruitDialogue;
    public DialogueContainer CollectCashDialogue;
    public DialogueContainer AssignCustomersDialogue;
    [Header("Dealer Settings")]
    public EDealerType DealerType;
    public string HomeName;
    public float SigningFee;
    public float Cut;
    [Header("Variables")]
    public string CompletedDealsVariable;
    [Header("UnityEvents")]
    public UnityEvent onRecommended;
    public UnityEvent onCompleteDeal;
    [Header("Seasonal Events")]
    public AvatarSettings ChristmasOutfit;
    private ItemSlot[] overflowSlots;
    private Contract currentContract;
    private DialogueController.DialogueChoice recruitChoice;
    private DialogueController.DialogueChoice collectCashChoice;
    private DialogueController.DialogueChoice assignCustomersChoice;
    private int itemCountOnTradeStart;
    private DealerAttendDealBehaviour _attendDealBehaviour;
    public SyncVar<float> syncVar____003CCash_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EEconomy_002EDealerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EEconomy_002EDealerAssembly_002DCSharp_002Edll_Excuted;
    public bool IsRecruited { get; private set; }
    public List<ItemSlot> ItemSlots { get; set; } = new List<ItemSlot>();
    public NPCPoI PotentialDealerPoI { get; private set; }
    public NPCPoI DealerPoI { get; private set; }
    public float Cash {[CompilerGenerated]
        get; [CompilerGenerated]
        private set; }
    public List<Customer> AssignedCustomers { get; private set; } = new List<Customer>();
    public List<Contract> ActiveContracts { get; private set; } = new List<Contract>();
    public bool HasBeenRecommended { get; private set; }
    public float SyncAccessor__003CCash_003Ek__BackingField { get; set; }

    public override void Awake();
    protected override void OnValidate();
    protected override void OnDestroy();
    protected override void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    private void SetupPoI();
    private void SetUpDialogue();
    protected override void OnTick();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void MarkAsRecommended();
    [ObserversRpc(RunLocally = true)]
    private void SetRecommended();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void InitialRecruitment();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public virtual void SetIsRecruited(NetworkConnection conn);
    protected virtual void OnDealerUnlocked(NPCRelationData.EUnlockType unlockType, bool b);
    protected virtual void UpdatePotentialDealerPoI();
    private void DealerUnconscious();
    private void TradeItems();
    private void TradeItemsDone();
    private bool CanCollectCash(out string reason);
    private void UpdateCollectCashChoice(float oldCash, float newCash, bool asServer);
    private void CollectCash();
    private void CheckCurrentDealValidity();
    private bool CanOfferRecruitment(out string reason);
    private void CheckAttendStart();
    public virtual bool ShouldAcceptContract(ContractInfo contractInfo, Customer customer);
    public virtual void ContractedOffered(ContractInfo contractInfo, Customer customer);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void AddCustomer_Server(string npcID);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void AddCustomer_Client(NetworkConnection conn, string npcID);
    protected virtual void AddCustomer(Customer customer);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendRemoveCustomer(string npcID);
    [ObserversRpc(RunLocally = true)]
    private void RemoveCustomer(string npcID);
    public virtual void RemoveCustomer(Customer customer);
    public void ChangeCash(float change);
    [ServerRpc(RequireOwnership = false)]
    public void SetCash(float cash);
    [ServerRpc(RequireOwnership = false)]
    public virtual void CompletedDeal();
    [ServerRpc(RequireOwnership = false)]
    public void SubmitPayment(float payment);
    public void TryRobDealer();
    public List<Tuple<ProductDefinition, EQuality, int>> GetOrderableProducts(EQuality minQuality);
    public int GetOrderableProductQuantity(string productID, EQuality minQuality, EQuality maxQuality);
    [Button]
    private List<Tuple<ProductDefinition, EQuality, int>> GetAvailableProducts();
    private EDealWindow GetDealWindow();
    private int GetContractCountInWindow(EDealWindow window);
    private void AddContract(Contract contract);
    private void CustomerContractEnded(Contract contract);
    private void SortContracts();
    protected virtual void RecruitmentRequested();
    public void RemoveContractItems(Contract contract, EQuality targetQuality, out List<ItemInstance> items);
    private List<ProductItemInstance> RemoveAndReturnProductFromInventory(string productID, int requiredQuantity, EQuality targetQuality);
    private void SplitItemSlot(ItemSlot slot);
    private List<ItemSlot> FilterAndSortSlots(List<ItemSlot> slots, string productID, EQuality productQuality, EAmountSortOrder amountSortOrder);
    public List<ItemSlot> GetAllSlots();
    public void AddItemToInventory(ItemInstance item);
    public void TryMoveOverflowItems();
    public int GetTotalInventoryItemCount();
    public int GetPackagedProductAmount();
    public virtual void CheckNotifyPlayerOfDeal(Dealer cartelDealer, Contract contract);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetStoredInstance(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetStoredInstance_Internal(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetItemSlotQuantity(int itemSlotIndex, int quantity);
    [ObserversRpc(RunLocally = true)]
    private void SetItemSlotQuantity_Internal(int itemSlotIndex, int quantity);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetSlotLocked(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    [TargetRpc]
    [ObserversRpc(RunLocally = true)]
    private void SetSlotLocked_Internal(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetSlotFilter(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetSlotFilter_Internal(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    public override NPCData GetNPCData();
    public override void Load(DynamicSaveData dynamicData, NPCData npcData);
    public override void Load(NPCData data, string containerPath);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_MarkAsRecommended_2166136261();
    public void RpcLogic___MarkAsRecommended_2166136261();
    private void RpcReader___Server_MarkAsRecommended_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetRecommended_2166136261();
    private void RpcLogic___SetRecommended_2166136261();
    private void RpcReader___Observers_SetRecommended_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_InitialRecruitment_2166136261();
    public void RpcLogic___InitialRecruitment_2166136261();
    private void RpcReader___Server_InitialRecruitment_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetIsRecruited_328543758(NetworkConnection conn);
    public virtual void RpcLogic___SetIsRecruited_328543758(NetworkConnection conn);
    private void RpcReader___Observers_SetIsRecruited_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetIsRecruited_328543758(NetworkConnection conn);
    private void RpcReader___Target_SetIsRecruited_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_AddCustomer_Server_3615296227(string npcID);
    public void RpcLogic___AddCustomer_Server_3615296227(string npcID);
    private void RpcReader___Server_AddCustomer_Server_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_AddCustomer_Client_2971853958(NetworkConnection conn, string npcID);
    private void RpcLogic___AddCustomer_Client_2971853958(NetworkConnection conn, string npcID);
    private void RpcReader___Observers_AddCustomer_Client_2971853958(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_AddCustomer_Client_2971853958(NetworkConnection conn, string npcID);
    private void RpcReader___Target_AddCustomer_Client_2971853958(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendRemoveCustomer_3615296227(string npcID);
    public void RpcLogic___SendRemoveCustomer_3615296227(string npcID);
    private void RpcReader___Server_SendRemoveCustomer_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_RemoveCustomer_3615296227(string npcID);
    private void RpcLogic___RemoveCustomer_3615296227(string npcID);
    private void RpcReader___Observers_RemoveCustomer_3615296227(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetCash_431000436(float cash);
    public void RpcLogic___SetCash_431000436(float cash);
    private void RpcReader___Server_SetCash_431000436(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_CompletedDeal_2166136261();
    public virtual void RpcLogic___CompletedDeal_2166136261();
    private void RpcReader___Server_CompletedDeal_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SubmitPayment_431000436(float payment);
    public void RpcLogic___SubmitPayment_431000436(float payment);
    private void RpcReader___Server_SubmitPayment_431000436(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SetStoredInstance_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    public void RpcLogic___SetStoredInstance_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    private void RpcReader___Server_SetStoredInstance_2652194801(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetStoredInstance_Internal_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    private void RpcLogic___SetStoredInstance_Internal_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    private void RpcReader___Observers_SetStoredInstance_Internal_2652194801(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetStoredInstance_Internal_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    private void RpcReader___Target_SetStoredInstance_Internal_2652194801(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetItemSlotQuantity_1692629761(int itemSlotIndex, int quantity);
    public void RpcLogic___SetItemSlotQuantity_1692629761(int itemSlotIndex, int quantity);
    private void RpcReader___Server_SetItemSlotQuantity_1692629761(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetItemSlotQuantity_Internal_1692629761(int itemSlotIndex, int quantity);
    private void RpcLogic___SetItemSlotQuantity_Internal_1692629761(int itemSlotIndex, int quantity);
    private void RpcReader___Observers_SetItemSlotQuantity_Internal_1692629761(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetSlotLocked_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    public void RpcLogic___SetSlotLocked_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    private void RpcReader___Server_SetSlotLocked_3170825843(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Target_SetSlotLocked_Internal_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    private void RpcLogic___SetSlotLocked_Internal_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    private void RpcReader___Target_SetSlotLocked_Internal_3170825843(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetSlotLocked_Internal_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    private void RpcReader___Observers_SetSlotLocked_Internal_3170825843(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetSlotFilter_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    public void RpcLogic___SetSlotFilter_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    private void RpcReader___Server_SetSlotFilter_527532783(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetSlotFilter_Internal_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    private void RpcLogic___SetSlotFilter_Internal_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    private void RpcReader___Observers_SetSlotFilter_Internal_527532783(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetSlotFilter_Internal_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    private void RpcReader___Target_SetSlotFilter_Internal_527532783(PooledReader PooledReader0, Channel channel);
    public override bool ReadSyncVar___ScheduleOne_002EEconomy_002EDealer(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002EEconomy_002EDealer_Assembly_002DCSharp_002Edll();
}