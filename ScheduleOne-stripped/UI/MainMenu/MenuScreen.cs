using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using ScheduleOne.UI.Multiplayer;
using UnityEngine;

namespace ScheduleOne.UI.MainMenu;
public class MenuScreen : MonoBehaviour
{
    private const float LerpTime;
    private const float LerpScale;
    [Header("Settings")]
    public int ExitInputPriority;
    public bool OpenOnStart;
    public bool AttachLobbyToScreen;
    [Header("References")]
    public MenuScreen PreviousScreen;
    public CanvasGroup Group;
    public MonoState State;
    [Header("Custom UI")]
    public UIScreen uiScreen;
    public UIPanel uiPanel;
    private RectTransform rect;
    private Coroutine lerpRoutine;
    public static MenuScreen Current { get; private set; }
    public bool IsOpen { get; protected set; }

    protected virtual void Awake();
    private void Start();
    protected virtual void Exit(ExitAction action);
    public void Open(bool b);
    public void Open();
    public void Close();
    protected virtual void OnOpen();
    protected virtual void OnClose();
    private void Lerp(bool open);
}