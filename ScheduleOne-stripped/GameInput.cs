using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

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
        Escape,
        Back,
        Interact,
        Submit,
        TogglePhone,
        VehicleToggleLights,
        VehicleHandbrake,
        RotateLeft,
        RotateRight,
        ManagementMode,
        OpenMap,
        OpenJournal,
        OpenTexts,
        QuickMove,
        ToggleFlashlight,
        ViewAvatar,
        Reload,
        InventoryLeft,
        InventoryRight,
        Holster,
        VehicleResetCamera,
        SkateboardDismount,
        SkateboardMount,
        TogglePauseMenu
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
        public static UnityAction _003C_003E9__73_0;
        internal void _003CStart_003Eb__73_0();
    }

    public static Action<InputDeviceType> OnInputDeviceChanged;
    public static List<ExitListener> exitListeners;
    public PlayerInput PlayerInput;
    public static bool IsTyping;
    public static Vector2 MotionAxis;
    public static Vector2 CameraAxis;
    public static bool TogglePauseInputUsed;
    private static Mouse systemMouse;
    public static float MouseWheelAxis;
    public static bool ControllerComboActive;
    private float vehicleDriveAxis;
    private List<ButtonCode> buttonsDownThisFrame;
    private List<ButtonCode> buttonsDown;
    private List<ButtonCode> buttonsUpThisFrame;
    public static InputDeviceType CurrentInputDevice { get; private set; }
    public static Vector2 MouseDelta => CameraAxis;
    public unsafe static Vector3 MousePosition { get; }
    public static float MouseScrollDelta => MouseWheelAxis;
    public static float VehicleDriveAxis { get; private set; }
    public static Vector2 UINavigationDirection { get; private set; }
    public static Vector2 UICyclePanelDirection { get; private set; }
    public static float UITabNavigationPrimaryAxis { get; private set; }
    public static float UITabNavigationSecondaryAxis { get; private set; }
    public static float UIScrollbarAxis { get; private set; }
    public static Vector2 UIMapNavigationDirection { get; private set; }
    public static float UIMapZoomAxis { get; private set; }
    public static float UIModifyAmountIncrementTierOneAxis { get; private set; }
    public static float UIModifyAmountIncrementTierTwoAxis { get; private set; }
    public static float UIModifyAmountIncrementTierThreeAxis { get; private set; }

    protected override void Awake();
    protected override void OnDestroy();
    protected override void Start();
    private void OnApplicationFocus(bool focus);
    public static bool GetButton(ButtonCode buttonCode);
    public static bool GetButtonDown(ButtonCode buttonCode);
    public static bool GetButtonUp(ButtonCode buttonCode);
    public static bool GetCurrentInputDeviceIsKeyboardMouse();
    public static bool GetCurrentInputDeviceIsGamepad();
    protected virtual void Update();
    private void Exit(ExitType type);
    private void LateUpdate();
    public void ExitAll();
    private void OnControlsChanged(PlayerInput input);
    private void OnMotion(InputValue value);
    private void OnPrimaryClick();
    private void OnSecondaryClick();
    private void OnTertiaryClick();
    private void OnJump();
    private void OnCrouch();
    private void OnSprint();
    private void OnEscape();
    private void OnBack();
    private void OnInteract();
    private void OnSubmit();
    private void OnTogglePhone();
    private void OnVehicleToggleLights();
    private void OnVehicleHandbrake();
    private void OnRotateLeft();
    private void OnRotateRight();
    private void OnManagementMode();
    private void OnOpenMap();
    private void OnOpenJournal();
    private void OnOpenTexts();
    private void OnQuickMove();
    private void OnToggleFlashlight();
    private void OnViewAvatar();
    private void OnReload();
    private void OnCamera(InputValue value);
    private void OnScrollWheel(InputValue value);
    private void OnInventoryLeft();
    private void OnInventoryRight();
    private void OnHolster();
    private void OnControllerCombo(InputValue value);
    private void OnVehicleResetCamera();
    private void OnVehicleDrive(InputValue value);
    private void OnSkateboardDismount();
    private void OnSkateboardMount();
    private void OnTogglePauseMenu();
    private void OnUINavigationDirection(InputValue value);
    private void OnUICyclePanelDirection(InputValue value);
    private void OnUITabNavigationPrimary(InputValue value);
    private void OnUITabNavigationSecondary(InputValue value);
    private void OnUIScrollbar(InputValue value);
    private void OnUIMapNavigationDirection(InputValue value);
    private void OnUIMapZoom(InputValue value);
    private void OnUIModifyAmountIncrementTierOne(InputValue value);
    private void OnUIModifyAmountIncrementTierTwo(InputValue value);
    private void OnUIModifyAmountIncrementTierThree(InputValue value);
    public static void RegisterExitListener(ExitDelegate listener, int priority = 0);
    public static void DeregisterExitListener(ExitDelegate listener);
    public InputAction GetAction(ButtonCode code);
}