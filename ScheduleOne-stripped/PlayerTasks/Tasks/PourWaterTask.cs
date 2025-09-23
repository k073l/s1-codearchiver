using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.ObjectScripts.WateringCan;
using ScheduleOne.UI;
using ScheduleOne.Variables;
using UnityEngine;

namespace ScheduleOne.PlayerTasks.Tasks;
public class PourWaterTask : PourOntoTargetTask
{
    public const float NORMALIZED_FILL_PER_TARGET;
    public static bool hintShown;
    protected override bool UseCoverage => true;
    protected override bool FailOnEmpty => false;
    protected override Pot.ECameraPosition CameraPosition => Pot.ECameraPosition.BirdsEye;

    public PourWaterTask(Pot _pot, ItemInstance _itemInstance, Pourable _pourablePrefab);
    public override void StopTask();
    public override void TargetReached();
}