using System;
using ScheduleOne.DevUtilities;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ScheduleOne.UI.Input;
public class EmbeddedInputPromptUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Image _promptImage;
    [SerializeField]
    private TextMeshProUGUI _promptImageLabel;
    [SerializeField]
    private Transform _promptContainer;
    [Header("Settings")]
    [SerializeField]
    private bool _runOnlyWithGamepad;
    [SerializeField]
    private InputActionReference _actionReference;
    private bool _isActive;
    public bool IsActive => _isActive;

    public void Start();
    public void SetActive(bool isActive);
    private void ShowPrompt();
    public void UpdatePrompt(InputPromptsBindingData bindingData);
    private void OnInputDeviceChanged(GameInput.InputDeviceType newInputDevice);
}