using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.Law;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Police;
using ScheduleOne.Product;
using ScheduleOne.Product.Packaging;
using ScheduleOne.UI;
using ScheduleOne.Vehicles;
using ScheduleOne.VoiceOver;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs.Behaviour;
public class BodySearchBehaviour : Behaviour
{
    public const EStealthLevel MAX_STEALTH_LEVEL;
    public const float BODY_SEARCH_RANGE;
    public const float MAX_SEARCH_TIME;
    public const float MAX_TIME_OUTSIDE_RANGE;
    public const float RANGE_TO_ESCALATE;
    public const float MOVE_SPEED;
    public const float BODY_SEARCH_COOLDOWN;
    [Header("Settings")]
    public float ArrestCircle_MaxVisibleDistance;
    public float ArrestCircle_MaxOpacity;
    public bool ShowPostSearchDialogue;
    [Header("Item of interest settings")]
    public EStealthLevel MaxStealthLevel;
    private PoliceOfficer officer;
    private float targetDistanceOnStart;
    private float searchTime;
    private bool hasBeenInRange;
    private float timeOutsideRange;
    private float timeWithinSearchRange;
    private float timeSinceCantReach;
    [Header("Events")]
    public UnityEvent onSearchComplete_Clear;
    public UnityEvent onSearchComplete_ItemsFound;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EBodySearchBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EBodySearchBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public static float BODY_SEARCH_TIME { get; }
    public Player TargetPlayer { get; protected set; }
    private DialogueDatabase dialogueDatabase => officer.DialogueHandler.Database;

    public override void Awake();
    public override void Activate();
    public override void Resume();
    public override void Deactivate();
    public override void Pause();
    public override void BehaviourUpdate();
    private void UpdateSearch();
    protected virtual void UpdateMovement();
    private void SearchClean();
    private void SearchFail();
    private void UpdateEscalation();
    protected virtual void UpdateLookAt();
    protected virtual void UpdateCircle();
    private void SetArrestCircleAlpha(float alpha);
    private void SetArrestCircleColor(Color col);
    private Vector3 GetNewDestination();
    private void ClearSpeedControls();
    private bool IsTargetValid(Player player);
    [ObserversRpc(RunLocally = true)]
    public virtual void AssignTarget(NetworkConnection conn, NetworkObject target);
    public virtual bool DoesPlayerContainItemsOfInterest();
    public virtual void ConcludeSearch(bool clear);
    public virtual void Escalate();
    public virtual void NoItemsOfInterestFound();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_AssignTarget_1824087381(NetworkConnection conn, NetworkObject target);
    public virtual void RpcLogic___AssignTarget_1824087381(NetworkConnection conn, NetworkObject target);
    private void RpcReader___Observers_AssignTarget_1824087381(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EBodySearchBehaviour_Assembly_002DCSharp_002Edll();
}