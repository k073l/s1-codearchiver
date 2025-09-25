using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Quests;
using UnityEngine;

namespace ScheduleOne.Dialogue;
public class DialogueController_Billy : DialogueController
{
    private Quest_DefeatCartel questDefeatCartel;
    protected override void Start();
    public override string ModifyDialogueText(string dialogueLabel, string dialogueText);
}