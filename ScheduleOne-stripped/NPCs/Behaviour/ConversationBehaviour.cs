using FishNet;
using FishNet.Managing;
using FishNet.Object;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class ConversationBehaviour : MoveToAndActBehaviour
{
    private static readonly EVOLineType[] ConversationLines;
    private static readonly string[] AnimationTriggers;
    private const int MinimumTimeBetweenLines;
    private const int MaximumTimeBetweenLines;
    private const float ProximityToLookAtNPC;
    private const float AngleToLookAtNPC;
    private const float VoiceVolume;
    private int timeUntilNextLine;
    private NPC _npcToLookAt;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EConversationBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EConversationBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public override void OnActiveTick();
    public override void BehaviourUpdate();
    public override void OnActiveUncappedMinutePass();
    private void GetNewNPCToLookAt();
    [Server]
    private void UpdateTalk();
    [Server]
    private void Talk();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}