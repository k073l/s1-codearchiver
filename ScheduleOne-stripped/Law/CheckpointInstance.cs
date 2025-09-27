using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Map;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Police;
using UnityEngine;

namespace ScheduleOne.Law;
[Serializable]
public class CheckpointInstance
{
    public const float MIN_ACTIVATION_DISTANCE;
    public CheckpointManager.ECheckpointLocation Location;
    public int Members;
    public int StartTime;
    public int EndTime;
    [Range(1f, 10f)]
    public int IntensityRequirement;
    public bool OnlyIfCurfewEnabled;
    private RoadCheckpoint checkPoint;
    public RoadCheckpoint activeCheckpoint { get; protected set; }

    public void Evaluate();
    public void EnableCheckpoint();
    private bool DistanceRequirementsMet();
    private void MinPass();
    public void DisableCheckpoint();
}