using System;
using System.Collections;
using FishNet;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using FluffyUnderware.DevTools.Extensions;
using ScheduleOne.DevUtilities;
using ScheduleOne.Doors;
using ScheduleOne.Map;
using UnityEngine;

namespace ScheduleOne.NPCs.Schedules;
public class NPCEvent_StayInBuilding : NPCEvent
{
    public NPCEnterableBuilding Building;
    [Header("Optionally specify door to use. Otherwise closest door will be used.")]
    public StaticDoor Door;
    private bool IsEntering;
    private Coroutine enterRoutine;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ESchedules_002ENPCEvent_StayInBuildingAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ESchedules_002ENPCEvent_StayInBuildingAssembly_002DCSharp_002Edll_Excuted;
    public new string ActionName => "Stay in Building";
    private bool InBuilding => (Object)(object)npc.CurrentBuilding == (Object)(object)Building;

    public override void Awake();
    public override string GetName();
    public override void Started();
    public override void ActiveMinPassed();
    public override void LateStarted();
    public override void JumpTo();
    public override void End();
    public override void Interrupt();
    public override void Skipped();
    public override void Resume();
    protected override void WalkCallback(NPCMovement.WalkResult result);
    [ObserversRpc(RunLocally = true)]
    private void PlayEnterAnimation();
    private void CancelEnter();
    protected virtual void EnterBuilding(int doorIndex);
    private void ExitBuilding();
    private Transform GetEntryPoint();
    private StaticDoor GetDoor(out int doorIndex);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_PlayEnterAnimation_2166136261();
    private void RpcLogic___PlayEnterAnimation_2166136261();
    private void RpcReader___Observers_PlayEnterAnimation_2166136261(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002ESchedules_002ENPCEvent_StayInBuilding_Assembly_002DCSharp_002Edll();
}