using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks.Tasks;
using ScheduleOne.Tools;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class PourableWaterContainerEquipped : Equippable_Pourable
{
    [SerializeField]
    private WaterContainerVisualizer _visuals;
    [SerializeField]
    private WaterContainerPourable _pourablePrefab;
    private WaterContainerInstance _waterContainerInstance;
    public override void Equip(ItemInstance item);
    public override void Unequip();
    protected override bool CanPour(GrowContainer growContainer, out string reason);
    protected override void StartPourTask(GrowContainer growContainer);
}