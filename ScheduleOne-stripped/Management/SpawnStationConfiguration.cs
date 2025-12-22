using ScheduleOne.Employees;
using ScheduleOne.EntityFramework;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.StationFramework;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class SpawnStationConfiguration : EntityConfiguration
{
    public NPCField AssignedBotanist;
    public ObjectField Destination;
    public MushroomSpawnStation Station { get; protected set; }
    public TransitRoute DestinationRoute { get; protected set; }

    public SpawnStationConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, MushroomSpawnStation station);
    public override void Reset();
    private void DestinationChanged(BuildableItem item);
    public bool DestinationFilter(BuildableItem obj, out string reason);
    public override void Selected();
    public override void Deselected();
    public override bool ShouldSave();
    public override string GetSaveString();
}