using ScheduleOne.Building;
using ScheduleOne.DevUtilities;

namespace ScheduleOne.Equipping;
public class Equippable_BuildableItem : Equippable
{
    protected bool isBuilding;
    protected override void Update();
    public override void Unequip();
}