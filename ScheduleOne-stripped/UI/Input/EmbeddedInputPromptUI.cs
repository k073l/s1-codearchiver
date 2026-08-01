using System;
using ScheduleOne.CustomUI;
using ScheduleOne.DevUtilities;
using TMPro;
using UnityEngine;
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
    [SerializeField]
    private LayoutElement _layoutElement;
    [Header("Settings")]
    [SerializeField]
    private bool _runOnlyWithGamepad;
    [SerializeField]
    private bool _useInputSpriteVariation;
    [SerializeField]
    private ActionBindingReference _actionBindingReference;
    private bool _isActive;
    public void Start();
    public void OnEnable();
    public void OnDisable();
    public void SetActive(bool isActive);
    private void ShowPrompt();
    public void UpdatePrompt(InputPromptsBindingData bindingData);
    private void OnInputDeviceChanged(GameInput.InputDeviceType newInputDevice);
}