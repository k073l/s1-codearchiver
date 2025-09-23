using System.Collections.Generic;

namespace ScheduleOne.NPCs.Schedules;
public class NPCActionOrderByDescending : IComparer<NPCAction>
{
    public int Compare(NPCAction x, NPCAction y);
}