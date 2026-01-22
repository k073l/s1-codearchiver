using System.Collections.Generic;
using ScheduleOne.Economy;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Quests;
public class DeaddropQuest : Quest
{
    public static List<DeaddropQuest> DeaddropQuests;
    public DeadDrop Drop { get; private set; }

    public override void Begin(bool network = true);
    public void SetDrop(DeadDrop drop);
    protected override void OnMinPass();
    private void OnDestroy();
    public override void End();
    public override void SetQuestState(EQuestState state, bool network = true);
    public override bool ShouldSave();
    public override SaveData GetSaveData();
}