using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Dialogue;
[Serializable]
[CreateAssetMenu(fileName = "New Dialogue Database", menuName = "Dialogue/Dialogue Database")]
public class DialogueDatabase : ScriptableObject
{
    public List<DialogueModule> Modules;
    public List<Entry> GenericEntries;
    private DialogueHandler handler;
    private List<DialogueModule> runtimeModules => handler.runtimeModules;

    public void Initialize(DialogueHandler _handler);
    public DialogueModule GetModule(EDialogueModule moduleType);
    public DialogueChain GetChain(EDialogueModule moduleType, string key);
    public bool HasChain(EDialogueModule moduleType, string key);
    public string GetLine(EDialogueModule moduleType, string key);
    public bool HasLine(EDialogueModule moduleType, string key);
}