using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerTasks;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class Equippable_Additive : Equippable_Pourable
{
    private AdditiveDefinition additiveDef;
    public override void Equip(ItemInstance item);
    protected override void StartPourTask(Pot pot);
    protected override bool CanPour(Pot pot, out string reason);
}