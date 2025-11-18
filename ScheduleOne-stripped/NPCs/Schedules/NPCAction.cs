using System;
using FishNet;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;

namespace ScheduleOne.NPCs.Schedules;
[Serializable]
public abstract class NPCAction : NetworkBehaviour
{
    public const int MAX_CONSECUTIVE_PATHING_FAILURES;
    [SerializeField]
    protected int priority;
    [Header("Timing Settings")]
    public int StartTime;
    protected NPC npc;
    protected NPCScheduleManager schedule;
    public Action onEnded;
    protected int consecutivePathingFailures;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ESchedules_002ENPCActionAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ESchedules_002ENPCActionAssembly_002DCSharp_002Edll_Excuted;
    protected string ActionName => "ActionName";
    public bool IsEvent => this is NPCEvent;
    public bool IsSignal => this is NPCSignal;
    public bool IsActive { get; protected set; }
    public bool HasStarted { get; protected set; }
    public virtual int Priority => priority;
    protected NPCMovement movement => npc.Movement;

    public override void Awake();
    protected override void OnValidate();
    private void GetReferences();
    protected virtual void Start();
    private void OnDestroy();
    public virtual void Started();
    public virtual void LateStarted();
    public virtual void JumpTo();
    public virtual void End();
    public virtual void Interrupt();
    public virtual void Resume();
    public virtual void ResumeFailed();
    public virtual void Skipped();
    public virtual void ActiveUpdate();
    public virtual void ActiveMinPassed();
    public virtual void PendingMinPassed();
    public virtual void MinPassed();
    public virtual bool ShouldStart();
    public abstract string GetName();
    public abstract string GetTimeDescription();
    public abstract int GetEndTime();
    protected unsafe void SetDestination(Vector3 position, bool teleportIfFail = true);
    protected virtual void WalkCallback(NPCMovement.WalkResult result);
    public virtual void SetStartTime(int startTime);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002ESchedules_002ENPCAction_Assembly_002DCSharp_002Edll();
}