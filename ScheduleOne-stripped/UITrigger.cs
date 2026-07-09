using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ScheduleOne;
[RequireComponent(typeof(Selectable))]
public class UITrigger : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler
{
    public enum TriggerType
    {
        Press,
        Hold,
        PressAndRelease
    }

    [SerializeField]
    private TriggerType triggerType;
    [SerializeField]
    [Tooltip("Set to true if you want Mouse to be always Press")]
    private bool mouseAlwaysPress;
    [SerializeField]
    [Tooltip("Duration in seconds to hold for Hold trigger")]
    private float holdDuration;
    [SerializeField]
    [Tooltip("Optional UI image to show hold progress (should be Image Type: Filled)")]
    private Image holdImage;
    [SerializeField]
    [Tooltip("Optional UGUI Selectable. If assigned, the uiTrigger interactable will also check for the UGUI Selectable interactable property.")]
    private Selectable uGUISelectable;
    [SerializeField]
    [Tooltip("Set to true to allow the hold action to loop while holding. The OnTrigger event will be invoked every holdDuration seconds.")]
    private bool _loopHold;
    [SerializeField]
    [Tooltip("Set to true to trigger the OnTrigger event when the hold starts. The OnTrigger event will be invoked once when the hold starts.")]
    private bool _triggerOnHoldStart;
    [Tooltip("Event triggered when the action is performed")]
    public UnityEvent OnTrigger;
    public UnityEvent OnRelease;
    public bool _debugMode;
    private bool isHolding;
    private float holdTime;
    private bool isHoldStarted;
    private bool interactable;
    protected bool _isPressed;
    public bool Interactable { get; set; }
    public Image HoldImage { get; set; }

    internal TriggerType GetTriggerType();
    protected virtual void Awake();
    private bool IsInteractable();
    private void Update();
    internal virtual void OnReset();
    internal virtual void DetectTriggerInput(InputActionReference inputAction);
    internal void OnInputDown();
    internal void OnInputRelease();
    internal void OnInputUp();
    public virtual void OnPointerDown(PointerEventData eventData);
    public virtual void OnPointerUp(PointerEventData eventData);
    public virtual void OnPointerExit(PointerEventData eventData);
    public virtual void OnPointerClick(PointerEventData eventData);
    private void HandleHoldStart();
    private void HandleHoldEnd();
    private void UpdateHoldImage(float amount);
}