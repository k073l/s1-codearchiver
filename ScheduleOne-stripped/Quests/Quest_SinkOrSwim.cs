using System;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Persistence;
using ScheduleOne.UI;
using ScheduleOne.Variables;
using ScheduleOne.Vehicles;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Quests;
public class Quest_SinkOrSwim : Quest
{
    public const int DAYS_TO_COMPLETE;
    public string QuestName;
    public int NelsonCallTime;
    public Transform LoanSharkVehiclePosition;
    public GameObject LoanSharkGraves;
    protected override void Awake();
    protected override void Start();
    protected override void MinPass();
    private void HourPass();
    private void SleepStart();
    private void SpawnLoanSharkVehicle();
    private void CheckArrival();
    public override void SetQuestState(EQuestState state, bool network = true);
    private void UpdateName();
}