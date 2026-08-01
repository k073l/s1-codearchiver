using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(fileName = "NPCDataObject", menuName = "ScheduleOne/NPCs/NPC Data Object", order = -10)]
public class NPCDataObject : GenericNPCDataObject<NPCData>
{
    public override void Initialize();
}