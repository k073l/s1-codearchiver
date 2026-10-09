using System;
using System.Collections.Generic;
using System.Linq;
using FishNet.Object;
using ScheduleOne.Combat;
using ScheduleOne.Economy;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Vision;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers;
public class PunchActivity : SpecialCustomerActivity
{
    [Header("Punch Activity: Properties")]
    [Tooltip("The range within which the punch activity considers NPCs as valid targets.")]
    [SerializeField]
    private float _targetRange;
    [Tooltip("The range within which the punch activity can be activated.")]
    [SerializeField]
    private float _activationRange;
    protected List<NPC> _validNpcs;
    protected List<Tuple<SpecialCustomer, NPC>> _validGroups;
    public override string ActivityName => "Punch";
    protected override int MaxParticipantsPerInstance => 1;
    protected override bool ShouldBeConsideredForReassignment => false;

    public override void Evaluate();
    protected override void OnRun(List<SpecialCustomer> npcs);
    private void OnBehaviourEnd(string npc, string activity);
    public override bool CanStart();
    public override bool IsValidParticipant(SpecialCustomer specialCustomer);
    private bool HasAnyNPCInSight(SpecialCustomer specialCustomer);
    private bool IsValidTarget(NPC npc);
}