using System;
using System.Collections;
using ScheduleOne.Economy;
using ScheduleOne.Quests;
using UnityEngine;

namespace ScheduleOne.NPCs.Schedules;
public class NPCSignal_HandleDeal : NPCSignal
{
    private Dealer dealer;
    private Contract contract;
    private Customer customer;
    private Coroutine handoverRoutine;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ESchedules_002ENPCSignal_HandleDealAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ESchedules_002ENPCSignal_HandleDealAssembly_002DCSharp_002Edll_Excuted;
    public new string ActionName => "Handle deal";

    public void AssignContract(Contract c);
    public override void Awake();
    protected override void OnValidate();
    public override string GetName();
    public override void Started();
    public override void MinPassed();
    public override void LateStarted();
    public override void JumpTo();
    public override void Interrupt();
    public override void End();
    public override void Skipped();
    private bool IsAtDestination();
    private bool IsCustomerReady();
    protected override void WalkCallback(NPCMovement.WalkResult result);
    private void BeginHandover();
    private void StopHandover();
    private Vector3 GetStandPos();
    private Vector3 GetStandDir();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002ESchedules_002ENPCSignal_HandleDeal_Assembly_002DCSharp_002Edll();
}