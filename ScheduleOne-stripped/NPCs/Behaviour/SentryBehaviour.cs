using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Law;
using ScheduleOne.Police;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class SentryBehaviour : Behaviour
{
    private const float BodySearchChance;
    private const int FlashlightMinTime;
    private int FlashlightMaxTime;
    private const string FlashlightAssetPath;
    private const float AngularSpeedMultiplier;
    private const float WalkSpeed;
    public bool UseFlashlight;
    private bool flashlightEquipped;
    private PoliceOfficer officer;
    private int _currentRoutePointIndex;
    private int _minutesAtCurrentPoint;
    private bool _movementModifiersApplied;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002ESentryBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002ESentryBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public SentryLocation AssignedLocation { get; private set; }
    private SentryLocation.SentryRoute _currentRoute { get; }
    private Transform _standPoint { get; }

    public override void Awake();
    public override void Deactivate();
    public override void Pause();
    public override void Disable();
    public void AssignLocation(SentryLocation loc);
    public void UnassignLocation();
    public override void OnActiveTick();
    public override void OnActiveUncappedMinutePass();
    private bool IsAtStandPoint();
    private void SetFlashlightEquipped(bool equipped);
    private void ApplyMovementModifiers();
    private void RemoveMovementModifiers();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002ESentryBehaviour_Assembly_002DCSharp_002Edll();
}