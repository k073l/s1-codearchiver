using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using ScheduleOne.UI.Input;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class SleepCanvas : Singleton<SleepCanvas>
{
    public const int MaxSleepTime;
    public const int MinSleepTime;
    private float QueuedMessageDisplayTime;
    [Header("References")]
    public Canvas Canvas;
    public RectTransform Container;
    public UIScreen UIScreen;
    public RectTransform MenuContainer;
    public TextMeshProUGUI CurrentTimeLabel;
    public TextMeshProUGUI EndTimeLabel;
    public Button SleepButton;
    public TextMeshProUGUI SleepButtonLabel;
    public Image BlackOverlay;
    public TextMeshProUGUI SleepMessageLabel;
    public CanvasGroup SleepMessageGroup;
    public TextMeshProUGUI TimeLabel;
    public TextMeshProUGUI WakeLabel;
    public TextMeshProUGUI WaitingForHostLabel;
    public MonoState MenuState;
    public MonoStateMachine SleepingState;
    public UnityEvent onSleepFullyFaded;
    public UnityEvent onSleepEndFade;
    private List<IPostSleepEvent> queuedPostSleepEvents;
    public bool IsMenuOpen { get; protected set; }
    public string QueuedSleepMessage { get; protected set; } = string.Empty;

    protected override void Awake();
    private void Exit(ExitAction action);
    public void OpenMenu();
    private void OnMenuClosed();
    public void Update();
    private void UpdateUI();
    public void AddPostSleepEvent(IPostSleepEvent postSleepEvent);
    private void UpdateSleepButton();
    private void SleepButtonPressed();
    private void SleepStart();
    private void LerpBlackOverlay(float transparency, float lerpTime);
    public void QueueSleepMessage(string message, float displayTime = 3f);
}