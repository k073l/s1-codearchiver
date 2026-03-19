using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne;
public class UISwitchInputModeDetector : MonoBehaviour
{
    public UnityEvent OnInputModeChanged;
    public UnityEvent OnInputModeChangedToController;
    public UnityEvent OnInputModeChangedToMouse;
    private void Start();
    private void OnControlsChanged(GameInput.InputDeviceType type);
    private void SwitchMode(GameInput.InputDeviceType type);
}