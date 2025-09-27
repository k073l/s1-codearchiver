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
public class PackageProductTaskMk2 : Task
{
    protected PackagingStationMk2 station;
    protected FunctionalPackaging Packaging;
    protected List<FunctionalProduct> Products;
    public override string TaskName { get; protected set; } = "Package product";

    public PackageProductTaskMk2(PackagingStationMk2 _station);
    public override void StopTask();
}