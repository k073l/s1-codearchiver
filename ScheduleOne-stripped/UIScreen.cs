using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne;
public class UIScreen : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Manually assign the UIPanel attached to this screen in editor.")]
    private List<UIPanel> panels;
    [SerializeField]
    [Tooltip("When selected, the input action in the inputDescriptor list will be active")]
    private List<InputDescriptor> inputDescriptors;
    [SerializeField]
    [Tooltip("Each screen support 1 active scroll rect to scroll. You can use uiScreen.ChangeActiveScrollRect(newScrollRect) to change the active scroll rect via script at runtime.")]
    private ScrollRect activeScrollRect;
    [SerializeField]
    [Tooltip("Add this screen to UIScreenManger on Start")]
    private bool addScreenOnStart;
    [SerializeField]
    [Tooltip("Add this screen to UIScreenManger on OnEnable")]
    private bool addScreenOnEnable;
    [SerializeField]
    [Tooltip("Remove this screen from UIScreenManger on OnDisable")]
    private bool removeScreenOnDisable;
    [SerializeField]
    private bool autoAttachToInventory;
    [SerializeField]
    protected bool _debugMode;
    private UIPanel currentSelectedPanel;
    private bool isSelected;
    private bool wasNavPressedLastFrame;
    private Canvas _canvas;
    private UIPanel _lastSelectedPanel;
    private PanelChangeEvent _onPanelChange;
    public bool IsSelected { get; set; }
    public UIPanel CurrentSelectedPanel => currentSelectedPanel;
    public IReadOnlyList<UIPanel> Panels => panels.AsReadOnly();
    public Canvas Canvas => _canvas;

    private void Awake();
    protected virtual void OnAwake();
    private void Start();
    protected virtual void OnStarted();
    private void OnEnable();
    private void OnDisable();
    private void OnDestroy();
    protected virtual void OnDestroyed();
    protected virtual void Update();
    private void InitScreen();
    public void AddPanel(UIPanel panel);
    public void RemovePanel(UIPanel panel);
    public void ClearPanels();
    public void SetCurrentSelectedPanel(UISelectable overrideSelectable = null, bool scrollToChild = true, bool allowReselect = false);
    public void SetCurrentSelectedPanel(UIPanel panel, UISelectable overrideSelectable = null, bool scrollToChild = true, bool allowReselect = false);
    public void SetToPreviousSelectedPanel();
    private void UpdateScrollbar();
    private void DetectInput();
    private void DetectScreenInputDescriptors();
    internal bool ForceNavigate(Vector2 navDir, Vector2 fromPos);
    private bool Navigate(Vector2 navDir, Vector2 fromPosScreen);
    private bool NavigateToPanel(UIPanel panel);
    public void ChangeActiveScrollRect(ScrollRect newScrollRect);
    public void SubscribeToPanelChange(PanelChangeEvent callback);
    public void UnsubscribeFromPanelChange(PanelChangeEvent callback);
}