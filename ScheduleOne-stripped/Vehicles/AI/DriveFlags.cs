using System;

namespace ScheduleOne.Vehicles.AI;
[Serializable]
public class DriveFlags
{
    public enum EObstacleMode
    {
        Default,
        IgnoreAll,
        IgnoreOnlySquishy
    }

    public bool OverrideSpeed;
    public float OverriddenSpeed;
    public float OverriddenReverseSpeed;
    public float SpeedLimitMultiplier;
    public bool IgnoreTrafficLights;
    public bool UseRoads;
    public bool StuckDetection;
    public EObstacleMode ObstacleMode;
    public bool AutoBrakeAtDestination;
    public bool TurnBasedSpeedReduction;
    public void ResetFlags();
}