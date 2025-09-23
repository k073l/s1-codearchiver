using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.NPCs;
using ScheduleOne.Vehicles;
using UnityEngine;

namespace ScheduleOne.Vision;
public class EntityVisibility : NetworkBehaviour
{
    public const float MAX_VISIBLITY;
    public List<VisibilityAttribute> ActiveAttributes;
    [Header("Settings")]
    public LayerMask VisibilityCheckMask;
    [Header("References")]
    public Transform CentralVisibilityPoint;
    public List<Transform> VisibilityPoints;
    private VisibilityAttribute environmentalVisibility;
    private Dictionary<string, Coroutine> removalRoutinesDict;
    private Dictionary<string, float> maxPointsChangesByUniquenessCode;
    private List<RaycastHit> hits;
    private bool NetworkInitialize___EarlyScheduleOne_002EVision_002EEntityVisibilityAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EVision_002EEntityVisibilityAssembly_002DCSharp_002Edll_Excuted;
    public float CurrentVisibility { get; protected set; }
    public float Suspiciousness { get; protected set; }
    public List<EntityVisualState> VisualStates { get; protected set; } = new List<EntityVisualState>();
    public Vector3 CenterPoint { get; }

    public override void Awake();
    public override void OnStartClient();
    protected virtual void FixedUpdate();
    private float CalculateVisibility();
    public VisibilityAttribute GetAttribute(string name);
    private void UpdateEnvironmentalVisibilityAttribute();
    public float CalculateExposureToPoint(Vector3 point, float checkRange = 50f, NPC checkingNPC = null);
    [ServerRpc(RunLocally = true)]
    public void ApplyState(string label, EVisualState state, float autoRemoveAfter = 0f);
    [ServerRpc(RunLocally = true)]
    public void RemoveState(string label, float delay = 0f);
    public EntityVisualState GetState(string label);
    public void ClearStates();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_ApplyState_2910447583(string label, EVisualState state, float autoRemoveAfter = 0f);
    public void RpcLogic___ApplyState_2910447583(string label, EVisualState state, float autoRemoveAfter = 0f);
    private void RpcReader___Server_ApplyState_2910447583(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_RemoveState_606697822(string label, float delay = 0f);
    public void RpcLogic___RemoveState_606697822(string label, float delay = 0f);
    private void RpcReader___Server_RemoveState_606697822(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    protected virtual void Awake_UserLogic_ScheduleOne_002EVision_002EEntityVisibility_Assembly_002DCSharp_002Edll();
}