using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.NPCs.Relation;
using ScheduleOne.PlayerScripts;

namespace ScheduleOne.Dialogue;
public class DialogueController_Jen : DialogueController
{
    public string BuyKeyText;
    public StorableItemDefinition KeyItem;
    public DialogueContainer BuyKeyDialogue;
    public float MinRelationToBuyKey;
    protected override void Start();
    private bool CanBuyKey(out string invalidReason);
    public override string ModifyChoiceText(string choiceLabel, string choiceText);
    public override string ModifyDialogueText(string dialogueLabel, string dialogueText);
    public override bool CheckChoice(string choiceLabel, out string invalidReason);
    public override void ChoiceCallback(string choiceLabel);
}