using System;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.UI;

namespace ScheduleOne;
public class OnScreenMouse : Singleton<OnScreenMouse>
{
    private static readonly Vector2 CURSOR_COORDINATE_REFERENCE;
    [Tooltip("Unity new input system virtual mouse")]
    public VirtualMouseInput ptrComponent;
    private Mouse systemMouse;
    private new void Awake();
    private void OnInputDeviceChanged(GameInput.InputDeviceType type);
    private void OnEnable();
    private void OnDisable();
    private void Update();
    public void Activate();
    public void Deactivate();
    public void SetTexture(Texture tex, Vector2 hotSpot);
    private void SetVirtualMouseEnabled(bool isOn);
    private void UpdateSystemMouseValues();
}