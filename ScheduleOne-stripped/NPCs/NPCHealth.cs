using System;
using System.Collections;
using System.Runtime.CompilerServices;
using FishNet;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs;
[RequireComponent(typeof(NPCHealth))]
[DisallowMultipleComponent]
public class NPCHealth : NetworkBehaviour
{
    public const int REVIVE_DAYS;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public float _003CHealth_003Ek__BackingField;
    [Header("Settings")]
    public bool Invincible;
    public float MaxHealth;
    public bool CanRevive;
    private NPC npc;
    public UnityEvent onDie;
    public UnityEvent onKnockedOut;
    public UnityEvent onDieOrKnockedOut;
    public UnityEvent onRevive;
    public Action<float> onTakeDamage;
    private bool AfflictedWithLethalEffect;
    public SyncVar<float> syncVar____003CHealth_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ENPCHealthAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ENPCHealthAssembly_002DCSharp_002Edll_Excuted;
    public float Health {[CompilerGenerated]
        get; [CompilerGenerated]
        private set; }
    public float NormalizedHealth { get; }
    public bool IsDead { get; private set; }
    public bool IsKnockedOut { get; private set; }
    public int DaysPassedSinceDeath { get; private set; }
    public int HoursSinceAttackedByPlayer { get; private set; } = 9999;
    public float SyncAccessor__003CHealth_003Ek__BackingField { get; set; }

    public override void Awake();
    private void Start();
    private void OnDestroy();
    public override void OnStartServer();
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