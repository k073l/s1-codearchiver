using System;
using System.Collections;
using FishNet;
using FishNet.Object;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Trash;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public abstract class GrowContainerBehaviour : Behaviour
{
    protected enum EState
    {
        Idle,
        Walking,
        GrabbingSupplies,
        PerformingAction
    }

    private Coroutine _walkRoutine;
    private Coroutine _grabRoutine;
    private Coroutine _performActionRoutine;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EGrowContainerBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EGrowContainerBehaviourAssembly_002DCSharp_002Edll_Excuted;
    protected GrowContainer _growContainer { get; private set; }
    protected EState _currentState { get; private set; }
    protected Botanist _botanist { get; private set; }
    protected BotanistConfiguration _botanistConfiguration => _botanist.Configuration as BotanistConfiguration;

    public override void Awake();
    public virtual void AssignAndEnable(GrowContainer growContainer);
    public override void Activate();
    public override void Resume();
    public override void Pause();
    public override void Deactivate();
    public virtual bool AreTaskConditionsMetForContainer(GrowContainer container);
    public bool DoesBotanistHaveAccessToRequiredSupplies(GrowContainer container);
    public override void OnActiveTick();
    protected virtual void OnStartPerformAction();
    protected virtual void OnStopPerformAction();
    protected virtual Vector3 GetGrowContainerLookPoint();
    protected virtual AvatarEquippable GetActionEquippable();
    protected virtual TrashItem GetTrashPrefab(ItemInstance usedItem);
    protected abstract void OnActionSuccess(ItemInstance usedItem);
    protected abstract string GetAnimationBool();
    protected abstract float GetActionDuration();
    private void WalkTo(ITransitEntity entity);
    private void GrabRequiredItemFromSupplies();
    private void PerformAction();
    protected virtual bool CheckSuccess(ItemInstance usedItem);
    private void StopAllRoutines();
    protected virtual string[] GetRequiredItemSuitableIDs(GrowContainer growContainer);
    private bool DoesTaskRequireItem(GrowContainer growContainer, out string[] suitableItemIDs);
    private bool IsRequiredItemInInventory(GrowContainer growContainer);
    private bool DoSuppliesContainRequiredItem(GrowContainer growContainer);
    private ItemSlot GetSuppliesSlotContainingRequiredItem(string[] suitableItemIDs);
    protected ItemSlot GetItemSlotContainingRequiredItem(IItemSlotOwner itemSlotOwner, string[] suitableItemIDs);
    private bool IsAtSupplies();
    private bool IsAtGrowContainer();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EGrowContainerBehaviour_Assembly_002DCSharp_002Edll();
}