using System;
using System.Collections;
using ScheduleOne.Cartel;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs.CharacterClasses;
using UnityEngine;

namespace ScheduleOne.Dialogue;
public class DialogueController_ThomasBenzies : DialogueController
{
    public override void ChoiceCallback(string choiceLabel);
    private void WaitForConversationEnd();
}