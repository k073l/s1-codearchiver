using System;
using System.Collections.Generic;
using ScheduleOne.Employees;
using ScheduleOne.EntityFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class ChemistConfiguration : EntityConfiguration
{
    public ObjectField Home;
    public ObjectListField Stations;
    public List<ChemistryStation> ChemStations;
    public List<LabOven> LabOvens;
    public List<Cauldron> Cauldrons;
    public List<MixingStation> MixStations;
    public int TotalStations => ChemStations.Count + LabOvens.Count + Cauldrons.Count + MixStations.Count;
    public Chemist chemist { get; protected set; }
    public EmployeeHome assignedHome { get; private set; }

    public ChemistConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, Chemist _chemist);
    public override void Reset();
    private bool IsStationValid(BuildableItem obj, out string reason);
    public void AssignedStationsChanged(List<BuildableItem> objects);
    public override bool ShouldSave();
    public override string GetSaveString();
    private void HomeChanged(BuildableItem newItem);
}