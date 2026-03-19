using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

namespace ScheduleOne;
public class UIScreenManager : PersistentSingleton<UIScreenManager>
{
    public struct UIScreenInfo
    {
        public UIScreen screen;
        public Action onCloseCallback;
    }

    public const float NavigationRepeatDelay;
    public const float NavigationRepeatRate;
    public const float DefaultScrollSpeed;
    public const float ScrollbarScrollSpeed;
    [SerializeField]
    private UIPopupScreen[] popupScreenPrefabs;
    [SerializeField]
    [Tooltip("Default 'A' button on controller for basic selectable interaction. Used in UITrigger")]
    private InputActionReference submitInputAction;
    [SerializeField]
    [Tooltip("Default 'B' button on controller, RightMouseButton for back interaction. Used in UIScreenManager")]
    private InputActionReference backInputAction;
    [SerializeField]
    [Tooltip("Default 'Start' button on controller, Escape key for back interaction. Used in UIScreenManager")]
    private InputActionReference escapeInputAction;
    private List<UIPopupScreen> popupScreenInstances;
    private Stack<UIScreenInfo> screenStack;
    private static GameObject lastSelectedObject;
    private static bool isBackTriggeredThisFrame;
    public InputActionReference SubmitInputAction => submitInputAction;
    public static GameObject LastSelectedObject { get; set; }
    public static bool IsBackTriggeredThisFrame => isBackTriggeredThisFrame;
    public UIScreen TopScreen => screenStack?.Peek().screen;

    protected override void Start();
    protected override void OnDestroy();
    private void Update();
    private void LateUpdate();
    private void BackToCloseCurrentScreen();
    public bool IsActiveScreenRegisteredForBack();
    private void HandleInputDeviceChanged(GameInput.InputDeviceType type);
    private void CheckInputDeviceMode();
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode);
    public void AddScreen(UIScreen screen, Action onCloseCallback = null);
    public void RemoveScreen(UIScreen screen);
    private bool IsScreenInStack(UIScreen screen);
    public bool IsAnyScreenActive();
    public bool IsAnyPopupScreenActive();
    public void OpenPopupScreen(string popupID);
    public void OpenPopupScreen(string popupID, params object[] args);
    public void ClosePopupScreen(string popupID);
    private UIPopupScreen FindPopupScreen(string popupID);
}