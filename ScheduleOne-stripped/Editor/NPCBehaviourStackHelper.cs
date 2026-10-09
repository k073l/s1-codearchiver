using System.Collections.Generic;
using System.Linq;
using ScheduleOne.NPCs.Behaviour;
using UnityEngine;

namespace ScheduleOne.Editor;
public class NPCBehaviourStackHelper : MonoBehaviour
{
    public List<int> PriorityGroupRanges;
    public void UpdateStackPriorityBasedOnGroups();
}