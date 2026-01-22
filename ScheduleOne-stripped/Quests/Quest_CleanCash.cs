using FishNet;
using ScheduleOne.Money;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Property;
using UnityEngine;

namespace ScheduleOne.Quests;
public class Quest_CleanCash : Quest
{
    public QuestEntry BuyBusinessEntry;
    public QuestEntry GoToBusinessEntry;
    protected override void OnMinPass();
}