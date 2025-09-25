using System;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Variables;

namespace ScheduleOne.Quests;
public class Quest_DownToBusiness : Quest
{
    protected override void Awake();
    protected override void Start();
    private void DayPass();
}