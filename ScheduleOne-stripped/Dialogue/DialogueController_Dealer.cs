using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.Money;
using UnityEngine;

namespace ScheduleOne.Dialogue;
public class DialogueController_Dealer : DialogueController
{
    public Dealer Dealer { get; private set; }

    protected override void Start();
    public override string ModifyDialogueText(string dialogueLabel, string dialogueText);
    public override string ModifyChoiceText(string choiceLabel, string choiceText);
    public override bool CheckChoice(string choiceLabel, out string invalidReason);
    public override void ChoiceCallback(string choiceLabel);
}