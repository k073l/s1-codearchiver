using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class StopDryingRackBehaviour : Behaviour
{
    public const float TIME_PER_ITEM;
    private Coroutine workRoutine;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EStopDryingRackBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EStopDryingRackBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public DryingRack Rack { get; protected set; }
    public bool WorkInProgress { get; protected set; }

    public override void Begin();
    public override void Resume();
    public override void Pause();
    public override void Disable();
    public override void End();
    public override void ActiveMinPass();
    private void StartWork();
    public void AssignRack(DryingRack rack);
    public bool IsAtStation();
    public void GoToStation();
    [ObserversRpc(RunLocally = true)]
    public void BeginAction();
    private void StopCauldron();
    public bool IsRackReady(DryingRack rack);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_BeginAction_2166136261();
    public void RpcLogic___BeginAction_2166136261();
    private void RpcReader___Observers_BeginAction_2166136261(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}