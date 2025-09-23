using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Employees;
using ScheduleOne.EntityFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class BotanistConfiguration : EntityConfiguration
{
    public ObjectField Home;
    public ObjectField Supplies;
    public ObjectListField AssignedStations;
    public List<Pot> AssignedPots;
    public List<DryingRack> AssignedRacks;
    public Botanist botanist { get; protected set; }
    public EmployeeHome assignedHome { get; private set; }

    public BotanistConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, Botanist _botanist);
    public override void Reset();
    private bool IsStationValid(BuildableItem obj, out string reason);
    public void AssignedPotsChanged(List<BuildableItem> objects);
    public override bool ShouldSave();
    public override string GetSaveString();
    private void HomeChanged(BuildableItem newItem);
}