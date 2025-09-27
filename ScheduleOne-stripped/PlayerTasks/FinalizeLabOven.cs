using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.Stations;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks;
public class FinalizeLabOven : Task
{
    public const float MAX_DISTANCE_FROM_IMPACT_POINT;
    public float SMASH_VELOCITY_THRESHOLD;
    public float SMASH_COOLDOWN;
    public const int REQUIRED_IMPACTS;
    private Coroutine startSequence;
    private LabOvenHammer hammer;
    private int impactCount;
    private float timeSinceLastImpact;
    public LabOven Oven { get; private set; }

    public FinalizeLabOven(LabOven oven);
    public override void Update();
    public override void StopTask();
    private IEnumerator StartSequence();
    public void Collision(Collision col);
    private void Shatter();
}