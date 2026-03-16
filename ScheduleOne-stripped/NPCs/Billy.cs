using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.Quests;
using ScheduleOne.UI.Handover;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.NPCs;
public class Billy : NPC
{
    public const int REQUESTED_PRODUCT_AMOUNT;
    public const string REQUESTED_PRODUCT_ID;
    [Header("References")]
    public Contract TradeContract;
    public ItemDefinition RDXDefinition;
    private Customer customerComp;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBillyAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBillyAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    public void OpenRDXTradeHandover();
    private void HandoverOutcome(HandoverScreen.EHandoverOutcome outcome, List<ItemInstance> givenItems, float payment);
    private float GetSucccessChance(List<ItemInstance> items, float price);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002EBilly_Assembly_002DCSharp_002Edll();
}