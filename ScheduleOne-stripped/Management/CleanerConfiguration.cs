using System.Collections.Generic;
using ScheduleOne.Employees;
using ScheduleOne.EntityFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class CleanerConfiguration : EntityConfiguration
{
    public ObjectField Home;
    public ObjectListField Bins;
    public Cleaner cleaner { get; protected set; }
    public List<TrashContainerItem> binItems { get; private set; } = new List<TrashContainerItem>();
    public EmployeeHome assignedHome { get; private set; }

    public CleanerConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, Cleaner _cleaner);
    public override void Reset();
    private bool IsObjValid(BuildableItem obj, out string reason);
    public void AssignedBinsChanged(List<BuildableItem> objects);
    public override bool ShouldSave();
    public override string GetSaveString();
    private void HomeChanged(BuildableItem newItem);
}