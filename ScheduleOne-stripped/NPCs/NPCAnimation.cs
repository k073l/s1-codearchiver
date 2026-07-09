using System;
using FishNet.Object;
using UnityEngine;

namespace ScheduleOne.NPCs;
public class NPCAnimation : NetworkBehaviour
{
    protected NPC npc;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ENPCAnimationAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ENPCAnimationAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    protected void Update();
    protected virtual void UpdateMovementAnimation();
    public void StandupStart();
    public void StandupDone();
    private void OnNPCVisibilityChanged(bool visible);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void Awake_UserLogic_ScheduleOne_002ENPCs_002ENPCAnimation_Assembly_002DCSharp_002Edll();
}