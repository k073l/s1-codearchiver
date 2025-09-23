using FishNet.Object;
using UnityEngine;

namespace ScheduleOne.NPCs;
public class NPCAnimation : NetworkBehaviour
{
    public bool DEBUG;
    protected NPC npc;
    [Header("Settings")]
    public AnimationCurve WalkMapCurve;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ENPCAnimationAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ENPCAnimationAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    protected virtual void LateUpdate();
    protected virtual void UpdateMovementAnimation();
    public virtual void SetRagdollActive(bool active);
    public void StandupStart();
    public void StandupDone();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void Awake_UserLogic_ScheduleOne_002ENPCs_002ENPCAnimation_Assembly_002DCSharp_002Edll();
}