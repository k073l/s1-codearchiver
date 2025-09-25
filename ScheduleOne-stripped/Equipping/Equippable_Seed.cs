using ScheduleOne.DevUtilities;
using ScheduleOne.Growing;
using ScheduleOne.Interaction;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class Equippable_Seed : Equippable_Viewmodel
{
    public SeedDefinition Seed;
    protected override void Update();
    protected virtual void StartSowSeedTask(Pot pot);
}