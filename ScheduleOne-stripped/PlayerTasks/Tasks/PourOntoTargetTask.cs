using ScheduleOne.DevUtilities;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.PlayerTasks.Tasks;
public class PourOntoTargetTask : GrowContainerPourTask
{
    public float SUCCESS_THRESHOLD;
    public float SUCCESS_TIME;
    private float timeOverTarget;
    public PourOntoTargetTask(GrowContainer _growContainer, ItemInstance _itemInstance, Pourable _pourablePrefab);
    public override void Update();
    public override void StopTask();
    public virtual void TargetReached();
}