using ScheduleOne.DevUtilities;
using ScheduleOne.Growing;
using ScheduleOne.Interaction;
using ScheduleOne.Management;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.PlayerTasks.Tasks;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class Equippable_Pourable : Equippable_Viewmodel
{
    private const float InteractionRange;
    [SerializeField]
    public Pourable PourablePrefab;
    [field: SerializeField]
    public string InteractionLabel { get; set; } = "Pour";

    protected virtual void Awake();
    protected override void Update();
    protected virtual void StartPourTask(GrowContainer growContainer);
    protected virtual bool CanPour(GrowContainer growContainer, out string reason);
}