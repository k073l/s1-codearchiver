using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ScheduleOne.DevUtilities;
using ScheduleOne.State;
using ScheduleOne.UI.Input;
using ScheduleOne.UI.Phone;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScheduleOne.UI;
public class HintDisplay : Singleton<HintDisplay>
{
    private class Hint
    {
        public string StandardText;
        public string GamepadText;
        public float Duration;
        public Hint(string text, float duration, string gamepadText = null);
    }

    public const float FadeTime;
    [Header("References")]
    public RectTransform Container;
    public TextMeshProUGUI Label;
    public CanvasGroup Group;
    public Animation FlashAnim;
    public InputActionReference DismissAction;
    public InputPromptObj InputPromptObj;
    [Header("Settings")]
    public Vector2 Padding;
    public Vector2 Offset;
    private Coroutine autoCloseRoutine;
    private Coroutine fadeRoutine;
    private List<Hint> hintQueue;
    private float timeSinceOpened;
    private Hint _currentHint;
    public bool IsOpen { get; protected set; }

    protected override void Start();
    public void Update();
    public void ShowHint_10s(string text, string alternateText = null);
    public void ShowHint_20s(string text, string alternateText = null);
    public void ShowHint(string text, float autoCloseTime = 0f, string alternateText = null);
    private void ProcessHint(string text, float autoCloseTime = 0f, string alternateText = null);
    private void SetHint(float autoCloseTime = 0f);
    public void Hide();
    private void SetAlpha(float alpha);
    public void QueueHint_10s(string message);
    public void QueueHint_20s(string message);
    public void QueueHint(string message, float time);
    private string ProcessText(string text);
    private string GetHintTextForCurrentDevice();
    private void HandleInputDeviceChanged(GameInput.InputDeviceType newDevice);
}