using ScheduleOne.Core.Avatar;
using ScheduleOne.NPCs;

namespace ScheduleOne.SpecialCustomers;
public class PissingActivity : MoveToAndActActivity
{
    public override string ActivityName => "Pissing";
    protected override int MaxParticipantsPerInstance => 3;
    protected override bool ShouldBeConsideredForReassignment => true;

    public override bool IsValidParticipant(SpecialCustomer npc);
}