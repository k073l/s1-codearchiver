using System.Collections;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.UI.MainMenu;
public class MainMenuScreen : MonoBehaviour
{
    public const float LERP_TIME;
    public const float LERP_SCALE;
    [Header("Settings")]
    public int ExitInputPriority;
    public bool OpenOnStart;
    [Header("References")]
    public MainMenuScreen PreviousScreen;
    public CanvasGroup Group;
    [Header("Custom UI")]
    public UIScreen uiScreen;
    public UIPanel uiPanel;
    private RectTransform Rect;
    private Coroutine lerpRoutine;
    public bool IsOpen { get; protected set; }

    protected virtual void Awake();
    private void OnDestroy();
    protected virtual void Exit(ExitAction action);
    public virtual void Open(bool closePrevious);
    private void Close();
    public virtual void Close(bool openPrevious);
    private void Lerp(bool open);
}