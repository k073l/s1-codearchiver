using System;
using System.Collections;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Map;
using ScheduleOne.Misc;
using ScheduleOne.NPCs.CharacterClasses;
using ScheduleOne.PlayerScripts;
using ScheduleOne.ScriptableObjects;
using ScheduleOne.UI;
using ScheduleOne.UI.Phone;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Quests;
public class Quest_TheDeepEnd : Quest
{
    public const float MEETING_REMINDER_TIME;
    public const float KIDNAP_TIME;
    private bool kidnapQueued;
    private bool meetingSetup;
    public Thomas Thomas;
    public ManorGate Gate;
    public ModularSwitch Switch;
    public Transform MeetingTeleportPoint;
    public PhoneCallData PostMeetingCall;
    public SystemTriggerObject PostMeetingTrigger;
    protected override void Start();
    public override void Begin(bool network = true);
    public void SetupFirstMeeting();
    private void ThomasDialogueNodeDisplayed(string nodeLabel);
    private void HourPass();
    private void BeforeSleep();
    private void SleepFadeOut();
    public override void SetQuestEntryState(int entryIndex, EQuestState state, bool network = true);
}