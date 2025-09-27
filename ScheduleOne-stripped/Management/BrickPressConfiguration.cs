using ScheduleOne.Employees;
using ScheduleOne.EntityFramework;
using ScheduleOne.NPCs;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class BrickPressConfiguration : EntityConfiguration
{
    public NPCField AssignedPackager;
    public ObjectField Destination;
    public BrickPress BrickPress { get; protected set; }
    public TransitRoute DestinationRoute { get; protected set; }

    public BrickPressConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, BrickPress station);
    public override void Reset();
    private void DestinationChanged(BuildableItem item);
    public bool DestinationFilter(BuildableItem obj, out string reason);
    public override void Selected();
    public override void Deselected();
    public override bool ShouldSave();
    public override string GetSaveString();
}