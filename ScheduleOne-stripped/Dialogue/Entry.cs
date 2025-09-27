using System;
using UnityEngine;

namespace ScheduleOne.Dialogue;
[Serializable]
public struct Entry
{
    public string Key;
    public DialogueChain[] Chains;
    public DialogueChain GetRandomChain();
    public string GetRandomLine();
}