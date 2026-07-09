using System;
using System.Collections.Generic;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.Gamepad;
public class GamepadPointer : PersistentSingleton<GamepadPointer>
{
    public enum EGamepadJoystickType
    {
        Left,
        Right
    }

    [Header("Components")]
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private RectTransform _container;
    [SerializeField]
    private RectTransform _pointer;
    [SerializeField]
    private Graphic _pointerGraphic;
    [Header("Settings")]
    [SerializeField]
    private GamepadPointerData _defaultData;
    [SerializeField]
    private GamepadPointerLureData _defaultLureData;
    [SerializeField]
    private float _modifier;
    [Tooltip("Maximum speed reduction when perfectly centered and aiming at the lure (0 = no friction, 0.9 = 90% slower)")]
    [SerializeField]
    [Range(0f, 0.95f)]
    private float _maxFriction;
    [SerializeField]
    private AnimationCurve _frictionCurve;
    [Header("Data")]
    [SerializeField]
    private List<GamepadPointerData> _pointerDataList;
    [SerializeField]
    private List<GamepadPointerLureData> _pointerLureDataList;
    [Header("Development")]
    [SerializeField]
    [Range(0f, 1f)]
    private float _debugDirectionMatch;
    private GamepadPointerData _lastPointerData;
    private GamepadPointerData _currentData;
    private Dictionary<string, GamepadPointerData> _dataLookup;
    private Dictionary<string, GamepadPointerLureData> _lureDataLookup;
    private List<IGamepadPointerLure> _activeLures;
    private IGamepadPointerLure _currentLure;
    private IGamepadPointerHandler _handler;
    private float _previousRotationAngle;
    private bool _isTrackingRotation;
    private float _rotationDeadzone;
    private bool _runRotationInputCheck;
    private Vector2 _currentVelocity;
    private float _currentDistanceToLure;
    private float _sensitivity;
    private bool _isInteractingWithLure;
    private bool _isActive;
    private bool _isGamePad;
    private bool _isLocked;
    private bool _isAimAssistActive;
    private const float REFERENCE_HEIGHT;
    protected float ResolutionScale => (float)Screen.height / 1080f;
    protected float Acceleration => _currentData.Acceleration * _modifier * ResolutionScale * _sensitivity;
    protected float Decceleration => _currentData.Decceleration * _modifier * ResolutionScale * _sensitivity;
    protected float Speed => _currentData.Speed * _modifier * ResolutionScale * _sensitivity;
    public float? RotationDelta { get; private set; }
    public bool IsRotationInputActive => _runRotationInputCheck;

    protected override void Awake();
    protected override void Start();
    private void Update();
    private void Initialise();
    public IGamepadPointerLure GetNearestLure(Vector2 screenPos, out Vector2 lureScreenPos);
    public List<IGamepadPointerLure> GetActiveLures();
    public Vector2 GetClampedPositionFromVelocity(Vector2 velocity);
    public Vector2 GetClampedPosition(Vector2 pos);
    private void OnInputChange(GameInput.InputDeviceType deviceType);
    private void UpdateVisibility();
    private bool IsRunning();
    private Vector2 GetJoystickInput(EGamepadJoystickType joystickType);
    private void HandleRotationInput();
    private float? GetRotationDelta(Vector2 input);
    public float GetJoystickMagnitude(Vector2 direction = default(Vector2), EGamepadJoystickType joystickType = EGamepadJoystickType.Right);
    public void SetHandler(IGamepadPointerHandler handler);
    public void SetActive(bool value);
    public void SetActive(bool value, Vector2 startScreenPosition);
    public void MoveToScreenCenter();
    public void SetSensitivity(float sensitivity);
    public void SetAimAssist(bool value);
    public void SetPointerData(GamepadPointerData data);
    public void SetPointerData(string id);
    public void RevertPointerData();
    public GamepadPointerLureData GetLureData(string id);
    public void SetGraphic(Texture2D texture, Vector2 hotSpot);
    public Vector3 GetPointerScreenPosition();
    public void RegisterLure(IGamepadPointerLure lure);
    public void UnregisterLure(IGamepadPointerLure lure);
    public void SetRotationInputCheckActive(bool active);
    public void SetPointerLocked(bool locked);
    public static float ConvertRadiusToScreenUnits(Vector3 worldPosition, float radius);
    [Button]
    public void DebugToggleActive();
    [Button]
    public void SetToSnapHandler();
}