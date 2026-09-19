using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class SleepMenu : Singleton<SleepMenu>
{
    [Header("References")]
    public Canvas Canvas;
    public RectTransform Container;
    public UIScreen UIScreen;
    public RectTransform MenuContainer;
    public TextMeshProUGUI CurrentTimeLabel;
    public TextMeshProUGUI EndTimeLabel;
    public Button SleepButton;
    public TextMeshProUGUI SleepButtonLabel;
    public TextMeshProUGUI TimeLabel;
    public TextMeshProUGUI WakeLabel;
    public TextMeshProUGUI WaitingForHostLabel;
    public MonoState MenuState;
    public bool IsMenuOpen { get; protected set; }

    protected override void Awake();
    private void Exit(ExitAction action);
    public void OpenMenu();
    private void OnMenuClosed();
    public void Update();
    private void UpdateUI();
    private void UpdateSleepButton();
    private void SleepButtonPressed();
    private void OnSleepStart();
}