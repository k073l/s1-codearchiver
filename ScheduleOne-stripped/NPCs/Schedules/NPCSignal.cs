using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;

namespace ScheduleOne.NPCs.Schedules;
public class NPCSignal : NPCAction
{
    public int MaxDuration;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ESchedules_002ENPCSignalAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ESchedules_002ENPCSignalAssembly_002DCSharp_002Edll_Excuted;
    public new string ActionName => "Signal";
    public bool StartedThisCycle { get; protected set; }

    public override string GetName();
    public override void ActiveUpdate();
    public override string GetTimeDescription();
    public override int GetEndTime();
    public override void Started();
    public override void LateStarted();
    public override bool ShouldStart();
    public override void Interrupt();
    public override void MinPassed();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}