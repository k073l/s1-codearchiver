using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.UI.Input;
public class InputPromptObj : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private InputPromptsItemUI _inputPromptItemUI;
    [SerializeField]
    private Transform _container;
    [Header("Settings")]
    [SerializeField]
    private InputPromptsData _promptData;
    [SerializeField]
    private bool _runOnEnable;
    [Header("Animation")]
    [SerializeField]
    private bool _enablePulseAnimation;
    private bool _isActive;
    private void OnEnable();
    private void OnDisable();
    private void Start();
    public void SetActive(bool value);
    private void ShowPrompt();
    private void HidePrompt();
    private void OnInputDeviceChanged(GameInput.InputDeviceType newInputDevice);
}