using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Police;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class FootPatrolBehaviour : Behaviour
{
    public const float MOVE_SPEED;
    public const int FLASHLIGHT_MIN_TIME;
    public int FLASHLIGHT_MAX_TIME;
    public const string FLASHLIGHT_ASSET_PATH;
    public bool UseFlashlight;
    private bool flashlightEquipped;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EFootPatrolBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EFootPatrolBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public PatrolGroup Group { get; protected set; }

    public override void Activate();
    public override void Resume();
    public override void Pause();
    public override void Deactivate();
    public override void OnActiveTick();
    private void SetFlashlightEquipped(bool equipped);
    public void SetGroup(PatrolGroup group);
    public bool IsReadyToAdvance();
    private bool IsAtDestination();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}