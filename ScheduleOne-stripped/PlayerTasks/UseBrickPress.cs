using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Packaging;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.UI;
using ScheduleOne.UI.Stations;
using UnityEngine;

namespace ScheduleOne.PlayerTasks;
public class UseBrickPress : Task
{
    public enum EStep
    {
        Pouring,
        Pressing,
        Complete
    }

    public const float PRODUCT_SCALE;
    protected EStep currentStep;
    protected BrickPress press;
    protected ProductItemInstance product;
    protected List<FunctionalProduct> products;
    protected Draggable container;
    public override string TaskName { get; protected set; } = "Use brick press";

    public UseBrickPress(BrickPress _press, ProductItemInstance _product);
    public override void Update();
    public override void StopTask();
    private void CheckMould();
    private void BeginPress();
    private void FinishPress();
}