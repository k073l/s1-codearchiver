using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.Vehicles;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers.Activity;
public class RevingActivity : SpecialCustomerActivity
{
    [Header("Components")]
    [SerializeField]
    private List<Motorbike> _motorbikes;
    private Dictionary<string, int> _npcSeatMap;
    public override string ActivityName => "Reving";
    protected override int MaxParticipantsPerInstance => 1;
    protected override bool ShouldBeConsideredForReassignment => false;

    protected override void Awake();
    protected override void OnRun(List<SpecialCustomer> addedNpcs);
    private Motorbike GetRandomFreeMotorbike(out int index);
    private void AssignSeat(string name, int index);
    public Motorbike GetMotorBike(int index);
    public int GetFreeBikeCount();
    public override void OnActivityEnd(string npcName, string activityName);
    public override Vector2Int GetMinMaxParticipants();
    public override bool CanStart();
    public void OnKnockOverBike(int motorbikeIndex);
    public override void OnClientJoin(NetworkConnection connection);
}