using System;
using System.Collections.Generic;
using EasyButtons;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.Audio;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.WorldspacePopup;
using ScheduleOne.Vehicles;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace ScheduleOne.Vision;
public class VisionCone : NetworkBehaviour
{
    public enum EEventLevel
    {
        Start,
        Half,
        Full,
        Zero
    }

    [Serializable]
    public class StateContainer
    {
        public EVisualState state;
        public bool Enabled;
        [Range(0.5f, 4f)]
        public float NoticeTimeMultiplier;
        public float RequiredNoticeTime => 0.2f * NoticeTimeMultiplier;

        public StateContainer GetCopy();
    }

    public class SightableData
    {
        public ISightable Sightable;
        public float VisionDelta;
        public float TimeVisible;
    }

    public delegate void EventStateChange(VisionEventReceipt _event);
    public const float VISION_UPDATE_INTERVAL;
    public const float MinVisionDelta;
    public static float UniversalAttentivenessScale;
    public static float UniversalMemoryScale;
    public const float HorizontalFOV;
    public const float VerticalFOV;
    public const float Range;
    public const float MinorWidth;
    public const float MinorHeight;
    public bool DEBUG;
    public Transform VisionOrigin;
    [Header("Vision Settings")]
    public AnimationCurve VisionFalloff;
    public LayerMask VisibilityBlockingLayers;
    [Range(0f, 2f)]
    public float RangeMultiplier;
    [Header("Interest settings")]
    [FormerlySerializedAs("StatesOfInterest")]
    public List<StateContainer> DefaultStatesOfInterest;
    [Header("Notice Settings")]
    public float Attentiveness;
    public float Memory;
    [Header("Sound Settings")]
    public bool UseTremoloSound;
    [Header("Worldspace Icons")]
    public bool WorldspaceIconsEnabled;
    public WorldspacePopup QuestionMarkPopup;
    public WorldspacePopup ExclamationPointPopup;
    public AudioSourceController ExclamationSound;
    public EventStateChange onVisionEventStarted;
    public EventStateChange onVisionEventHalf;
    public EventStateChange onVisionEventFull;
    public EventStateChange onVisionEventExpired;
    protected List<ISightable> sightablesOfInterest;
    protected Dictionary<ISightable, SightableData> sightableDatas;
    protected Dictionary<ISightable, Dictionary<EVisualState, StateContainer>> stateSettings;
    protected List<VisionEvent> activeVisionEvents;
    protected List<VisionEvent> cachedVisionEvents;
    protected NPC npc;
    protected bool noticeGeneralCrime;
    protected List<ISightable> sightablesSeenThisFrame;
    protected List<ISightable> toRemove;
    private bool NetworkInitialize___EarlyScheduleOne_002EVision_002EVisionConeAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EVision_002EVisionConeAssembly_002DCSharp_002Edll_Excuted;
    protected float effectiveRange => 25f * RangeMultiplier;

    public override void Awake();
    private void PlayerSpawned(Player plr);
    private void OnEnable();
    private void OnDisable();
    protected virtual void VisionUpdate();
    protected virtual void UpdateEvents(float tickTime);
    protected virtual void UpdateVision(float tickTime);
    public virtual void EventReachedZero(VisionEvent _event);
    public virtual void EventHalfNoticed(VisionEvent _event);
    public virtual void EventFullyNoticed(VisionEvent _event);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SendEventReceipt(VisionEventReceipt receipt, EEventLevel level);
    [ObserversRpc(RunLocally = true, ExcludeOwner = true)]
    public virtual void ReceiveEventReceipt(VisionEventReceipt receipt, EEventLevel level);
    public void AddSightableOfInterest(ISightable s);
    public void RemoveSightableOfInterest(ISightable s);
    public void SetSightableStateEnabled(ISightable sightable, EVisualState state, bool enabled);
    [Button]
    public void PrintSightableStates();
    public virtual bool IsPointWithinSight(Vector3 point, bool ignoreLoS = false, LandVehicle vehicleToIgnore = null);
    public VisionEvent GetEvent(ISightable target, EntityVisualState state);
    public bool IsPlayerVisible(Player player);
    public bool WasSightableVisibleThisFrame(ISightable sightable);
    public bool IsTargetVisible(ISightable target);
    public float GetPlayerVisibility(Player player);
    public bool IsPlayerVisible(Player player, out SightableData data);
    public virtual void SetNoticePlayerCrimes(Player player, bool active);
    private void OnDie();
    public void ClearEvents();
    private Vector3[] GetFrustumVertices();
    private Plane[] GetFrustumPlanes();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SendEventReceipt_3486014028(VisionEventReceipt receipt, EEventLevel level);
    public void RpcLogic___SendEventReceipt_3486014028(VisionEventReceipt receipt, EEventLevel level);
    private void RpcReader___Server_SendEventReceipt_3486014028(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ReceiveEventReceipt_3486014028(VisionEventReceipt receipt, EEventLevel level);
    public virtual void RpcLogic___ReceiveEventReceipt_3486014028(VisionEventReceipt receipt, EEventLevel level);
    private void RpcReader___Observers_ReceiveEventReceipt_3486014028(PooledReader PooledReader0, Channel channel);
    protected virtual void Awake_UserLogic_ScheduleOne_002EVision_002EVisionCone_Assembly_002DCSharp_002Edll();
}