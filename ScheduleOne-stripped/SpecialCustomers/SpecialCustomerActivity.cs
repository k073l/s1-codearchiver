using System.Collections.Generic;
using FishNet.Connection;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Behaviour;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers;
public abstract class SpecialCustomerActivity : MonoBehaviour
{
    public class ActivityTimer
    {
        public float Timer;
        public float Duration;
        public bool IsComplete => Timer >= Duration;

        public ActivityTimer(float duration);
    }

    [Header("Activity Settings: General")]
    [Tooltip("Determines the overall chance for this activity to run.")]
    [SerializeField]
    [Range(0f, 100f)]
    protected float _priority;
    [SerializeField]
    protected Vector2Int _minMaxDuration;
    [SerializeField]
    protected bool _restrictToTimeOfDay;
    [Conditional("_restrictToTimeOfDay", false)]
    [SerializeField]
    protected Vector2Int _minMaxTimeOfDay;
    protected List<SpecialCustomer> _assignedNPCs;
    protected IActivityHandler _activityHandler;
    protected List<ActivityTimer> _activityTimers;
    private List<SpecialCustomer> _npcesToReassign;
    public float Priority { get; protected set; }
    public abstract string ActivityName { get; }
    protected abstract int MaxParticipantsPerInstance { get; }
    protected abstract bool ShouldBeConsideredForReassignment { get; }

    protected virtual void Awake();
    public virtual void ValidateActivity();
    public virtual void Evaluate();
    public void Intialise(IActivityHandler activityHandler);
    public void Run(List<SpecialCustomer> npcs);
    public void Stop(bool clearAssigned = true);
    protected virtual void OnInitialise();
    protected virtual void OnRun(List<SpecialCustomer> npcs);
    protected virtual void OnStop();
    protected virtual void AddActivityTimer();
    public virtual void UpdateActivity();
    public virtual Vector2Int GetMinMaxParticipants();
    public virtual bool CanStart();
    public virtual void OnActivityEnd(string npcName, string activityName);
    public List<SpecialCustomer> GetAndRemoveNPCWithActivityProgress(float progressThreshold);
    public void StopAndRemoveNPC(SpecialCustomer npc);
    public virtual bool IsValidParticipant(SpecialCustomer npc);
    public virtual void UpdatePriority();
    public virtual void OnClientJoin(NetworkConnection connection);
}