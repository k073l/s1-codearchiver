using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Connection;
using ScheduleOne.Map;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Behaviour;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers;
public class OrgyActivity : SpecialCustomerActivity
{
    [Header("Components")]
    [SerializeField]
    private List<NPCEnterableBuilding> _buildings;
    private Dictionary<string, int> orgyParticipants;
    public override string ActivityName => "Orgy";
    protected override int MaxParticipantsPerInstance => 3;
    protected override bool ShouldBeConsideredForReassignment => true;
    protected int MaxParticipantsPerBuilding => 3;

    public override void ValidateActivity();
    protected override void OnInitialise();
    protected override void OnRun(List<SpecialCustomer> addedNpcs);
    private void OnEnterBuilding(string buildingId);
    private void OnExitBuilding(string buildingId);
    public override Vector2Int GetMinMaxParticipants();
    public override bool CanStart();
    protected void OnStartOrgy(string npcId, string buildingId);
    protected void OnEndOrgy(string npcId, string buildingId);
    public override void OnClientJoin(NetworkConnection connection);
}