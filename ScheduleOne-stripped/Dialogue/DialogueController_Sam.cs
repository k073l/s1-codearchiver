using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using ScheduleOne.Quests;
using UnityEngine;

namespace ScheduleOne.Dialogue;
public class DialogueController_Sam : DialogueController
{
    private Quest_DefeatCartel questDefeatCartel;
    protected override void Start();
    public override bool CheckChoice(string choiceLabel, out string invalidReason);
    public override string ModifyDialogueText(string dialogueLabel, string dialogueText);
    public override void ChoiceCallback(string choiceLabel);
}