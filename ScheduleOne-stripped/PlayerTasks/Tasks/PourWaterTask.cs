using ScheduleOne.DevUtilities;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
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
    protected override GrowContainerCameraHandler.ECameraPosition CameraPosition => GrowContainerCameraHandler.ECameraPosition.BirdsEye;

    public PourWaterTask(GrowContainer _growContainer, ItemInstance _itemInstance, Pourable _pourablePrefab);
    public override void StopTask();
    public override void TargetReached();
}