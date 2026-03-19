using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne;
[RequireComponent(typeof(RectTransform))]
public abstract class UIPanel : MonoBehaviour
{
    public enum UINavigationType
    {
        ImmediateDirection,
        NearestDirectionAndDistance
    }

    [SerializeField]
    [Tooltip("Manually assign the UIPanel attached to this screen in editor. Alternatively, you can use AddSelectable and RemoveSelectable to add/remove UISelectable.")]
    protected List<UISelectable> selectables;
    [SerializeField]
    [Tooltip("Default selectable to focus when the panel is selected.")]
    protected UISelectable defaultSelectable;
    [SerializeField]
    [Tooltip("ScrollRect for scrolling Layout Group.")]
    protected ScrollRect scrollRect;
    [SerializeField]
    [Tooltip("Priority value to control which panel will be selected by default by the Screen.")]
    private int priority;
    [SerializeField]
    [Tooltip("When selected, the input action in the inputDescriptor list will be active")]
    private List<InputDescriptor> inputDescriptors;
    [SerializeField]
    [Tooltip("Select this panel on Start")]
    private bool selectPanelOnStart;
    [SerializeField]
    [Tooltip("Select this panel on OnEnable")]
    private bool selectPanelOnEnable;
    [SerializeField]
    [Tooltip("Deselect this panel on OnDisable")]
    private bool deselectPanelOnDisable;
    [SerializeField]
    [Tooltip("Set to true if this panel is supporting UIOptions to prevent left/right navigation of UISelectable and UIPanel")]
    protected bool preventSideNavigation;
    [SerializeField]
    private UnityEvent OnPanelSelected;
    [SerializeField]
    private UnityEvent OnPanelDeselected;
    private UISelectable currentSelectedSelectable;
    protected int currentIndex;
    protected float navTimer;
    protected bool wasNavPressedLastFrame;
    protected float scrollSpeed;
    private Coroutine scrollCoroutine;
    private bool isDisabled;
    private bool isQuitting;
    private Vector2 scrollMargin;
    protected bool lockInputThisFrame;
    public int Priority => priority;
    public RectTransform RectTransform { get; private set; }
    public bool IsSelected { get; private set; }
    public bool IsLocked { get; set; }
    public UIScreen ParentScreen { get; private set; }
    public UISelectable CurrentSelectedSelectable { get; set; }
    public IReadOnlyList<UISelectable> Selectables => selectables.AsReadOnly();
    public bool IsNavigablePanel => !(this is INonNavigablePanel);

    protected virtual void Awake();
    protected virtual void Start();
    protected virtual void OnDestroy();
    protected virtual void OnEnable();
    protected virtual void OnDisable();
    protected virtual void Update();
    private void LateUpdate();
    protected virtual void EarlyUpdate();
    protected virtual void HandleInputDeviceChanged(GameInput.InputDeviceType type);
    protected virtual void DetectInput();
    protected void DetectScreenInputDescriptors();
    private void DetectSelectableInput();
    protected void SendClickEventToCurrentSelectedSelectable();
    public void SetParentScreen(UIScreen screen);
    internal bool IsPanelVisible();
    internal bool IsAnySelectablesActive();
    public UISelectable GetAValidCurrentSelectedSelectable(bool returnFirstFound = false);
    public void SelectSelectable(UISelectable selectable, bool scrollToSelectable = false);
    public void SelectSelectable(int index, bool scrollToSelectable = false);
    public void SelectSelectable(bool returnFirstFound, bool scrollToSelectable = false);
    public bool AddSelectable(UISelectable selectable);
    public void RemoveSelectable(UISelectable selectable, bool autoFallback = true);
    public void DeselectSelectable();
    public void ClearAllSelectables();
    private UISelectable GetFallbackSelectable(bool returnFirstFound = false);
    internal UISelectable Select(UISelectable overrideSelectable = null, bool scrollToChild = true);
    internal void Deselect();
    internal void OnReset();
    private void ResetCurrentSelectedSelectable();
    public void ScrollToCurrentSelectedSelectable();
    protected void ScrollToChild(RectTransform child, float duration = 0.25f);
    private IEnumerator SmoothScrollContent(Vector3 targetLocalPosition, float duration);
    public void EnableSideNavigation(bool enabled);
    protected virtual bool Navigate(Vector2 navDir);
    private void ResetNavigationData();
    internal void LockNavigationTemporarily();
    protected virtual bool NavigateUsingCyclePanel(Vector2 dir);
}