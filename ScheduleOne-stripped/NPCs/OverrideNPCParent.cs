using UnityEngine;

namespace ScheduleOne.NPCs;
[RequireComponent(typeof(NPC))]
public class OverrideNPCParent : MonoBehaviour
{
    public Transform Parent;
}