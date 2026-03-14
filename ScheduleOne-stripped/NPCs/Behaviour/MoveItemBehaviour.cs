using System;
using System.Collections;
using FishNet;
using FishNet.Object;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class MoveItemBehaviour : Behaviour
{
    public enum EState
    {
        Idle,
        WalkingToSource,
        Grabbing,
        WalkingToDestination,
        Placing
    }

    private TransitRoute assignedRoute;
    private ItemInstance itemToRetrieveTemplate;
    private int grabbedAmount;
    private int maxMoveAmount;
    private EState currentState;
    private Coroutine walkToSourceRoutine;
    private Coroutine grabRoutine;
    private Coroutine walkToDestinationRoutine;
    private Coroutine placingRoutine;
    private bool skipPickup;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EMoveItemBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EMoveItemBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public bool Initialized { get; protected set; }

    public void Initialize(TransitRoute route, ItemInstance _itemToRetrieveTemplate, int _maxMoveAmount = -1, bool _skipPickup = false);
    public void Resume(TransitRoute route, ItemInstance _itemToRetrieveTemplate, int _maxMoveAmount = -1);
    public override void Activate();
    public override void Pause();
    public override void Resume();
    public override void Deactivate();
    public override void Disable();
    private void StartTransit();
    private bool IsNpcInventoryItemValid(ItemInstance item);
    private void EndTransit();
    public override void OnActiveTick();
    public void WalkToSource();
    public void GrabItem();
    private void TakeItem();
    public void WalkToDestination();
    public void PlaceItem();
    private int GetAmountToGrab();
    private void StopCurrentActivity();
    public bool IsTransitRouteValid(TransitRoute route, string itemID, out string invalidReason);
    public bool IsTransitRouteValid(TransitRoute route, ItemInstance templateItem, out string invalidReason);
    public bool IsTransitRouteValid(TransitRoute route, string itemID);
    public bool IsDestinationValid(TransitRoute route, ItemInstance item);
    public bool IsDestinationValid(TransitRoute route, ItemInstance item, out string invalidReason);
    public bool CanGetToSource(TransitRoute route);
    private Transform GetSourceAccessPoint(TransitRoute route);
    private bool IsAtSource();
    public bool CanGetToDestination(TransitRoute route);
    private Transform GetDestinationAccessPoint(TransitRoute route);
    private bool IsAtDestination();
    public MoveItemData GetSaveData();
    public void Load(MoveItemData moveItemData);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}