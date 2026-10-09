using System.Collections.Generic;
using ScheduleOne.Core.Avatar;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Dialogue;
public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField]
    private DialogueDatabase _defaultDialogueDatabase;
    [SerializeField]
    private Conversation _genericConversation;
    [SerializeField]
    private List<DialogueModule> _defaultModules;
    public DialogueDatabase DefaultDialogueDatabase => _defaultDialogueDatabase;
    public Conversation GenericConversation => _genericConversation;

    protected override void Awake();
    public DialogueModule Get(EDialogueModule moduleType);
    public static string GetFormalAddress(EGender gender, bool capitalized = true);
    public static string GetThirdPersonAddress(EGender gender, bool capitalized = true);
    public static string GetThirdPersonPronoun(EGender gender, bool capitalized = true);
}