using System.Collections.Generic;
using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.Dialogue;
public class DialogueModule : MonoBehaviour
{
    public EDialogueModule ModuleType;
    public List<Entry> Entries;
    public Entry GetEntry(string key);
    public DialogueChain GetChain(string key);
    public bool HasChain(string key);
    public string GetLine(string key);
    public bool HasLine(string key);
    [Button]
    public int GetWordCount();
}