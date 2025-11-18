using ScheduleOne.Cartel;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.Quests;
public class Quest_DealForCartel : Quest
{
    public QuestEntry MainEntry;
    public QuestEntry EndTruceEntry;
    private CartelDealInfo dealInfo;
    public void Initialize(CartelDealInfo dealInfo);
    public override void Begin(bool network = true);
    protected override void MinPass();
    private void UpdateTimingLabel();
    public void NotifyDealCompleted();
    public void NotifyTruceEnded();
}