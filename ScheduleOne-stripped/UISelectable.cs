using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI.Input;
using ScheduleOne.UI.Items;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne;
[RequireComponent(typeof(RectTransform))]
public class UISelectable : UITrigger, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, IUIComponent
{
    [SerializeField]
    [Tooltip("When selected, the input action in the inputDescriptor list will be active")]
    private List<InputDescriptor> inputDescriptors;
    [SerializeField]
    [Tooltip("Support default A to fire the button click event even if there are inputDescriptors")]
    private bool allowTriggerSubmitWithInputDescriptors;
    [SerializeField]
    [Tooltip("A gameobject that will show when selected. Only shown when in Controller mode")]
    private GameObject selectedImage;
    [SerializeField]
    [Tooltip("Search and Add selectable to a parent Panel on Awake")]
    private bool addToPanelOnAwake;
    [SerializeField]
    [Tooltip("On Disable, tell the parent Panel to search for another valid selectable to select")]
    private bool findAnotherSelectableInPanelOnDisable;
    [SerializeField]
    [Tooltip("Set to true if you want this to be not selectable when UGUI interactable is set to false")]
    private bool blockSelectionOnInteractableFalse;
    [SerializeField]
    protected bool disableSideNavigationWhenSelected;
    [SerializeField]
    [Tooltip("Set to true if you want this to use the rect corner points for navigation calculations rather than center point")]
    private bool useFullRectForNavigation;
    [SerializeField]
    [Tooltip("Override navigation calculation to move to a set IUIComponent instead")]
    protected NavigationOverride<UISelectable> navigationOverride;
    [SerializeField]
    [Tooltip("The RectTransform used for Full Rect calculation. If null, it will default to the selectable's own RectTransform.")]
    protected RectTransform fullRectTransformOverride;
    [SerializeField]
    [Tooltip("Used to determine which point is used as the origin for calculating navigation direction. Only used if useFullRectForNavigation is true.")]
    private UIPanel.ENavigationOrigin navigationOrigin;
    [SerializeField]
    [Tooltip("Custom origin point for navigation origin")]
    private RectTransform customNavigationOrigin;
    [Header("Components")]
    [SerializeField]
    private Text _label;
    [Header("Input Prompts")]
    [SerializeField]
    private InputPromptsData _inputPrompt;
    [SerializeField]
    private EmbeddedInputPromptUI _embeddedInputPrompt;
    public UnityEvent OnSelected;
    public UnityEvent OnDeselected;
    private bool _isSelected;
    private bool _ignoreWhenNevigating;
    private bool _isPromptActive;
    private const float INTERSECTION_OFFSET;
    public RectTransform RectTransform { get; private set; }
    public UIPanel ParentPanel { get; private set; }
    public Text Label => _label;
    public bool DisableSideNavigationWhenSelected { get; set; }
    public bool UseFullRectForNavigation { get; set; }
    public bool IgnoreWhenNavigating => _ignoreWhenNevigating;
    public NavigationOverride<UISelectable> NavigationOverride => navigationOverride;
    public bool AllowTriggerSubmitWithInputDescriptors => allowTriggerSubmitWithInputDescriptors;
    public bool CanBeSelected => CanBeSelectedInternal();

    internal IReadOnlyList<InputDescriptor> GetInputDescriptors();
    protected override void Awake();
    protected virtual void OnDisable();
    protected virtual void OnEnable();
    private void OnDestroy();
    public virtual void OnPointerEnter(PointerEventData eventData);
    public override void OnPointerExit(PointerEventData eventData);
    protected virtual bool DeselectOnPointerExit();
    public override void OnPointerClick(PointerEventData eventData);
    public virtual void OnSelect(BaseEventData eventData);
    public virtual void OnDeselect(BaseEventData eventData);
    internal override void OnReset();
    internal void SetParentPanel(UIPanel panel);
    internal bool IsSelected();
    private void SetSelectedImageVisible(bool visible);
    public void SetIgnoreWhenNavigating(bool isIgnored);
    public RectTransform GetRectTransform();
    protected virtual bool CanBeSelectedInternal();
    protected virtual bool CanBeSelectedWhileDraggingItem();
    public bool HasNavigationOverride(ScreenDirection dir, out UISelectable selectable);
    public bool HasReciprocalNavigationOverride(string dir);
    public void SetNavigationOverrideReciprocated(string dir);
    public void ClearNavigationOverrideReciprocated(string dir);
    public float GetDirectionMatch(Vector2 dir, Vector2 screenPos);
    public float GetDistance(Vector2 screenPos, Vector2 direction);
    public Vector3 GetOrigin();
}