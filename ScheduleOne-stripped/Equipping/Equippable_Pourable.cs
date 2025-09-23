using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.PlayerTasks.Tasks;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class Equippable_Pourable : Equippable_Viewmodel
{
    [Header("Pourable settings")]
    public float InteractionRange;
    public Pourable PourablePrefab;
    public virtual string InteractionLabel { get; set; } = "Pour";

    protected override void Update();
    protected virtual void StartPourTask(Pot pot);
    protected virtual bool CanPour(Pot pot, out string reason);
}