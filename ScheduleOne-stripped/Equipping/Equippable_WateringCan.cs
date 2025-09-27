using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.ObjectScripts.WateringCan;
using ScheduleOne.PlayerTasks.Tasks;

namespace ScheduleOne.Equipping;
public class Equippable_WateringCan : Equippable_Pourable
{
    public WateringCanVisuals Visuals;
    private WateringCanInstance WCInstance;
    public override string InteractionLabel { get; set; } = "Pour water";

    public override void Equip(ItemInstance item);
    public override void Unequip();
    private void UpdateVisuals();
    protected override bool CanPour(Pot pot, out string reason);
    protected override void StartPourTask(Pot pot);
}