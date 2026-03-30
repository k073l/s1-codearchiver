using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Law;
using ScheduleOne.Levelling;
using ScheduleOne.Map;
using ScheduleOne.NPCs;
using ScheduleOne.Police;
using ScheduleOne.UI;
using ScheduleOne.Vision;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerScripts;
public class PlayerCrimeData : NetworkBehaviour
{
    public class VehicleCollisionInstance
    {
        public NPC Victim;
        public float TimeSince;
        public VehicleCollisionInstance(NPC victim, float timeSince);
    }

    public enum EPursuitLevel
    {
        None,
        Investigating,
        Arresting,
        NonLethal,
        Lethal
    }

    public const float SEARCH_TIME_INVESTIGATING;
    public const float SEARCH_TIME_ARRESTING;
    public const float SEARCH_TIME_NONLETHAL;
    public const float SEARCH_TIME_LETHAL;
    public const float ESCALATION_TIME_ARRESTING;
    public const float ESCALATION_TIME_NONLETHAL;
    public const float SHOT_COOLDOWN_MIN;
    public const float SHOT_COOLDOWN_MAX;
    public const float VEHICLE_COLLISION_LIFETIME;
    public const float VEHICLE_COLLISION_LIMIT;
    public PoliceOfficer NearestOfficer;
    public Player Player;
    public AudioSourceController onPursuitEscapedSound;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public EPursuitLevel _003CCurrentPursuitLevel_003Ek__BackingField;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    public Vector3 _003CLastKnownPosition_003Ek__BackingField;
    public List<PoliceOfficer> Pursuers;
    public float TimeSincePursuitStart;
    public float CurrentPursuitLevelDuration;
    public float TimeSinceSighted;
    public Dictionary<Crime, int> Crimes;
    public bool BodySearchPending;
    public Action<EPursuitLevel, EPursuitLevel> onPursuitLevelChange;
    protected List<VehicleCollisionInstance> Collisions;
    public SyncVar<EPursuitLevel> syncVar____003CCurrentPursuitLevel_003Ek__BackingField;
    public SyncVar<Vector3> syncVar____003CLastKnownPosition_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EPlayerScripts_002EPlayerCrimeDataAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EPlayerScripts_002EPlayerCrimeDataAssembly_002DCSharp_002Edll_Excuted;
    public EPursuitLevel CurrentPursuitLevel {[CompilerGenerated]
        get; [CompilerGenerated]
        protected set; }
    public Vector3 LastKnownPosition {[CompilerGenerated]
        get; [CompilerGenerated]
        [ServerRpc(RunLocally = true)]
        protected set; } = Vector3.zero;
    public float CurrentArrestProgress { get; protected set; }
    public float CurrentBodySearchProgress { get; protected set; }
    public int MinsSinceLastArrested { get; set; } = 9999;
    public float TimeSinceLastBodySearch { get; set; } = 100000f;
    public bool EvadedArrest { get; protected set; }
    public EPursuitLevel SyncAccessor__003CCurrentPursuitLevel_003Ek__BackingField { get; set; }
    public Vector3 SyncAccessor__003CLastKnownPosition_003Ek__BackingField { get; set; }

    public override void Awake();
    private void Start();
    private void OnDestroy();
    protected virtual void Update();
    private void MinPass();
    protected virtual void LateUpdate();
    public void SetPursuitLevel(EPursuitLevel level);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    private void SetPursuitLevel_Server(EPursuitLevel level);
    public void Escalate();
    public void Deescalate();
    [ObserversRpc(RunLocally = true)]
    public void RecordLastKnownPosition(bool resetTimeSinceSighted);
    public void SetArrestProgress(float progress);
    public void ResetBodysearchCooldown();
    public void SetBodySearchProgress(float progress);
    private void OnDie();
    public void AddCrime(Crime crime, int quantity = 1);
    public void ClearCrimes();
    public bool IsCrimeOnRecord(Type crime);
    public void SetEvaded();
    private void OnSleepStart();
    private void UpdateEscalation();
    private void UpdateTimeout();
    private void TimeoutPursuit();
    public float GetSearchTime();
    public float GetShotAccuracyMultiplier();
    public void RecordVehicleCollision(NPC victim);
    private void CheckNearestOfficer();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_set_LastKnownPosition_4276783012(Vector3 value);
    [SpecialName]
    protected void RpcLogic___set_LastKnownPosition_4276783012(Vector3 value);
    private void RpcReader___Server_set_LastKnownPosition_4276783012(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SetPursuitLevel_Server_2979171596(EPursuitLevel level);
    private void RpcLogic___SetPursuitLevel_Server_2979171596(EPursuitLevel level);
    private void RpcReader___Server_SetPursuitLevel_Server_2979171596(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_RecordLastKnownPosition_1140765316(bool resetTimeSinceSighted);
    public void RpcLogic___RecordLastKnownPosition_1140765316(bool resetTimeSinceSighted);
    private void RpcReader___Observers_RecordLastKnownPosition_1140765316(PooledReader PooledReader0, Channel channel);
    public override bool ReadSyncVar___ScheduleOne_002EPlayerScripts_002EPlayerCrimeData(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    private void Awake_UserLogic_ScheduleOne_002EPlayerScripts_002EPlayerCrimeData_Assembly_002DCSharp_002Edll();
}