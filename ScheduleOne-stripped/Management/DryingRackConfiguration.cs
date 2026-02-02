using ScheduleOne.Employees;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.NPCs;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class DryingRackConfiguration : EntityConfiguration
{
    public NPCField AssignedBotanist;
    public QualityField TargetQuality;
    public NumberField StartThreshold;
    public ObjectField Destination;
    public DryingRack Rack { get; protected set; }
    public TransitRoute DestinationRoute { get; protected set; }

    public DryingRackConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, DryingRack rack);
    public override void Reset();
    private void DestinationChanged(BuildableItem item);
    public bool DestinationFilter(BuildableItem obj, out string reason);
    public override void Selected();
    public override void Deselected();
    public override bool ShouldSave();
    public override string GetSaveString();
}