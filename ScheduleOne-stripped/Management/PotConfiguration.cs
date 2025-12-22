using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.EntityFramework;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.NPCs;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class PotConfiguration : EntityConfiguration
{
    public ItemField Seed;
    public ItemField Additive1;
    public ItemField Additive2;
    public ItemField Additive3;
    public NPCField AssignedBotanist;
    public ObjectField Destination;
    public Pot Pot { get; protected set; }
    public TransitRoute DestinationRoute { get; protected set; }

    public PotConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, Pot pot);
    public bool IsAdditiveSelected(ItemDefinition additive);
    public string[] GetSelectedSeedIDs();
    public override void Reset();
    private void DestinationChanged(BuildableItem item);
    public bool DestinationFilter(BuildableItem obj, out string reason);
    public override void Selected();
    public override void Deselected();
    public override bool ShouldSave();
    public override string GetSaveString();
}