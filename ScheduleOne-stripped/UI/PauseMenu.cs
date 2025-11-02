using System;
using ScheduleOne.AvatarFramework.Customization;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.MainMenu;
using UnityEngine;

namespace ScheduleOne.UI;
public class PauseMenu : Singleton<PauseMenu>
{
    public Canvas Canvas;
    public RectTransform Container;
    public MainMenuScreen Screen;
    public FeedbackForm FeedbackForm;
    private bool noActiveUIElements;
    private bool justPaused;
    private bool justResumed;
    private bool couldLook;
    private bool lockedMouse;
    private bool crosshairVisible;
    private bool hudVisible;
    public Action onPause;
    public Action onResume;
    public bool IsPaused { get; protected set; }

    protected override void Awake();
    protected override void Start();
    private void Exit(ExitAction action);
    private void Update();
    private void LateUpdate();
    public void Pause();
    public void Resume();
    public void StuckButtonClicked();
}