using System;
using FishNet;
using ScheduleOne.Audio;
using ScheduleOne.Cartel;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Map;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.CharacterClasses;
using ScheduleOne.Property;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Quests;
public class Quest_DefeatCartel : Quest
{
    public const float DIG_TUNNEL_COST;
    [Header("References")]
    public Sam Sam;
    public Manor Manor;
    public QuestEntry DigTunnelEntry;
    public QuestEntry WaitForTunnelEntry;
    public QuestEntry EnquireAboutRDXEntry;
    public QuestEntry ObtainRDXEntry;
    public QuestEntry EnquireAboutBombEntry;
    public QuestEntry KillBanditEntry;
    public NPC Bandit;
    public GameObject BanditScheduleContainer;
    protected override void Start();
    private void OnSleepEnd();
    protected override void OnMinPass();
    public override void SetQuestEntryState(int entryIndex, EQuestState state, bool network = true);
    public void PlayCountdownMusic();
    private void Defeat();
    public override void SetQuestState(EQuestState state, bool network = true);
}