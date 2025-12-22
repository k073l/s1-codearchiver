using System;
using System.Collections;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs.CharacterClasses;
using ScheduleOne.PlayerScripts;
using ScheduleOne.VoiceOver;
using UnityEngine;
using UnityEngine.AI;

namespace ScheduleOne.NPCs.Behaviour;
public class SewerGoblinRetrieveBehaviour : Behaviour
{
    public const float PROXIMITY_THRESHOLD;
    public const float TIMEOUT;
    private SewerGoblin sewerGoblin;
    public Action onRetrieveComplete;
    public Action onRetrieveCancelled;
    private float timeSinceStart;
    private bool grabbing;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002ESewerGoblinRetrieveBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002ESewerGoblinRetrieveBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public Player Target => sewerGoblin.TargetPlayer;

    public override void Awake();
    public override void Activate();
    public override void Resume();
    public override void Deactivate();
    public override void Pause();
    private void StartBehaviour();
    private void StopBehaviour();
    public void CancelRetrieve();
    private void CompleteRetrieve();
    public override void BehaviourUpdate();
    private bool IsTargetDestinationValid();
    private bool GetNewDestination(out Vector3 dest);
    private bool WithinRangeOfTarget();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002ESewerGoblinRetrieveBehaviour_Assembly_002DCSharp_002Edll();
}