using System.Collections.Generic;
using System.Linq;
using FishNet.Connection;
using GameKit.Utilities;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Behaviour;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers;
public class MoveToAndActActivity : SpecialCustomerActivity
{
    [Header("Components")]
    [SerializeField]
    protected List<ActivityLocation> _locations;
    [Header("Properties")]
    [SerializeField]
    protected string _behaviourName;
    [SerializeField]
    protected int _maxParticipantsPerInstance;
    [SerializeField]
    protected bool _shouldBeConsideredForReassignment;
    [SerializeField]
    protected int _equippableItemIndex;
    public override string ActivityName => _behaviourName;
    protected override int MaxParticipantsPerInstance => _maxParticipantsPerInstance;
    protected override bool ShouldBeConsideredForReassignment => _shouldBeConsideredForReassignment;

    public override void ValidateActivity();
    private void OnDrawGizmos();
    protected override void OnRun(List<SpecialCustomer> addedNpcs);
    public override void OnActivityEnd(string npcName, string activityName);
    public override Vector2Int GetMinMaxParticipants();
    public override bool CanStart();
    public override void OnClientJoin(NetworkConnection connection);
}