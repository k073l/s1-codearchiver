using ScheduleOne.PlayerScripts;
using ScheduleOne.Vehicles;
using UnityEngine;

namespace ScheduleOne.Tools;
public class PlayerSmoothedVelocityCalculator : SmoothedVelocityCalculator
{
    public Player Player;
    protected override void FixedUpdate();
}