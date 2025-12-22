using ScheduleOne.DevUtilities;
using ScheduleOne.Growing;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.PlayerTasks.Tasks;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class Equippable_SprayBottle : Equippable_Viewmodel
{
    private const float InteractionRange;
    [SerializeField]
    private GameObject _sprayablePrefab;
    private WaterContainerInstance _waterContainerInstance;
    [SerializeField]
    private string InteractionLabel { get; set; } = "Spray";

    protected override void Update();
    protected virtual bool CanSpray(GrowContainer growContainer, out string reason);
    protected void StartSprayTask(MushroomBed growContainer);
}