using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.GameTime;
using ScheduleOne.Messaging;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.Messages;
public class DealWindowSelector : MonoBehaviour
{
    public const float TIME_ARM_ROTATION_0000;
    public const float TIME_ARM_ROTATION_2400;
    public const int WINDOW_CUTOFF_MINS;
    public UnityEvent<EDealWindow> OnSelected;
    [Header("References")]
    public GameObject Container;
    public WindowSelectorButton MorningButton;
    public WindowSelectorButton AfternoonButton;
    public WindowSelectorButton NightButton;
    public WindowSelectorButton LateNightButton;
    public RectTransform CurrentTimeArm;
    public Text CurrentTimeLabel;
    private Action<EDealWindow> callback;
    private WindowSelectorButton[] buttons;
    private bool hintShown;
    public bool IsOpen { get; private set; }

    private void Start();
    public void Exit(ExitAction action);
    public void SetIsOpen(bool open);
    public void SetIsOpen(bool open, MSGConversation conversation, Action<EDealWindow> callback = null);
    public void Update();
    private void UpdateTime();
    private void UpdateWindowValidity();
    private void Close();
    private void ButtonClicked(EDealWindow window);
}