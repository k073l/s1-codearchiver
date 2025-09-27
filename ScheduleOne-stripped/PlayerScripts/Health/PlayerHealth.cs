using System;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerScripts.Health;
public class PlayerHealth : NetworkBehaviour
{
    public const float MAX_HEALTH;
    public const float HEALTH_RECOVERY_PER_MINUTE;
    [Header("References")]
    public Player Player;
    public UnityEvent<float> onHealthChanged;
    public UnityEvent onDie;
    public UnityEvent onRevive;
    private bool AfflictedWithLethalEffect;
    private bool NetworkInitialize___EarlyScheduleOne_002EPlayerScripts_002EHealth_002EPlayerHealthAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EPlayerScripts_002EHealth_002EPlayerHealthAssembly_002DCSharp_002Edll_Excuted;
    public bool IsAlive { get; protected set; } = true;
    public float CurrentHealth { get; protected set; } = 100f;
    public float TimeSinceLastDamage { get; protected set; }
    public bool CanTakeDamage { get; }

    public override void Awake();
    private void Start();
    [ObserversRpc]
    public void TakeDamage(float damage, bool flinch = true, bool playBloodMist = true);
    private void Update();
    private void MinPass();
    public void SetAfflictedWithLethalEffect(bool value);
    public void RecoverHealth(float recovery);
    public void SetHealth(float health);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendDie();
    [ObserversRpc(RunLocally = true)]
    public void Die();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendRevive(Vector3 position, Quaternion rotation);
    [ObserversRpc(RunLocally = true, ExcludeOwner = true)]
    public void Revive(Vector3 position, Quaternion rotation);
    [ObserversRpc]
    public void PlayBloodMist();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_TakeDamage_3505310624(float damage, bool flinch = true, bool playBloodMist = true);
    public void RpcLogic___TakeDamage_3505310624(float damage, bool flinch = true, bool playBloodMist = true);
    private void RpcReader___Observers_TakeDamage_3505310624(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendDie_2166136261();
    public void RpcLogic___SendDie_2166136261();
    private void RpcReader___Server_SendDie_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_Die_2166136261();
    public void RpcLogic___Die_2166136261();
    private void RpcReader___Observers_Die_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendRevive_3848837105(Vector3 position, Quaternion rotation);
    public void RpcLogic___SendRevive_3848837105(Vector3 position, Quaternion rotation);
    private void RpcReader___Server_SendRevive_3848837105(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_Revive_3848837105(Vector3 position, Quaternion rotation);
    public void RpcLogic___Revive_3848837105(Vector3 position, Quaternion rotation);
    private void RpcReader___Observers_Revive_3848837105(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_PlayBloodMist_2166136261();
    public void RpcLogic___PlayBloodMist_2166136261();
    private void RpcReader___Observers_PlayBloodMist_2166136261(PooledReader PooledReader0, Channel channel);
    private void Awake_UserLogic_ScheduleOne_002EPlayerScripts_002EHealth_002EPlayerHealth_Assembly_002DCSharp_002Edll();
}