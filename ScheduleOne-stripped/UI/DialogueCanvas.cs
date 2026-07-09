using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class DialogueCanvas : Singleton<DialogueCanvas>
{
    private const float TimePerChar;
    [Header("References")]
    [SerializeField]
    protected Canvas canvas;
    [SerializeField]
    protected RectTransform Container;
    [SerializeField]
    protected TextMeshProUGUI dialogueText;
    [SerializeField]
    protected GameObject continuePopup;
    [SerializeField]
    protected List<DialogueChoiceEntry> dialogueChoices;
    [SerializeField]
    protected MonoState state;
    [SerializeField]
    protected InputActionReference[] continueActions;
    [Header("Custom UI")]
    [SerializeField]
    protected UIScreen uiScreen;
    [SerializeField]
    protected UIPanel uiPanel;
    private DialogueHandler currentHandler;
    private DialogueNodeData currentNode;
    private Coroutine dialogueRoutine;
    private bool _continuePressed;
    private bool hasChoiceBeenSelected;
    private Coroutine choiceSelectionResidualCoroutine;
    public bool IsOpen => (Object)(object)currentHandler != (Object)null;
    public bool SkipNextRollout { get; set; }

    protected override void Awake();
    public void DisplayDialogueNode(DialogueHandler diag, DialogueNodeData node, string dialogueText, List<DialogueChoiceData> choices);
    private void Update();
    private void Exit(ExitAction action);
    protected IEnumerator RolloutDialogue(string text, List<DialogueChoiceData> choices);
    private IEnumerator SelectPanel(UISelectable selectable);
    private IEnumerator ChoiceSelectionResidual(DialogueChoiceEntry choice, float fadeTime);
    private void StartDialogue(DialogueHandler handler);
    private void OnStateDeactivated();
    private void OnClose();
    private void ChoiceSelected(int choiceIndex);
    private bool IsChoiceValid(int choiceIndex, out string reason);
}