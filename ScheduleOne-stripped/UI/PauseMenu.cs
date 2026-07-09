using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.Platform;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Reporting;
using ScheduleOne.State;
using ScheduleOne.Tools;
using ScheduleOne.UI.MainMenu;
using ScheduleOne.Vehicles;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace ScheduleOne.UI;
public class PauseMenu : Singleton<PauseMenu>
{
    public Canvas Canvas;
    public RectTransform Container;
    public MenuScreen Screen;
    public MonoStateMachine State;
    public InputActionReference TogglePauseAction;
    public TextMeshProUGUI CartelNameLabel;
    public PreallocatedAction onPause;
    public PreallocatedAction onResume;
    private bool _togglePausePressedThisFrame;
    public bool IsPaused { get; protected set; }

    protected override void Awake();
    protected override void Start();
    private void PlatformEvents_OnGameLoseFocus();
    private void Exit(ExitAction action);
    private bool CanTogglePause();
    protected override void OnDestroy();
    private void PrepForScreenshot();
    private void UpdateCartelName();
    private void CleanupScreenshot();
    private void Update();
    private void CheckTogglePause();
    private void LateUpdate();
    public void Pause();
    public void Resume();
    public void StuckButtonClicked();
}