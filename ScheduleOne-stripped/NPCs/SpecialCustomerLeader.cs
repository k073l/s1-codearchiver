using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.Effects;
using ScheduleOne.ItemFramework;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.NPCs.Schedules;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.Product.Packaging;
using ScheduleOne.SpecialCustomers;
using ScheduleOne.UI.Handover;
using ScheduleOne.VoiceOver;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs;
public class SpecialCustomerLeader : SpecialCustomer
{
    public struct ProductEvaluationResult
    {
        public int TotalValue;
        public int PotentialQuantity;
        public int BaseValue;
        public int BonusValue;
        public bool ExceedsBuyLimit;
    }

    public const string MessageConversationPrefix;
    [Header("Special Customer Leader")]
    [SerializeField]
    private NPCEvent_LocationDialogue _leaderIdleEvent;
    [SerializeField]
    private GameObject _leaderIndicator;
    private DialogueController _dialogueController;
    private SpecialCustomerData _customerData;
    private List<Effect> _desiredEffects;
    [SyncVar( /*Could not decode attribute arguments.*/)]
    [HideInInspector]
    public int _startingBuyQuantity;
    [SyncVar( /*Could not decode attribute arguments.*/)]
    [HideInInspector]
    public int _remainingBuyQuantity;
    public SyncVar<int> syncVar____startingBuyQuantity;
    public SyncVar<int> syncVar____remainingBuyQuantity;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ESpecialCustomerLeaderAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ESpecialCustomerLeaderAssembly_002DCSharp_002Edll_Excuted;
    public List<Effect> DesiredEffects => _desiredEffects;
    public SpecialCustomerData CustomerData => _customerData;
    public int StartingBuyQuantity => SyncAccessor__startingBuyQuantity;
    public int RemainingBuyQuantity => SyncAccessor__remainingBuyQuantity;
    public int SyncAccessor__startingBuyQuantity { get; set; }
    public int SyncAccessor__remainingBuyQuantity { get; set; }

    public override void Awake();
    public void SetCustomerData(SpecialCustomerData data, List<Effect> desiredEffects, Transform idlePosition);
    private void OnDealDialogueChoice();
    private bool IsDealChoiceValid(out string invalidReason);
    protected void DealSubmitCallback(IEnumerable<ItemInstance> items);
    private void PlayDealReaction();
    [ServerRpc(RequireOwnership = false)]
    private void DealSubmit_Server(Player seller, List<ItemInstance> items, int totalQuantity);
    protected void ConsumeProduct(ProductItemInstance product, float delay = 1f);
    protected void DealCancelCallback();
    public bool IsProductWantedByGroup(ProductItemInstance productInstance);
    public ProductEvaluationResult GetProductValue(IEnumerable<ItemInstance> items);
    private int GetProductValue(ProductItemInstance product, out int baseValue, out int bonusValue);
    public bool HasProduct();
    public int GetProductQunatity();
    public ProductItemInstance GetProduct();
    [Server]
    public void SetStartingBuyQuantity(int quantity);
    [Server]
    public void SetRemainingBuyQuantity(int quantity);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_DealSubmit_Server_1831547993(Player seller, List<ItemInstance> items, int totalQuantity);
    private void RpcLogic___DealSubmit_Server_1831547993(Player seller, List<ItemInstance> items, int totalQuantity);
    private void RpcReader___Server_DealSubmit_Server_1831547993(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override bool ReadSyncVar___ScheduleOne_002ENPCs_002ESpecialCustomerLeader(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002ESpecialCustomerLeader_Assembly_002DCSharp_002Edll();
}