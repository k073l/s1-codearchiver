using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Property;
using ScheduleOne.Tools;
using UnityEngine;

namespace ScheduleOne.PlayerTasks;
public class FillWaterContainer : Task
{
    private Tap _tap;
    private WaterContainerInstance _waterContainerItem;
    private FillableWaterContainer _fillable;
    public new string TaskName { get; protected set; } = "Fill watering can";

    public FillWaterContainer(Tap tap, WaterContainerInstance waterContainerItem);
    public override void StopTask();
    public override void Update();
    private void UpdateInstruction();
    private void UpdateFillSound();
}