using System;
using FishNet.Object;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Trash;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks.Tasks;
public class GrowContainerPourTask : Task
{
    protected GrowContainer growContainer;
    protected ItemInstance item;
    protected Pourable pourable;
    protected bool removeItemAfterInitialPour;
    public override string TaskName { get; protected set; } = "Pour";
    protected virtual bool UseCoverage { get; }
    protected virtual bool FailOnEmpty { get; } = true;
    protected virtual GrowContainerCameraHandler.ECameraPosition CameraPosition { get; } = GrowContainerCameraHandler.ECameraPosition.Midshot;

    public GrowContainerPourTask(GrowContainer _growContainer, ItemInstance _itemInstance, Pourable _pourablePrefab);
    public override void Update();
    public override void StopTask();
    protected virtual void OnInitialPour();
    protected void RemoveItem();
    protected virtual void FullyCovered();
}