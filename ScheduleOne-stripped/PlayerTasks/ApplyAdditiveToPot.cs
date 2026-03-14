using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerTasks.Tasks;
using UnityEngine;

namespace ScheduleOne.PlayerTasks;
public class ApplyAdditiveToPot : GrowContainerPourTask
{
    private AdditiveDefinition def;
    protected override bool UseCoverage => true;
    protected override GrowContainerCameraHandler.ECameraPosition CameraPosition => GrowContainerCameraHandler.ECameraPosition.BirdsEye;

    public ApplyAdditiveToPot(GrowContainer _growContainer, ItemInstance _itemInstance, Pourable _pourablePrefab);
    public override void Update();
    protected override void FullyCovered();
}