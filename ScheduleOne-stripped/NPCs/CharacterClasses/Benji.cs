using FishNet;
using FishNet.Connection;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.Product;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs.CharacterClasses;
public class Benji : Dealer
{
    public string CompletedDealsVariable;
    public UnityEvent onRecruitmentRequested;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ECharacterClasses_002EBenjiAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ECharacterClasses_002EBenjiAssembly_002DCSharp_002Edll_Excuted;
    public override void OnSpawnServer(NetworkConnection connection);
    protected override void OnTick();
    protected override void AddCustomer(Customer customer);
    public override void RemoveCustomer(Customer customer);
    protected override void RecruitmentRequested();
    protected override void UpdatePotentialDealerPoI();
    private void IncrementCompletedDeals();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}