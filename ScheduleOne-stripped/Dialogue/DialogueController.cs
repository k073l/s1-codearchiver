using System;
using System.Collections.Generic;
using ScheduleOne.Core.Weather;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Interaction;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tools;
using ScheduleOne.VoiceOver;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace ScheduleOne.Dialogue;
public class DialogueController : MonoBehaviour
{
    [Serializable]
    public class DialogueChoice
    {
        public delegate bool ShouldShowCheck(bool enabled);
        public delegate bool IsChoiceValid(out string invalidReason);
        public bool Enabled;
        public string ChoiceText;
        public bool ShowWorldspaceDialogue;
        public Conversation Conversation;
        public UnityEvent onChoosen;
        public ShouldShowCheck shouldShowCheck;
        public IsChoiceValid isValidCheck;
        public int Priority;
        public bool ShouldShow();
        public bool IsValid(out string invalidReason);
    }

    [Serializable]
    public class GreetingOverride
    {
        public string Greeting;
        public bool ShouldShow;
        public bool PlayVO;
        public EVOLineType VOType;
    }

    private const float GreetingCooldown;
    private const float RainyGreetingThreshold;
    private const float RainyGreetingChance;
    [Header("References")]
    [SerializeField]
    [FormerlySerializedAs("IntObj")]
    private InteractableObject _interactable;
    [Header("Settings")]
    public bool DialogueEnabled;
    public bool UseDialogueBehaviour;
    public List<DialogueChoice> Choices;
    public List<GreetingOverride> GreetingOverrides;
    public Conversation OverrideContainer;
    protected NPC npc;
    protected DialogueHandler handler;
    private float _lastGreetingTime;
    private List<DialogueChoice> _shownChoices;
    private string _cachedGreeting;
    private Action<string> _onChoiceSelectedEvent;
    private float _timeOnDialogueStart;
    private float _remainingInteractionCooldown;
    private Conversation _genericConversation => Singleton<DialogueManager>.Instance.GenericConversation;

    protected virtual void Start();
    private void Update();
    private void Hovered();
    public void StartGenericDialogue(bool allowExit = true);
    private void Interacted();
    private string GetActiveGreeting(out bool playVO, out EVOLineType voLineType);
    private List<DialogueChoice> GetActiveChoices();
    protected virtual bool GetCustomGreeting(out string greeting, out bool playVO, out EVOLineType voLineType);
    public virtual int AddDialogueChoice(DialogueChoice data, int priority = 0);
    public virtual int AddGreetingOverride(GreetingOverride data);
    public virtual bool CanStartDialogue();
    public void SetCooldown(float cooldown);
    public virtual string ModifyDialogueText(string dialogueLabel, string dialogueText);
    public virtual string ModifyChoiceText(string choiceLabel, string choiceText);
    public virtual void ModifyChoiceList(string dialogueLabel, ref List<DialogueChoiceData> existingChoices);
    public virtual void ChoiceCallback(string choiceLabel);
    public virtual bool CheckChoice(string choiceLabel, out string invalidReason);
    public void SetOverrideContainer(Conversation container);
    public void ClearOverrideContainer();
    public virtual bool DecideBranch(string branchLabel, out int index);
    public void SetDialogueEnabled(bool enabled);
    public void SubscribeToChoiceSelected(Action<string> callback);
    public void UnsubscribeFromChoiceSelected(Action<string> callback);
}