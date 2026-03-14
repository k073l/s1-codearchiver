using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class DialogueCanvas : Singleton<DialogueCanvas>
{
    public const float TIME_PER_CHAR;
    public bool SkipNextRollout;
    [Header("References")]
    [SerializeField]
    protected Canvas canvas;
    public RectTransform Container;
    [SerializeField]
    protected TextMeshProUGUI dialogueText;
    [SerializeField]
    protected GameObject continuePopup;
    [SerializeField]
    protected List<DialogueChoiceEntry> dialogueChoices;
    [Header("Custom UI")]
    [SerializeField]
    protected UIScreen uiScreen;
    [SerializeField]
    protected UIPanel uiPanel;
    private DialogueHandler currentHandler;
    private DialogueNodeData currentNode;
    private bool spaceDownThisFrame;
    private bool leftClickThisFrame;
    private string overrideText;
    private Coroutine dialogueRollout;
    private Coroutine choiceSelectionResidualCoroutine;
    private bool hasChoiceBeenSelected;
    public bool isActive => (Object)(object)currentHandler != (Object)null;

    protected override void Awake();
    public void DisplayDialogueNode(DialogueHandler diag, DialogueNodeData node, string dialogueText, List<DialogueChoiceData> choices);
    public void OverrideText(string text);
    public void StopTextOverride();
    private void Update();
    private void Exit(ExitAction action);
    protected IEnumerator RolloutDialogue(string text, List<DialogueChoiceData> choices);
    private IEnumerator SelectPanel(UISelectable selectable);
    private IEnumerator ChoiceSelectionResidual(DialogueChoiceEntry choice, float fadeTime);
    private void StartDialogue(DialogueHandler handler);
    public void EndDialogue();
    private IEnumerator UnlockPlayer();
    public void ChoiceSelected(int choiceIndex);
    private bool IsChoiceValid(int choiceIndex, out string reason);
}