using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs.CharacterClasses;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Property;
using ScheduleOne.UI.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScheduleOne.Quests;
public class Quest_WelcomeToHylandPoint : Quest
{
    public QuestEntry ReturnToRVQuest;
    public QuestEntry ReadMessagesQuest;
    public RV RV;
    public UncleNelson Nelson;
    [Header("Settings")]
    public float ExplosionMaxDist;
    public float ExplosionMinDist;
    private float cameraLookTime;
    protected override void OnUncappedMinPass();
    private void Update();
    public override void SetQuestState(EQuestState state, bool network = true);
    public void BlowupRV();
    public void SetRVDestroyed();
}