using ScheduleOne.Equipping;
using ScheduleOne.PlayerTasks.Tasks;

namespace ScheduleOne.ObjectScripts.Soil;
public class Equippable_Soil : Equippable_Pourable
{
    public override string InteractionLabel { get; set; } = "Pour soil";

    protected override bool CanPour(Pot pot, out string reason);
    protected override void StartPourTask(Pot pot);
}