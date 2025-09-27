using ScheduleOne.Employees;
using ScheduleOne.EntityFramework;
using ScheduleOne.NPCs;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class CauldronConfiguration : EntityConfiguration
{
    public NPCField AssignedChemist;
    public ObjectField Destination;
    public Cauldron Station { get; protected set; }
    public TransitRoute DestinationRoute { get; protected set; }

    public CauldronConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, Cauldron cauldron);
    public override void Reset();
    private void DestinationChanged(BuildableItem item);
    public bool DestinationFilter(BuildableItem obj, out string reason);
    public override void Selected();
    public override void Deselected();
    public override bool ShouldSave();
    public override string GetSaveString();
}