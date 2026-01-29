using ScheduleOne.Economy;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Quests;
public class Quest_GearingUp : Quest
{
    public QuestEntry WaitForDropEntry;
    public QuestEntry CollectDropEntry;
    public Supplier Supplier;
    private bool setCollectionPosition;
    protected override void Start();
    protected override void OnUncappedMinPass();
    private void DropReady();
}