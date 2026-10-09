using FishNet.Connection;
using ScheduleOne.Dragging;
using UnityEngine;

namespace ScheduleOne.NPCs;
public class NPCRagdollDraggable : Draggable
{
    public override bool ShouldReplicateInitialTransformForClient(NetworkConnection conn);
}