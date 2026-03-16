using ScheduleOne.Equipping;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerTasks.Tasks;
using UnityEngine;

namespace ScheduleOne.ObjectScripts.Soil;
public class Equippable_Soil : Equippable_Pourable
{
    protected override bool CanPour(GrowContainer growContainer, out string reason);
    protected override void StartPourTask(GrowContainer growContainer);
}