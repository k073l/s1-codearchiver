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
public abstract class UIPanel : MonoBehaviour, IUIComponent
{
    public enum UINavigationType
    {
        ImmediateDirection,
        NearestDirectionAndDistance
    }

    public enum EPanelSelectionMode
    {
        KeepLastSelection,
        NearestToPreviousSelection,
        NearestToNavigationOrigin
    }

    public enum ENavigationOrigin
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        Center,
        Custom
    }

    [Serializable]
    public enum EPanelExitMode
    {
        BestMatch,
        LastSelected
    }

    [SerializeField]
    [Tooltip("Manually assign the UIPanel attached to this screen in editor. Alternatively, you can use AddSelectable and RemoveSelectable to add/remove UISelectable.")]
    protected List<UISelectable> selectables;
    [SerializeField]
    [Tooltip("Default selectable to focus when the panel is selected.")]
    protected UISelectable defaultSelectable;
    [SerializeField]
    [Tooltip("When navigating to this panel from another, should it remember its last selection or find the selectable nearest to the item you just came from?")]
    private EPanelSelectionMode selectionModeOnEnter;
    [SerializeField]
    [Tooltip("ScrollRect for scrolling Layout Group.")]
    protected ScrollRect scrollRect;
    [SerializeField]
    [Tooltip("Margin to keep the child visible in the viewport when scrolling.")]
    protected Vector2 scrollMargin;
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
    [Tooltip("Set to true if this panel is supporting UIOptions to allow diagonal navigation of UISelectable and UIPanel")]
    protected bool allowDiagonalNavigation;
    [SerializeField]
    [Tooltip("Set to true to use the full rect of the selectable for navigation instead of just the center point.")]
    protected bool useFullRectForNavigation;
    [SerializeField]
    [Tooltip("The RectTransform used for Full Rect calculation. If null, it will default to the selectable's own RectTransform.")]
    protected RectTransform fullRectTransformOverride;
    [SerializeField]
    [Tooltip("Used to determine which selectable to select by default when using ClosestToNavigationOrigin option")]
    protected ENavigationOrigin navigationOrigin;
    [SerializeField]
    [Tooltip("Custom navigation origin point")]
    protected RectTransform customNavigationOrigin;
    [SerializeField]
    [Tooltip("Panel exit mode")]
    protected EPanelExitMode panelExitMode;
    [SerializeField]
    [Tooltip("Override navigation calculation to move to a set IUIComponent instead")]
    protected NavigationOverride<UIPanel> navigationOverride;
    [SerializeField]
    private UnityEvent OnPanelSelected;
    [SerializeField]
    private UnityEvent OnPanelDeselected;
    [SerializeField]
    protected bool _debugMode;
    private RectTransform _rectTransform;
    private UISelectable currentSelectedSelectable;
    protected int currentIndex;
    protected float navTimer;
    protected bool wasNavPressedLastFrame;
    protected float scrollSpeed;
    private Coroutine scrollCoroutine;
    private bool isDisabled;
    private bool isQuitting;
    protected bool lockInputThisFrame;
    private Canvas _canvas;
    protected UISelectable _lastSelected;
    public int Priority => priority;
    public RectTransform RectTransform { get; }
    public bool IsSelected { get; private set; }
    public bool IsLocked { get; set; }
    public UIScreen ParentScreen { get; private set; }
    public UISelectable CurrentSelectedSelectable { get; set; }
    public int CurrentSelectableIndex => currentIndex;
    public IReadOnlyList<UISelectable> Selectables => selectables.AsReadOnly();
    public NavigationOverride<UIPanel> NavigationOverride => navigationOverride;
    public bool IsNavigablePanel => !(this is INonNavigablePanel);
    public EPanelExitMode PanelExitMode => panelExitMode;
    public Canvas Canvas => _canvas;

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
    public UISelectable GetNearestSelectableToWorldPosition(Vector3 worldPos);
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
    private UISelectable GetEntrySelectable();
    internal void Deselect();
    internal void OnReset();
    private void ResetCurrentSelectedSelectable();
    private UISelectable GetNearestToNavigationOrigin(ENavigationOrigin origin);
    public void ScrollToCurrentSelectedSelectable();
    protected void ScrollToChild(RectTransform child, float duration = 0.15f);
    private IEnumerator SmoothScrollContent(Vector3 targetLocalPosition, float duration);
    public void EnableSideNavigation(bool enabled);
    protected virtual bool Navigate(Vector2 navDir);
    public void ResetNavigationData();
    internal void LockNavigationTemporarily();
    protected virtual bool NavigateUsingCyclePanel(Vector2 dir);
    public RectTransform GetRectTransform();
    public bool HasNavigationOverride(ScreenDirection dir, out UIPanel selectable);
    public bool HasReciprocalNavigationOverride(string dir);
    public void SetNavigationOverrideReciprocated(string dir);
    public void ClearNavigationOverrideReciprocated(string dir);
    public float GetDirectionMatch(Vector2 dir, Vector2 screenPos);
    public float GetDistance(Vector2 screenPos, Vector2 direction);
    public Vector3 GetOrigin();
}