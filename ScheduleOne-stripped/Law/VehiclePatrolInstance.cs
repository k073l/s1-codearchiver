using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Map;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.Police;
using UnityEngine;

namespace ScheduleOne.Law;
[Serializable]
public class VehiclePatrolInstance
{
    public VehiclePatrolRoute Route;
    public int StartTime;
    [Range(1f, 10f)]
    public int IntensityRequirement;
    public bool OnlyIfCurfewEnabled;
    private PoliceOfficer activeOfficer;
    private int latestStartTime;
    private bool startedThisCycle;
    private PoliceStation nearestStation => PoliceStation.GetClosestPoliceStation(Vector3.zero);

    public void Evaluate();
    private void CheckEnd();
    public void StartPatrol();
}