using System;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class Interaction
{
    public bool CanBeSummoned;
    public Interaction GetCopy();
}