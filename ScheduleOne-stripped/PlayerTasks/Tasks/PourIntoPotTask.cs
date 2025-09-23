using System;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Trash;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks.Tasks;
public class PourIntoPotTask : Task
{
    protected Pot pot;
    protected ItemInstance item;
    protected Pourable pourable;
    protected bool removeItemAfterInitialPour;
    public override string TaskName { get; protected set; } = "Pour";
    protected virtual bool UseCoverage { get; }
    protected virtual bool FailOnEmpty { get; } = true;
    protected virtual Pot.ECameraPosition CameraPosition { get; } = Pot.ECameraPosition.Midshot;

    public PourIntoPotTask(Pot _pot, ItemInstance _itemInstance, Pourable _pourablePrefab);
    public override void Update();
    public override void StopTask();
    private void OnInitialPour();
    protected void RemoveItem();
    protected virtual void FullyCovered();
}