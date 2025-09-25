using FishNet.Object;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Police;
using ScheduleOne.Vehicles;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.Dialogue;
public class DialogueHandler_Police : ControlledDialogueHandler
{
    [Header("References")]
    public DialogueContainer CheckpointRequestDialogue;
    private PoliceOfficer officer;
    protected override void Awake();
    public override void Hovered();
    public override void Interacted();
    private bool CanTalk_Checkpoint();
    protected override int CheckBranch(string branchLabel);
}