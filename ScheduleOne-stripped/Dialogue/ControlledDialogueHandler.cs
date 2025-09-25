using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Dialogue;
public class ControlledDialogueHandler : DialogueHandler
{
    private DialogueController controller;
    protected override void Awake();
    protected override string ModifyDialogueText(string dialogueLabel, string dialogueText);
    protected override string ModifyChoiceText(string choiceLabel, string choiceText);
    protected override void ModifyChoiceList(string dialogueLabel, ref List<DialogueChoiceData> existingChoices);
    protected override void ChoiceCallback(string choiceLabel);
    protected override int CheckBranch(string branchLabel);
    public override bool CheckChoice(string choiceLabel, out string invalidReason);
}