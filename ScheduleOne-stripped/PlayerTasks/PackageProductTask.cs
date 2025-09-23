using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Packaging;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.Product.Packaging;
using ScheduleOne.UI;
using ScheduleOne.UI.Stations;
using UnityEngine;

namespace ScheduleOne.PlayerTasks;
public class PackageProductTask : Task
{
    protected PackagingStation station;
    protected FunctionalPackaging Packaging;
    protected List<FunctionalProduct> Products;
    public override string TaskName { get; protected set; } = "Package product";

    public PackageProductTask(PackagingStation _station);
    public override void StopTask();
    public override void Success();
    private void FullyPacked();
    private void Sealed();
    private void ReachedOutput();
}