using FishNet;
using ScheduleOne.Police;
using ScheduleOne.Vehicles;
using ScheduleOne.Vehicles.AI;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class VehiclePatrolBehaviour : Behaviour
{
    public new const float MAX_CONSECUTIVE_PATHING_FAILURES;
    public const float PROGRESSION_THRESHOLD;
    public int CurrentWaypoint;
    [Header("Settings")]
    public VehiclePatrolRoute Route;
    public LandVehicle Vehicle;
    private bool aggressiveDrivingEnabled;
    private new int consecutivePathingFailures;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EVehiclePatrolBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EVehiclePatrolBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool isDriving => (Object)(object)Vehicle.OccupantNPCs[0] == (Object)(object)base.Npc;
    private VehicleAgent Agent => Vehicle.Agent;

    public override void Awake();
    public override void Begin();
    public override void Resume();
    public override void Pause();
    public override void End();
    public void SetRoute(VehiclePatrolRoute route);
    private void StartPatrol();
    public override void ActiveMinPass();
    private void DriveTo(Vector3 location);
    private void NavigationCallback(VehicleAgent.ENavigationResult status);
    private bool IsAsCloseAsPossible(Vector3 pos, out Vector3 closestPosition);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EVehiclePatrolBehaviour_Assembly_002DCSharp_002Edll();
}