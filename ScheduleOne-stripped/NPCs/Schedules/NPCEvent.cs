using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;

namespace ScheduleOne.NPCs.Schedules;
public class NPCEvent : NPCAction
{
    public int Duration;
    public int EndTime;
    private bool _forgotUmbrella;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ESchedules_002ENPCEventAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ESchedules_002ENPCEventAssembly_002DCSharp_002Edll_Excuted;
    public new string ActionName => "Event";

    [Button]
    public void ApplyDuration();
    [Button]
    public void ApplyEndTime();
    protected override void OnStart();
    public override void OnActiveMinPass();
    public override void OnActiveTick();
    public override void PendingMinPassed();
    public override string GetName();
    public override string GetTimeDescription();
    public override int GetEndTime();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}