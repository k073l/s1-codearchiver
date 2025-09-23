using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerTasks.Tasks;
using UnityEngine;

namespace ScheduleOne.PlayerTasks;
public class ApplyAdditiveToPot : PourIntoPotTask
{
    private AdditiveDefinition def;
    protected override bool UseCoverage => true;
    protected override Pot.ECameraPosition CameraPosition => Pot.ECameraPosition.BirdsEye;

    public ApplyAdditiveToPot(Pot _pot, ItemInstance _itemInstance, Pourable _pourablePrefab);
    public override void Update();
    protected override void FullyCovered();
}