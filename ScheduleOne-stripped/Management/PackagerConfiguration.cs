using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Employees;
using ScheduleOne.EntityFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Packaging;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class PackagerConfiguration : EntityConfiguration
{
    public ObjectField Home;
    public ObjectListField Stations;
    public RouteListField Routes;
    public List<PackagingStation> AssignedStations;
    public List<BrickPress> AssignedBrickPresses;
    public int AssignedStationCount => AssignedStations.Count + AssignedBrickPresses.Count;
    public Packager packager { get; protected set; }
    public EmployeeHome assignedHome { get; private set; }

    public PackagerConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, Packager _botanist);
    public override void Reset();
    private bool IsStationValid(BuildableItem obj, out string reason);
    public void AssignedStationsChanged(List<BuildableItem> objects);
    public override bool ShouldSave();
    public override string GetSaveString();
    private void HomeChanged(BuildableItem newItem);
}