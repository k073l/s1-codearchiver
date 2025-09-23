using System;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.Growing;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Trash;
using ScheduleOne.UI;
using ScheduleOne.Variables;
using UnityEngine;

namespace ScheduleOne.PlayerTasks;
public class SowSeedTask : Task
{
    protected Pot pot;
    protected SeedDefinition definition;
    protected FunctionalSeed seed;
    private bool seedExitedVial;
    private bool seedReachedDestination;
    private bool successfullyPlanted;
    private float weedSeedStationaryTime;
    private bool capRemoved;
    public override string TaskName { get; protected set; } = "Sow seed";

    public SowSeedTask(Pot _pot, SeedDefinition def);
    public override void Update();
    public override void Success();
    public override void StopTask();
    private void OnSeedExitVial();
    private void OnSeedReachedDestination();
}