using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ScheduleOne.DevUtilities;
using ScheduleOne.Gamepad;
using ScheduleOne.Persistence;
using ScheduleOne.Platform;
using ScheduleOne.UI.Input;
using ScheduleOne.UI.Items;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.Switch;
using UnityEngine.InputSystem.XInput;

namespace ScheduleOne;
public class GameInput : PersistentSingleton<GameInput>
{
    public enum ButtonCode
    {
        PrimaryClick,
        SecondaryClick,
        TertiaryClick,
        Forward,
        Backward,
        Left,
        Right,
        Jump,
        Crouch,
        Sprint,
        Interact,
        Submit,
        VehicleToggleLights,
        VehicleHandbrake,
        Reload,
        InventoryLeft,
        InventoryRight,
        VehicleResetCamera,
        SkateboardDismount,
        SkateboardMount
    }

    public enum InputDeviceType
    {
        KeyboardMouse,
        Gamepad
    }

    public class ExitListener
    {
        public ExitDelegate listenerFunction;
        public int priority;
    }

    public delegate void ExitDelegate(ExitAction exitAction);
    [Serializable]
    [CompilerGenerated]
    private sealed class _003C_003Ec
    {
        public static readonly _003C_003Ec _003C_003E9;
        public static UnityAction _003C_003E9__86_0;
        internal void _003CStart_003Eb__86_0();
    }

    public static Action<InputDeviceType> OnInputDeviceChanged;
    public static List<ExitListener> exitListeners;
    public PlayerInput PlayerInput;
    public InputActionReference PrimaryExitAction;
    public InputActionReference SecondaryExitAction;
    private static bool _isTyping;
    public static Vector2 MotionAxis;
    public static Vector2 CameraAxis;
    private static Mouse systemMouse;
    private static Vector2 MouseWheelAxis;
    public static bool ControllerComboActive;
    private float vehicleDriveAxis;
    private List<ButtonCode> buttonsDownThisFrame;
    private List<ButtonCode> buttonsDown;
    private List<ButtonCode> buttonsUpThisFrame;
    private float _timeOnLastRebind;
    public static InputDeviceType CurrentInputDevice { get; private set; }
    public static EPlatformType CurrentPlatformType { get; private set; }
    public static bool IsTyping { get; set; }
    public static Vector2 MouseDelta => CameraAxis;
    public unsafe static Vector3 MousePosition { get; }
    public static float MouseScrollDelta => MouseWheelAxis.y;
    public static float VehicleDriveAxis { get; private set; }
    public static Vector2 UINavigationDirection { get; private set; }
    public static Vector2 UICyclePanelDirection { get; private set; }
    public static float UITabNavigationPrimaryAxis { get; private set; }
    public static float UITabNavigationSecondaryAxis { get; private set; }
    public static float UITabNavigationTertiaryAxis { get; private set; }
    public static float UIScrollbarAxis { get; private set; }
    public static Vector2 UIMapNavigationDirection { get; private set; }
    public static float UIMapZoomAxis { get; private set; }
    public static float UIModifyAmountIncrementTierOneAxis { get; private set; }
    public static float UIModifyAmountIncrementTierTwoAxis { get; private set; }
    public static float UIModifyAmountIncrementTierThreeAxis { get; private set; }

    protected override void OnDestroy();
    protected override void Awake();
    protected override void Start();
    private void OnApplicationFocus(bool focus);
    public static bool GetButton(ButtonCode buttonCode);
    public static bool GetButtonDown(ButtonCode buttonCode);
    public static bool GetButtonUp(ButtonCode buttonCode);
    public static bool GetCurrentInputDeviceIsKeyboardMouse();
    public static bool GetCurrentInputDeviceIsGamepad();
    public static InputDeviceType GetCurrentInputDevice();
    private void Update();
    private void LateUpdate();
    private void HandleExitInputs();
    private void Exit(ExitType type);
    public void ExitAll();
    public static Vector3 GetPointerPosition();
    private void OnControlsChanged(PlayerInput input);
    private void SetCurrentPlatformType();
    private void OnMotion(InputValue value);
    private void OnPrimaryClick();
    private void OnSecondaryClick();
    private void OnTertiaryClick();
    private void OnJump();
    private void OnCrouch();
    private void OnSprint();
    private void OnInteract();
    private void OnSubmit();
    private void OnVehicleToggleLights();
    private void OnVehicleHandbrake();
    private void OnReload();
    private void OnCamera(InputValue value);
    private void OnScrollWheel(InputValue value);
    private void OnInventoryLeft();
    private void OnInventoryRight();
    private void OnControllerCombo(InputValue value);
    private void OnVehicleResetCamera();
    private void OnVehicleDrive(InputValue value);
    private void OnSkateboardDismount();
    private void OnSkateboardMount();
    private void OnUINavigationDirection(InputValue value);
    private void OnUICyclePanelDirection(InputValue value);
    private void OnUITabNavigationPrimary(InputValue value);
    private void OnUITabNavigationSecondary(InputValue value);
    private void OnUITabNavigationTertiary(InputValue value);
    private void OnUIScrollbar(InputValue value);
    private void OnUIMapNavigationDirection(InputValue value);
    private void OnUIMapZoom(InputValue value);
    private void OnUIModifyAmountIncrementTierOne(InputValue value);
    private void OnUIModifyAmountIncrementTierTwo(InputValue value);
    private void OnUIModifyAmountIncrementTierThree(InputValue value);
    public static void RegisterExitListener(ExitDelegate listener, int priority = 0);
    public static void DeregisterExitListener(ExitDelegate listener);
    public static void RegisterExitListener(Action exitMethod, Func<bool> condition, int priority = 0, bool primaryExitOnly = false);
    public InputAction GetAction(ButtonCode code);
}