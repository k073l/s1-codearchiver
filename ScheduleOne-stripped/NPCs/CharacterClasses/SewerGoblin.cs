using System;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Object;
using ScheduleOne.Audio;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.Doors;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Map;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.NPCs.Schedules;
using ScheduleOne.PlayerScripts;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.NPCs.CharacterClasses;
public class SewerGoblin : NPC
{
    public enum ESewerGoblinState
    {
        Inactive,
        Attacking,
        Retrieving,
        Retreating
    }

    public const int COOLDOWN_HOURS_BETWEEN_DEPLOYS;
    public const float HOURLY_DEPLOY_CHANCE;
    public const float NORMALIZED_HEALTH_THRESHOLD_TO_RETREAT;
    public const float RETREAT_CHANCE_AFTER_HIT;
    public const int MAX_CANCELLED_RETRIEVE_ATTEMPTS;
    [Header("References")]
    public NPCEnterableBuilding SewerHidingBuilding;
    public NPCEvent_StayInBuilding StayInBuildingEvent;
    public ItemDefinition PacifyItem;
    public SewerGoblinRetrieveBehaviour RetrieveBehaviour;
    public AudioSourceController ExitSound;
    [HideInInspector]
    public int cancelledRetrieveAttempts;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ECharacterClasses_002ESewerGoblinAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ECharacterClasses_002ESewerGoblinAssembly_002DCSharp_002Edll_Excuted;
    public Player TargetPlayer { get; private set; }
    public ESewerGoblinState CurrentState { get; private set; }
    public int HoursSinceLastDeploy { get; set; }

    public override void Awake();
    protected override void Start();
    private void Update();
    private void OnMinPass();
    private void OnHourPass();
    public void DeployToPlayer(Player player);
    private void AttackTarget();
    public void Retreat();
    protected override void EnterBuilding(string buildingGUID, int doorIndex);
    protected override void ExitBuilding(NPCEnterableBuilding building);
    public void DeployToLocalPlayer();
    private void OnSuccesfulCombatHit();
    private bool CanBeginRetieve();
    private void BeginRetrieve();
    private void OnRetrieveCancel();
    private void OnRetrieveSuccess();
    public bool IsPlayerValidTarget(Player player);
    public bool IsPlayerHoldingPacifyItem(Player player);
    public override void ProcessImpactForce(Vector3 forcePoint, Vector3 forceDirection, float force);
    private void OnTakeDamage(float damageAmount);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002ECharacterClasses_002ESewerGoblin_Assembly_002DCSharp_002Edll();
}