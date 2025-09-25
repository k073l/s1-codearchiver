using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.NPCs;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.StationFramework;
using ScheduleOne.UI.Stations;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class ChemistryStationConfiguration : EntityConfiguration
{
    public NPCField AssignedChemist;
    public StationRecipeField Recipe;
    public ObjectField Destination;
    public ChemistryStation Station { get; protected set; }
    public TransitRoute DestinationRoute { get; protected set; }

    public ChemistryStationConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, ChemistryStation station);
    public override void Reset();
    private void DestinationChanged(BuildableItem item);
    public bool DestinationFilter(BuildableItem obj, out string reason);
    public override void Selected();
    public override void Deselected();
    public override bool ShouldSave();
    public override string GetSaveString();
}