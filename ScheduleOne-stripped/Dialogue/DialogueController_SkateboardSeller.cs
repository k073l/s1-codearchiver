using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Dialogue;
public class DialogueController_SkateboardSeller : DialogueController
{
    [Serializable]
    public class Option
    {
        public string Name;
        public float Price;
        public bool IsAvailable;
        public string NotAvailableReason;
        public ItemDefinition Item;
    }

    public List<Option> Options;
    private Option chosenWeapon;
    public UnityEvent onPurchase;
    private void Awake();
    public override void ChoiceCallback(string choiceLabel);
    public override void ModifyChoiceList(string dialogueLabel, ref List<DialogueChoiceData> existingChoices);
    private List<DialogueChoiceData> GetChoices(List<Option> options);
    public override bool CheckChoice(string choiceLabel, out string invalidReason);
    public override string ModifyDialogueText(string dialogueLabel, string dialogueText);
}