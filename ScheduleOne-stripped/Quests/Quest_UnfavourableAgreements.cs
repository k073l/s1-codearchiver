using System;
using System.Collections;
using FishNet;
using ScheduleOne.Cartel;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.GameTime;
using ScheduleOne.Map;
using ScheduleOne.NPCs.CharacterClasses;
using ScheduleOne.Vehicles;
using ScheduleOne.Vehicles.AI;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Quests;
public class Quest_UnfavourableAgreements : Quest
{
    public LandVehicle MeetingVehicle;
    public ParkingLot MeetingParkingLot;
    public ParkingLot ManorParkingLot;
    public Thomas Thomas;
    public QuestEntry ReadMessageQuestEntry;
    public QuestEntry MeetingQuestEntry;
    public Quest PrereqQuest;
    public UnityEvent onMeetingConcluded;
    protected override void Awake();
    protected override void Start();
    private void CheckQuestStart();
    public override void Begin(bool network = true);
    protected override void MinPass();
    public override void SetQuestState(EQuestState state, bool network = true);
    private void MeetingEnded();
    private void DriveCallback(VehicleAgent.ENavigationResult result);
    private void Park();
}