using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using ScheduleOne.Property;
using ScheduleOne.Quests;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Dialogue;
public class DialogueController_Ming : DialogueController
{
    public ScheduleOne.Property.Property Property;
    public float Price;
    public DialogueContainer BuyDialogue;
    public string BuyText;
    public string RemindText;
    public DialogueContainer RemindLocationDialogue;
    public QuestEntry[] PurchaseRoomQuests;
    public UnityEvent onPurchase;
    protected override void Start();
    private bool CanBuyRoom(bool enabled);
    public override string ModifyChoiceText(string choiceLabel, string choiceText);
    public override string ModifyDialogueText(string dialogueLabel, string dialogueText);
    public override bool CheckChoice(string choiceLabel, out string invalidReason);
    public override void ChoiceCallback(string choiceLabel);
}