using System;
using System.Collections;
using FishNet;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.NPCs.Framework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs;
[DisallowMultipleComponent]
public class NPCHealth : NetworkBehaviour
{
    public UnityEvent onDie;
    public UnityEvent onKnockedOut;
    public UnityEvent onDieOrKnockedOut;
    public UnityEvent onRevive;
    [SyncVar( /*Could not decode attribute arguments.*/)]
    [HideInInspector]
    public float _currentHealth;
    private NPC _npc;
    private bool _invincible;
    private bool _afflictedWithLethalEffect;
    private bool _canRevive;
    private int _daysToRevive;
    public SyncVar<float> syncVar____currentHealth;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ENPCHealthAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ENPCHealthAssembly_002DCSharp_002Edll_Excuted;
    public float Health => SyncAccessor__currentHealth;
    public float NormalizedHealth { get; }
    public bool IsDead { get; private set; }
    public bool IsKnockedOut { get; private set; }
    public int DaysPassedSinceDeath { get; private set; }
    public int HoursSinceAttackedByPlayer { get; private set; } = 9999;
    public float MaxHealth { get; private set; } = 100f;
    public float SyncAccessor__currentHealth { get; set; }

    public event Action<float> onTakeDamage;
    public override void Awake();
    private void OnDestroy();
    public override void OnStartServer();
    public void SetHealthData(Health healthData);
    public void ResetToDefault();
    public void Load(NPCHealthData healthData);
    private IEnumerator AfflictWithLethalEffect();
    protected virtual void OnHourPass();
    public void SetAfflictedWithLethalEffect(bool value);
    public void SleepStart();
    public virtual void NotifyAttackedByPlayer(Player player);
    public void TakeDamage(float damage, bool isLethal = true);
    public virtual void Die();
    public virtual void KnockOut();
    public virtual void Revive();
    public void RestoreHealth();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override bool ReadSyncVar___ScheduleOne_002ENPCs_002ENPCHealth(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002ENPCHealth_Assembly_002DCSharp_002Edll();
}