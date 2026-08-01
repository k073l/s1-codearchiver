using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Input;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.UI.Compass;
using ScheduleOne.UI.Items;
using UnityEngine;

namespace ScheduleOne.State;
[Serializable]
public struct StateProperties
{
    public enum EPreset
    {
        Unenforced,
        UIDefault,
        Vehicle,
        UIWithBlur,
        Task,
        UINoInventory,
        Cutscene
    }

    public enum EMouseState
    {
        Unenforced,
        Free,
        Locked
    }

    public enum ECrosshairState
    {
        Unenforced,
        Visible,
        Hidden
    }

    public enum EEquippingState
    {
        Unenforced,
        Enabled,
        Disabled
    }

    public enum EInventoryState
    {
        Unenforced,
        Interactable,
        NonInteractable,
        Disabled
    }

    public enum EHUDState
    {
        Unenforced,
        Visible,
        Hidden
    }

    public enum EMovementState
    {
        Unenforced,
        Free,
        Locked
    }

    public enum ELookState
    {
        Unenforced,
        Free,
        Locked
    }

    public enum EBlurState
    {
        Unenforced,
        Enabled,
        Disabled
    }

    public enum ECompassState
    {
        Unenforced,
        Visible,
        Hidden
    }

    public EMouseState MouseState;
    public ECrosshairState Crosshair;
    public EEquippingState Equipping;
    public EInventoryState Inventory;
    public EHUDState HUD;
    public ECompassState Compass;
    public EMovementState Movement;
    public ELookState CameraLook;
    public EBlurState Blur;
    public PlayerCamera.ECameraMode CameraMode;
    public static readonly StateProperties Unenforced;
    public static readonly StateProperties UIDefault;
    public static readonly StateProperties UIWithBlur;
    public static readonly StateProperties Vehicle;
    public static readonly StateProperties Skateboard;
    public static readonly StateProperties Task;
    public static readonly StateProperties UINoInventory;
    public static readonly StateProperties Cutscene;
    public StateProperties(EMouseState mouseState = EMouseState.Unenforced, ECrosshairState crosshairVisible = ECrosshairState.Unenforced, EEquippingState equippingEnabled = EEquippingState.Unenforced, EInventoryState inventoryEnabled = EInventoryState.Unenforced, EHUDState hudVisible = EHUDState.Unenforced, ECompassState compassVisible = ECompassState.Unenforced, EMovementState canMove = EMovementState.Unenforced, ELookState canLook = ELookState.Unenforced, EBlurState blur = EBlurState.Unenforced, PlayerCamera.ECameraMode cameraMode = PlayerCamera.ECameraMode.Default);
    public override string ToString();
    public static void Transition(StateProperties from, StateProperties to);
    public static StateProperties GetPreset(EPreset preset);
}