using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.VoiceOver;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Dialogue;
public class DialogueHandler : MonoBehaviour
{
    public const float TimePerChar;
    public const float WorldspaceDialogueMinDuration;
    public const float WorldspaceDialogueMaxDuration;
    public static DialogueContainer activeDialogue;
    public static DialogueNodeData activeDialogueNode;
    public DialogueDatabase Database;
    [Header("References")]
    public Transform LookPosition;
    public WorldspaceDialogueRenderer WorldspaceRend;
    public VOEmitter VOEmitter;
    [HideInInspector]
    public List<DialogueChoiceData> CurrentChoices;
    [Header("Events")]
    public DialogueEvent[] DialogueEvents;
    public UnityEvent onConversationStart;
    public UnityEvent<string> onDialogueNodeDisplayed;
    public UnityEvent<string> onDialogueChoiceChosen;
    [SerializeField]
    protected List<DialogueContainer> dialogueContainers;
    protected string overrideText;
    protected List<NodeLinkData> tempLinks;
    protected bool skipNextDialogueBehaviourEnd;
    protected List<DialogueChoiceData> finalChoices;
    private bool passChecked;
    public bool IsDialogueInProgress { get; private set; }
    public List<DialogueModule> runtimeModules { get; private set; } = new List<DialogueModule>();
    public NPC NPC { get; protected set; }
    protected DialogueCanvas canvas => Singleton<DialogueCanvas>.Instance;

    protected virtual void Awake();
    protected virtual void Start();
    public void InitializeDialogue(DialogueContainer container);
    public void InitializeDialogue(DialogueContainer dialogueContainer, bool enableDialogueBehaviour = true, string entryNodeLabel = "ENTRY");
    public void InitializeDialogue(string dialogueContainerName, bool enableDialogueBehaviour = true, string entryNodeLabel = "ENTRY");
    public virtual bool CanBeginConversation();
    public void OverrideShownDialogue(string _overrideText);
    public void StopOverride();
    public virtual void EndDialogue();
    public void SkipNextDialogueBehaviourEnd();
    protected virtual DialogueNodeData FinalizeDialogueNode(DialogueNodeData data);
    public void ShowNode(DialogueNodeData node);
    private void EvaluateBranch(BranchNodeData node);
    public void ChoiceSelected(int choiceIndex);
    public void ContinueSubmitted();
    public virtual bool CheckChoice(string choiceLabel, out string invalidReason);
    public virtual bool ShouldChoiceBeShown(string choiceLabel);
    protected virtual int CheckBranch(string branchLabel);
    protected virtual string ModifyDialogueText(string dialogueLabel, string dialogueText);
    protected virtual string ModifyChoiceText(string choiceLabel, string choiceText);
    protected virtual void ChoiceCallback(string choiceLabel);
    protected virtual void DialogueCallback(string dialogueLabel);
    protected virtual void ModifyChoiceList(string dialogueLabel, ref List<DialogueChoiceData> existingChoices);
    protected void CreateTempLink(string baseNodeGUID, string baseOptionGUID, string targetNodeGUID);
    private NodeLinkData GetLink(string baseChoiceOrOptionGUID);
    public virtual void Hovered();
    public virtual void Interacted();
    public virtual void PlayReaction_Local(string key);
    public virtual void PlayReaction_Networked(string key);
    public virtual void PlayReaction(string key, float duration, bool network);
    public virtual void HideWorldspaceDialogue();
    public virtual void ShowWorldspaceDialogue(string text, float duration);
    public virtual void ShowWorldspaceDialogue_5s(string text);
}