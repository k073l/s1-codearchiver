using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.Money;
using ScheduleOne.NPCs.CharacterClasses;
using ScheduleOne.Property;
using ScheduleOne.Variables;
using UnityEngine;

namespace ScheduleOne.Dialogue;
public class DialogueController_Fixer : DialogueController
{
    private EEmployeeType selectedEmployeeType;
    private ScheduleOne.Property.Property selectedProperty;
    private bool lastConfirmationWasInitial;
    public override void ChoiceCallback(string choiceLabel);
    public override void ModifyChoiceList(string dialogueLabel, ref List<DialogueChoiceData> existingChoices);
    public override bool CheckChoice(string choiceLabel, out string invalidReason);
    public override string ModifyDialogueText(string dialogueLabel, string dialogueText);
    public override bool DecideBranch(string branchLabel, out int index);
    private void Confirm();
}