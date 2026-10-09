using System;
using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using UnityEngine;

namespace ScheduleOne.Combat;
public class NetworkedPhysicsDamageable : NetworkBehaviour, IPhysicsDamageable, IDamageable
{
    public float ForceMultiplier;
    private List<int> _impactHistory;
    private bool NetworkInitialize___EarlyScheduleOne_002ECombat_002ENetworkedPhysicsDamageableAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ECombat_002ENetworkedPhysicsDamageableAssembly_002DCSharp_002Edll_Excuted;
    public Rigidbody Rb { get; private set; }

    public event Action<Impact> OnImpacted;
    public override void Awake();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendImpact(Impact impact);
    [ObserversRpc(RunLocally = true)]
    public virtual void ReceiveImpact(Impact impact);
    GameObject IDamageable.get_gameObject();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SendImpact_427288424(Impact impact);
    public void RpcLogic___SendImpact_427288424(Impact impact);
    private void RpcReader___Server_SendImpact_427288424(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ReceiveImpact_427288424(Impact impact);
    public virtual void RpcLogic___ReceiveImpact_427288424(Impact impact);
    private void RpcReader___Observers_ReceiveImpact_427288424(PooledReader PooledReader0, Channel channel);
    protected virtual void Awake_UserLogic_ScheduleOne_002ECombat_002ENetworkedPhysicsDamageable_Assembly_002DCSharp_002Edll();
}