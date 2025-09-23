using System;
using System.Collections;
using FishNet;
using FishNet.Object;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.Equipping;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using ScheduleOne.ObjectScripts.Soil;
using ScheduleOne.Trash;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class PotActionBehaviour : Behaviour
{
    public enum EActionType
    {
        None,
        PourSoil,
        SowSeed,
        Water,
        ApplyAdditive,
        Harvest
    }

    public enum EState
    {
        Idle,
        WalkingToSupplies,
        GrabbingSupplies,
        WalkingToPot,
        PerformingAction,
        WalkingToDestination
    }

    [HideInInspector]
    public int AdditiveNumber;
    [Header("Equippables")]
    public AvatarEquippable WateringCanEquippable;
    public AvatarEquippable TrimmersEquippable;
    private Botanist botanist;
    private Coroutine walkToSuppliesRoutine;
    private Coroutine grabRoutine;
    private Coroutine walkToPotRoutine;
    private Coroutine performActionRoutine;
    private string currentActionAnimation;
    private AvatarEquippable currentActionEquippable;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EPotActionBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EPotActionBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public bool Initialized { get; protected set; }
    public Pot AssignedPot { get; protected set; }
    public EActionType CurrentActionType { get; protected set; }
    public EState CurrentState { get; protected set; }

    public override void Awake();
    public virtual void Initialize(Pot pot, EActionType actionType);
    protected override void Begin();
    protected override void Resume();
    protected override void Pause();
    public override void Disable();
    protected override void End();
    public override void ActiveMinPass();
    private void StartAction();
    private void StopAllActions();
    public void WalkToSupplies();
    public void GrabItem();
    public void WalkToPot();
    public void PerformAction();
    private void CompleteAction();
    private void StopPerformAction();
    private string GetActionAnimation(EActionType actionType);
    private AvatarEquippable GetActionEquippable(EActionType actionType);
    public float GetWaitTime(EActionType actionType);
    public bool CanGetToSupplies();
    private bool IsAtSupplies();
    private ITransitEntity GetSuppliesAsTransitEntity();
    public bool CanGetToPot();
    private Transform GetPotAccessPoint();
    private bool IsAtPot();
    private string[] GetRequiredItemIDs(EActionType actionType, Pot pot);
    private string[] GetRequiredItemIDs();
    private bool AreActionConditionsMet();
    public bool DoesTaskTypeRequireSupplies(EActionType actionType);
    public bool DoesBotanistHaveMaterialsForTask(Botanist botanist, Pot pot, EActionType actionType, int additiveNumber = -1);
    private ItemInstance GetSoilInSupplies();
    private ItemInstance GetSeedInSupplies(Pot pot);
    private ItemInstance GetAdditiveInSupplies(Pot pot, int additiveNumber);
    public bool CanPotBeWatered(Pot pot, float threshold);
    public bool CanPotHaveSoilPour(Pot pot);
    public bool CanPotHaveSeedSown(Pot pot);
    public bool CanPotHaveAdditiveApplied(Pot pot, out int additiveNumber);
    public bool CanPotBeHarvested(Pot pot);
    public bool DoesPotHaveValidDestination(Pot pot);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EPotActionBehaviour_Assembly_002DCSharp_002Edll();
}