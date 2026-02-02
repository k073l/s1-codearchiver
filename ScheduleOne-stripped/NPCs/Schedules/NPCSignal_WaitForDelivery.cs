using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.GameTime;
using ScheduleOne.Quests;
using UnityEngine;

namespace ScheduleOne.NPCs.Schedules;
public class NPCSignal_WaitForDelivery : NPCSignal
{
    public const float DestinationThreshold;
    public const float WalkSpeedMultiplier;
    private Contract contract;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ESchedules_002ENPCSignal_WaitForDeliveryAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ESchedules_002ENPCSignal_WaitForDeliveryAssembly_002DCSharp_002Edll_Excuted;
    public new string ActionName => "Wait for delivery";
    private DeliveryLocation Location => contract.DeliveryLocation;

    public void SetContract(Contract contract);
    public override void Awake();
    protected override void OnValidate();
    public override string GetName();
    public override void Started();
    public override void LateStarted();
    public override void JumpTo();
    private void EnsureNPCHasEnoughCash();
    public override void OnActiveTick();
    private void CheckWarp();
    public override void Interrupt();
    public override void Resume();
    public override void End();
    public override void Skipped();
    private bool IsAtDestination();
    protected override void WalkCallback(NPCMovement.WalkResult result);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002ESchedules_002ENPCSignal_WaitForDelivery_Assembly_002DCSharp_002Edll();
}