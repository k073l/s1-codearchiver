using System;
using FishNet;
using ScheduleOne.Economy;
using ScheduleOne.NPCs.Relation;

namespace ScheduleOne.Quests;
public class Quest_GrowShrooms : Quest
{
    public Supplier ShroomSupplier;
    protected override void Start();
    private void SupplierUnlocked(NPCRelationData.EUnlockType unlockType, bool notify);
}