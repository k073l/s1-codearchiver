using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using ScheduleOne.Property;
using UnityEngine;

namespace ScheduleOne.Dialogue;
public class DialogueHandler_EstateAgent : ControlledDialogueHandler
{
    private ScheduleOne.Property.Property selectedProperty;
    private Business selectedBusiness;
    public override bool CheckChoice(string choiceLabel, out string invalidReason);
    public override bool ShouldChoiceBeShown(string choiceLabel);
    protected override void ChoiceCallback(string choiceLabel);
    protected override void DialogueCallback(string choiceLabel);
    protected override string ModifyDialogueText(string dialogueLabel, string dialogueText);
    protected override string ModifyChoiceText(string choiceLabel, string choiceText);
}