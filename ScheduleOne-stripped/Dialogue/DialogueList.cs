using System;
using UnityEngine;

namespace ScheduleOne.Dialogue;
[Serializable]
public class DialogueList
{
    public string[] Lines;
    public string GetRandomLine();
}