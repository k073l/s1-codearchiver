using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScheduleOne.NPCs.Schedules;
public class ConversationLocation : MonoBehaviour
{
    public Transform[] StandPoints;
    [HideInInspector]
    public List<NPC> NPCs;
    private Dictionary<NPC, bool> npcReady;
    public bool NPCsReady => npcReady.Where(default).Count() >= 2;

    public void Awake();
    public Transform GetStandPoint(NPC npc);
    public void SetNPCReady(NPC npc, bool ready);
    public NPC GetOtherNPC(NPC npc);
}