using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks.Tasks;
public class MistMushroomBedTask : Task
{
    private const float TARGET_SPRAY_RADIUS;
    private const float TARGET_SPRAY_DISTANCE;
    private MushroomBed _mushroomBed;
    private Sprayable _sprayable;
    private GameObject _sprayableObj;
    private WaterContainerInstance _waterContainerInstance;
    public override string TaskName { get; protected set; } = "Mist";

    public MistMushroomBedTask(MushroomBed mushroomBed, ItemInstance item, GameObject sprayablePrefab);
    private void OnSuccessfulSpray();
    private void OnSpray();
    public override void StopTask();
}