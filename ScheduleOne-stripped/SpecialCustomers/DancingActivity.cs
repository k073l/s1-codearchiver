using System.Collections.Generic;
using FishNet.Connection;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Behaviour;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers;
public class DancingActivity : MoveToAndActActivity
{
    public override string ActivityName => "Dancing";
    protected override int MaxParticipantsPerInstance => 5;
    protected override bool ShouldBeConsideredForReassignment => false;

    protected override void OnRun(List<SpecialCustomer> addedNpcs);
    public override void OnClientJoin(NetworkConnection connection);
}