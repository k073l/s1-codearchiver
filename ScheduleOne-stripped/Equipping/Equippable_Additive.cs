using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerTasks;

namespace ScheduleOne.Equipping;
public class Equippable_Additive : Equippable_Pourable
{
    private AdditiveDefinition additiveDef;
    public override void Equip(ItemInstance item);
    protected override void StartPourTask(GrowContainer growContainer);
    protected override bool CanPour(GrowContainer pot, out string reason);
}