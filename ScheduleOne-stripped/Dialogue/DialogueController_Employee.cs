using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.Property;
using UnityEngine;

namespace ScheduleOne.Dialogue;
public class DialogueController_Employee : DialogueController
{
    private ScheduleOne.Property.Property selectedProperty;
    private void Awake();
    public override void ChoiceCallback(string choiceLabel);
    public override void ModifyChoiceList(string dialogueLabel, ref List<DialogueChoiceData> existingChoices);
    private List<DialogueChoiceData> GetChoices();
    private ScheduleOne.Property.Property GetPropertyByCode(string code);
    public override bool CheckChoice(string choiceLabel, out string invalidReason);
    public override string ModifyDialogueText(string dialogueLabel, string dialogueText);
}