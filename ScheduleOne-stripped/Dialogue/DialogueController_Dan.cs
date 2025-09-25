using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Dialogue;
public class DialogueController_Dan : DialogueController
{
    public ItemDefinition ItemToGive;
    protected override void Start();
    public override string ModifyDialogueText(string dialogueLabel, string dialogueText);
}