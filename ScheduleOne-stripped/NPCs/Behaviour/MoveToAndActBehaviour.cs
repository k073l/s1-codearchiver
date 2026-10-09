using System;
using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Core;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs.Other;
using ScheduleOne.SpecialCustomers;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class MoveToAndActBehaviour : Behaviour
{
    [Header("Components")]
    [SerializeField]
    private List<ActivityLocation> _locations;
    [Header("Properties: General")]
    [SerializeField]
    private Vector2 _minMaxDuration;
    [SerializeField]
    private float _minDistanceToLocation;
    [Header("Properties: Animation")]
    [SerializeField]
    protected string _animation;
    [SerializeField]
    protected bool _haltMovementForAnimations;
    [SerializeField]
    [Conditional("_haltMovementForAnimations", false)]
    private float _haltMovementDuration;
    [Header("Properties: Equippable")]
    [Tooltip("If set to -1, no item will be equipped. If set to a valid index, that specific item will be equipped.")]
    [SerializeField]
    protected int _itemToEquipIndex;
    [SerializeField]
    protected List<EquippableData> _equippableItems;
    [Header("Properties: Auxiliary Action")]
    [SerializeField]
    protected NPCAuxAction _aux;
    protected Vector3 _targetPosition;
    protected Vector3 _faceDir;
    protected IEquippedItemHandler _equippedItem;
    protected bool _isActing;
    private int _failedAttempts;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EMoveToAndActBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EMoveToAndActBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public bool IsActing => _isActing;
    public string AnimationName => _animation;

    public event Action _onStartAct;
    public event Action _onEndAct;
    [ObserversRpc]
    [TargetRpc]
    public void Set_Client(NetworkConnection connection, Vector3 position, Vector3 faceDir, int itemToEquipIndex = -1);
    protected override void OnActivateOrResume();
    public override void Disable();
    protected override void OnDeactivateOrPause();
    public override void OnActiveUncappedMinutePass();
    [ObserversRpc]
    [TargetRpc]
    public void StartAct(NetworkConnection conn);
    protected virtual void OnStartAct();
    protected virtual void OnEndAct();
    protected override void WalkCallback(NPCMovement.WalkResult result);
    protected bool IsAtDestination();
    protected bool HasValidTargetPosition();
    private IEnumerator DoHaltMovementForAnimationsRoutine(float delay);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_Set_Client_181508341(NetworkConnection connection, Vector3 position, Vector3 faceDir, int itemToEquipIndex = -1);
    public void RpcLogic___Set_Client_181508341(NetworkConnection connection, Vector3 position, Vector3 faceDir, int itemToEquipIndex = -1);
    private void RpcReader___Observers_Set_Client_181508341(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Set_Client_181508341(NetworkConnection connection, Vector3 position, Vector3 faceDir, int itemToEquipIndex = -1);
    private void RpcReader___Target_Set_Client_181508341(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_StartAct_328543758(NetworkConnection conn);
    public void RpcLogic___StartAct_328543758(NetworkConnection conn);
    private void RpcReader___Observers_StartAct_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_StartAct_328543758(NetworkConnection conn);
    private void RpcReader___Target_StartAct_328543758(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}