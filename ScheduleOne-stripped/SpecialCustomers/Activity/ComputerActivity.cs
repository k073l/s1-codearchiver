using System.Collections.Generic;
using FishNet.Connection;
using ScheduleOne.AvatarFramework.Animation;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Behaviour;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers.Activity;
public class ComputerActivity : SpecialCustomerActivity
{
    [Header("Components")]
    [SerializeField]
    private AvatarSeatSet _seats;
    private Dictionary<string, int> _npcSeatMap;
    public override string ActivityName => "Computer";
    protected override int MaxParticipantsPerInstance => 1;
    protected override bool ShouldBeConsideredForReassignment => false;

    public override void ValidateActivity();
    protected override void OnRun(List<SpecialCustomer> addedNpcs);
    private AvatarSeat GetNextFreeSeat(int startIndex, out int index);
    private void AssignSeat(string name, int index);
    public AvatarSeat GetSeat(int index);
    public override void OnActivityEnd(string npcName, string activityName);
    public override Vector2Int GetMinMaxParticipants();
    public override bool CanStart();
    public override void OnClientJoin(NetworkConnection connection);
}