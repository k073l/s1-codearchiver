using System;
using FishNet.Object;
using ScheduleOne.AvatarFramework.Animation;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Misc;
using ScheduleOne.Props;
using UnityEngine;

namespace ScheduleOne.Vehicles;
public class Motorbike : NetworkBehaviour, IProp
{
    [Header("Components")]
    [SerializeField]
    private AvatarSeat _seat;
    [SerializeField]
    private MotorbikeBurnout _burnoutController;
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private ToggleableLight _headlight;
    [SerializeField]
    private Collider[] _colliders;
    [Header("Settings")]
    [SerializeField]
    private bool _headlightsOn;
    [Tooltip("Enable or disable automatic headlights based on the time of day.")]
    [SerializeField]
    private bool _automaticHeadlights;
    [SerializeField]
    private int _headlightActivationTime;
    [SerializeField]
    private int _headlightDisableTime;
    private int _id;
    private Vector3 _defaultPosition;
    private Quaternion _defaultRotation;
    private Coroutine _checkKnockedOverRoutine;
    private bool _isInitialised;
    private bool _isUpright;
    private bool NetworkInitialize___EarlyScheduleOne_002EVehicles_002EMotorbikeAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EVehicles_002EMotorbikeAssembly_002DCSharp_002Edll_Excuted;
    public int Id => _id;
    public Collider[] Colliders => _colliders;
    public MotorbikeBurnout BurnoutController => _burnoutController;
    public AvatarSeat Seat => _seat;

    public event Action<int> OnKnockedOver;
    private void Start();
    private void OnEnable();
    private void OnDestroy();
    public override void OnStartServer();
    public void SetId(int id);
    public void Reposition();
    public bool IsUpright();
    private bool IsWithinRangeOfInitialPosition();
    private void FixedUpdate();
    private void CheckIsUpright();
    private void OnUncappedMinPass();
    public void OverrideAutomaticHeadlights(bool active);
    public void SetHeadlights(bool active);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}