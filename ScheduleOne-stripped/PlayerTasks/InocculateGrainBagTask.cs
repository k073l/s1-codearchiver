using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.StationFramework;
using ScheduleOne.UI;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks;
public class InocculateGrainBagTask : Task
{
    public enum EStage
    {
        RemoveCap,
        InsertSyringe,
        PushPlunger
    }

    private MushroomSpawnStation _station;
    private MushroomSpawnStationItem _spawn;
    private SporeSyringeStationItem _syringe;
    private EStage _currentStage;
    private ItemInstance _grainBagInstance;
    private ItemInstance _syringeInstance;
    private ShroomSpawnDefinition _spawnDefinition;
    public override string TaskName { get; protected set; } = "Inocculate grain bag";

    public InocculateGrainBagTask(MushroomSpawnStation station);
    public override void Success();
    public override void StopTask();
    public override void Update();
    private string GetInstructionForStage(EStage stage);
    private void OnSyringeCapRemoved();
    private void OnSyringeInserted();
    private void OnPlungerPushed(float amount);
}