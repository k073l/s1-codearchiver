using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class Equippable_Trimmers : Equippable_Viewmodel
{
    public bool CanClickAndDrag;
    public AudioSourceController SoundLoopPrefab;
    protected override void Update();
}