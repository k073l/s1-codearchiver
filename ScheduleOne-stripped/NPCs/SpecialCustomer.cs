using System;
using FishNet;
using FishNet.Object;
using ScheduleOne.NPCs.Responses;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.NPCs;
public class SpecialCustomer : NPC
{
    private const int DefaultNavAgentAvoidancePriority;
    private const int MinMovingNavMeshAgentAvoidancePriority;
    private const int MaxMovingNavMeshAgentAvoidancePriority;
    private const float MinAggressionToJoinGroupMateCombat;
    private const float MaxDistanceToRespondToGroupMateAttacked;
    private SpecialCustomer[] _groupMates;
    private int _randomMovingAvoidancePriority;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ESpecialCustomerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ESpecialCustomerAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    protected override void OnTick();
    public void SetGroupMates(SpecialCustomer[] groupMates);
    private void OnGroupMateAttackedByPlayer(Player attacker);
    private bool WillRespondToGroupMateAttacked(Player attacker);
    public override bool ShouldSave();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002ESpecialCustomer_Assembly_002DCSharp_002Edll();
}