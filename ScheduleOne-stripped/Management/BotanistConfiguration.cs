using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Employees;
using ScheduleOne.EntityFramework;
using ScheduleOne.NPCs;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.StationFramework;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class BotanistConfiguration : EntityConfiguration
{
    public static readonly Type[] AssignableTypes;
    public ObjectField Home;
    public ObjectField Supplies;
    public ObjectListField Assigns;
    private List<BuildableItem> _thisBotanistAssignedOn;
    private Botanist _botanist;
    public List<Pot> AssignedPots { get; private set; } = new List<Pot>();
    public List<DryingRack> AssignedRacks { get; private set; } = new List<DryingRack>();
    public List<MushroomBed> AssignedBeds { get; private set; } = new List<MushroomBed>();
    public List<MushroomSpawnStation> AssignedSpawnStations { get; private set; } = new List<MushroomSpawnStation>();
    public EmployeeHome AssignedHome { get; private set; }

    public override bool AllowRename();
    public BotanistConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, Botanist _botanist);
    public override void Reset();
    private bool IsStationValid(BuildableItem obj, out string reason);
    public void AssignsChanged(List<BuildableItem> objects);
    private NPCField GetNPCField(IConfigurable configurable);
    public override bool ShouldSave();
    public override string GetSaveString();
    private void HomeChanged(BuildableItem newItem);
}