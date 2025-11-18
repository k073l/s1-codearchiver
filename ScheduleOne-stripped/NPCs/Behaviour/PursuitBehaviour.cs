using System;
using FishNet.Object;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.Combat;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Police;
using ScheduleOne.Vision;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class PursuitBehaviour : CombatBehaviour
{
    private enum EPursuitAction
    {
        None,
        Move,
        Shoot,
        MoveAndShoot
    }

    public const float ARREST_RANGE;
    public const float ARREST_TIME;
    public const float EXTRA_VISIBILITY_TIME;
    public const float MOVE_SPEED_INVESTIGATING;
    public const float MOVE_SPEED_ARRESTING;
    public const float MOVE_SPEED_CHASE;
    public const float ARREST_MAX_DISTANCE;
    public const int LEAVE_ARREST_CIRCLE_LIMIT;
    [Header("Settings")]
    public float ArrestCircle_MaxVisibleDistance;
    public float ArrestCircle_MaxOpacity;
    [Header("Weapons")]
    public AvatarWeapon Weapon_Baton;
    public AvatarWeapon Weapon_Taser;
    public AvatarWeapon Weapon_Gun;
    protected bool arrestingEnabled;
    protected float currentPursuitLevelDuration;
    protected float timeWithinArrestRange;
    protected float distanceOnPursuitStart;
    private PoliceOfficer officer;
    private bool targetWasDrivingOnPursuitStart;
    private bool wasInArrestCircleLastFrame;
    private int leaveArrestCircleCount;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EPursuitBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EPursuitBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public Player TargetPlayer { get; protected set; }

    public override void Awake();
    private void OnDestroy();
    protected override void SetTarget(NetworkObject target);
    public override void Begin();
    public override void Resume();
    public override void Disable();
    public override void BehaviourUpdate();
    public override void ActiveMinPass();
    protected override bool IsTargetValid();
    protected virtual void UpdateInvestigatingBehaviour();
    protected virtual void UpdateArrestBehaviour();
    protected virtual void UpdateNonLethalBehaviour();
    protected virtual void UpdateLethalBehaviour();
    protected override void OnCurrentWeaponChanged(AvatarWeapon weapon);
    protected override float GetIdealRangedWeaponDistance();
    private void UpdateArrest(float tick);
    private void ClearSpeedControls();
    protected override void EndCombat();
    protected virtual void UpdateArrestCircle();
    public void ResetArrestProgress();
    private void SetArrestCircleAlpha(float alpha);
    private void SetArrestCircleColor(Color col);
    private void OnThirdPartyVisionEvent(VisionEventReceipt receipt);
    protected override void TargetSpotted();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EPursuitBehaviour_Assembly_002DCSharp_002Edll();
}