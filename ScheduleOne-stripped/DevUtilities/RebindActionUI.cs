using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace ScheduleOne.DevUtilities;
public class RebindActionUI : MonoBehaviour
{
    [Serializable]
    public class UpdateBindingUIEvent : UnityEvent<RebindActionUI, string, string, string>
    {
    }

    [Serializable]
    public class InteractiveRebindEvent : UnityEvent<RebindActionUI, RebindingOperation>
    {
    }

    public Action onRebind;
    [Tooltip("Reference to action that is to be rebound from the UI.")]
    [SerializeField]
    private InputActionReference m_Action;
    [SerializeField]
    private string m_BindingId;
    [SerializeField]
    private DisplayStringOptions m_DisplayStringOptions;
    [Tooltip("Text label that will receive the name of the action. Optional. Set to None to have the rebind UI not show a label for the action.")]
    [SerializeField]
    private TextMeshProUGUI m_ActionLabel;
    [Tooltip("Text label that will receive the current, formatted binding string.")]
    [SerializeField]
    private TextMeshProUGUI m_BindingText;
    [Tooltip("Optional UI that will be shown while a rebind is in progress.")]
    [SerializeField]
    private GameObject m_RebindOverlay;
    [Tooltip("Optional text label that will be updated with prompt for user input.")]
    [SerializeField]
    private TextMeshProUGUI m_RebindText;
    [Tooltip("Event that is triggered when the way the binding is display should be updated. This allows displaying bindings in custom ways, e.g. using images instead of text.")]
    [SerializeField]
    private UpdateBindingUIEvent m_UpdateBindingUIEvent;
    [Tooltip("Event that is triggered when an interactive rebind is being initiated. This can be used, for example, to implement custom UI behavior while a rebind is in progress. It can also be used to further customize the rebind.")]
    [SerializeField]
    private InteractiveRebindEvent m_RebindStartEvent;
    [Tooltip("Event that is triggered when an interactive rebind is complete or has been aborted.")]
    [SerializeField]
    private InteractiveRebindEvent m_RebindStopEvent;
    private RebindingOperation m_RebindOperation;
    private static List<RebindActionUI> s_RebindActionUIs;
    public InputActionReference actionReference { get; set; }
    public string bindingId { get; set; }
    public DisplayStringOptions displayStringOptions { get; set; }
    public TextMeshProUGUI actionLabel { get; set; }
    public TextMeshProUGUI bindingText { get; set; }
    public TextMeshProUGUI rebindPrompt { get; set; }
    public GameObject rebindOverlay { get; set; }
    public UpdateBindingUIEvent updateBindingUIEvent { get; }
    public InteractiveRebindEvent startRebindEvent { get; }
    public InteractiveRebindEvent stopRebindEvent { get; }
    public RebindingOperation ongoingRebind => m_RebindOperation;

    public bool ResolveActionAndBinding(out InputAction action, out int bindingIndex);
    public bool IsRebinding();
    public void UpdateBindingDisplay();
    public void ResetToDefault();
    public void StartInteractiveRebind();
    private void PerformInteractiveRebind(InputAction action, int bindingIndex, bool allCompositeParts = false);
    protected void OnEnable();
    protected void OnDisable();
    private static void OnActionChange(object obj, InputActionChange change);
    private void UpdateActionLabel();
}