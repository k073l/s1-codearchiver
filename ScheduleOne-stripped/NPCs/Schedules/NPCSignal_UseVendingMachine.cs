using System.Collections;
using FishNet;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.NPCs.Schedules;
public class NPCSignal_UseVendingMachine : NPCSignal
{
    private const float destinationThreshold;
    public VendingMachine MachineOverride;
    private VendingMachine TargetMachine;
    private Coroutine purchaseCoroutine;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ESchedules_002ENPCSignal_UseVendingMachineAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ESchedules_002ENPCSignal_UseVendingMachineAssembly_002DCSharp_002Edll_Excuted;
    public new string ActionName => "Use Vending Machine";

    public override string GetName();
    public override void Started();
    public override void MinPassed();
    public override void LateStarted();
    public override void Interrupt();
    public override void Resume();
    public override void Skipped();
    private bool IsAtDestination();
    private VendingMachine GetTargetMachine();
    protected override void WalkCallback(NPCMovement.WalkResult result);
    [ObserversRpc(RunLocally = true)]
    public void Purchase();
    private bool CheckItem();
    private void ItemWasStolen();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_Purchase_2166136261();
    public void RpcLogic___Purchase_2166136261();
    private void RpcReader___Observers_Purchase_2166136261(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}