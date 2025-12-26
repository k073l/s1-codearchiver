using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class MushroomSpawnEquipped : Equippable_Viewmodel
{
    private const float InteractionRange;
    [SerializeField]
    private GameObject _taskPrefab;
    [SerializeField]
    private string InteractionLabel { get; set; } = "Add mushroom spawn";

    protected override void Update();
    protected virtual bool CanApplyToMushroomBed(MushroomBed bed, out string reason);
    protected void StartTask(MushroomBed growContainer);
}