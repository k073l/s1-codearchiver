using FishNet;
using FishNet.Connection;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.Management;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace ScheduleOne.NPCs.Behaviour;
public class Behaviour : NetworkBehaviour
{
    public const int MAX_CONSECUTIVE_PATHING_FAILURES;
    public bool EnabledOnAwake;
    [Header("Settings")]
    public string Name;
    [Tooltip("Behaviour priority; higher = takes priority over lower number behaviour")]
    public int Priority;
    [HideInInspector]
    public int BehaviourIndex;
    public UnityEvent onEnable;
    public UnityEvent onDisable;
    public UnityEvent onBegin;
    public UnityEvent onEnd;
    protected int consecutivePathingFailures;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public bool Enabled { get; protected set; }
    public bool Started { get; private set; }
    public bool Active { get; private set; }
    public NPCBehaviour beh { get; private set; }
    public NPC Npc => beh.Npc;

    public override void Awake();
    protected override void OnValidate();
    public virtual void Enable();
    public void Enable_Server();
    public void Enable_Networked();
    public virtual void Disable();
    public void Disable_Server();
    public void Disable_Networked(NetworkConnection conn);
    public void Activate_Server(NetworkConnection conn);
    public virtual void Activate();
    public void Deactivate_Server();
    public void Deactivate_Networked(NetworkConnection conn);
    public virtual void Deactivate();
    public void Pause_Server();
    public virtual void Pause();
    public void Resume_Server();
    public virtual void Resume();
    public virtual void BehaviourUpdate();
    public virtual void BehaviourLateUpdate();
    public virtual void OnActiveTick();
    protected void SetDestination(ITransitEntity transitEntity, bool teleportIfFail = true);
    protected unsafe virtual void SetDestination(Vector3 position, bool teleportIfFail = true, float successThreshold = 1f);
    protected virtual void WalkCallback(NPCMovement.WalkResult result);
    private void UpdateGameObjectName();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EBehaviour_Assembly_002DCSharp_002Edll();
}