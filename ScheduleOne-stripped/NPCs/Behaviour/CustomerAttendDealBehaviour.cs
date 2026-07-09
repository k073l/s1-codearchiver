using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.GameTime;
using ScheduleOne.Quests;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class CustomerAttendDealBehaviour : Behaviour
{
    private const float DestinationThreshold;
    private const float WalkSpeedMultiplier;
    private Contract _contract;
    private Customer _customer;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002ECustomerAttendDealBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002ECustomerAttendDealBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private DeliveryLocation _location => _contract.DeliveryLocation;

    public override void Awake();
    public void SetContract(Contract contract);
    public override void Activate();
    public override void Resume();
    public override void Deactivate();
    public override void Pause();
    private void EnsureNPCHasEnoughCash();
    public override void OnActiveTick();
    private void CheckWarp();
    private bool IsAtDestination();
    protected override void WalkCallback(NPCMovement.WalkResult result);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002ECustomerAttendDealBehaviour_Assembly_002DCSharp_002Edll();
}