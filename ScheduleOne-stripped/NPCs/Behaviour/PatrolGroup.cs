using System.Collections.Generic;
using ScheduleOne.Police;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class PatrolGroup
{
    public List<NPC> Members;
    public FootPatrolRoute Route;
    public int CurrentWaypoint;
    public PatrolGroup(FootPatrolRoute route);
    public Vector3 GetDestination(NPC member);
    public void DisbandGroup();
    public void AdvanceGroup();
    private Vector3 GetMemberOffset(NPC member);
    public bool IsGroupReadyToAdvance();
    public bool IsPaused();
}