using System;
using ScheduleOne.Dialogue;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class Dialogue
{
    public DialogueDatabase DialogueDatabase;
    public Dialogue GetCopy();
}