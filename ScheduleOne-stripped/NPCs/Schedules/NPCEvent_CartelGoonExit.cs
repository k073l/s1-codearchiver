using ScheduleOne.Cartel;
using UnityEngine;

namespace ScheduleOne.NPCs.Schedules;
public class NPCEvent_CartelGoonExit : NPCEvent_StayInBuilding
{
    public CartelGoon Goon;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ESchedules_002ENPCEvent_CartelGoonExitAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ESchedules_002ENPCEvent_CartelGoonExitAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    public override void Started();
    public override void LateStarted();
    public override void JumpTo();
    public override void Resume();
    private void FindExitBuilding();
    protected override void EnterBuilding(int doorIndex);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002ESchedules_002ENPCEvent_CartelGoonExit_Assembly_002DCSharp_002Edll();
}