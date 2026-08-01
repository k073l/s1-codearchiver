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
    private float _timeOnLastRebind;
    [Tooltip("Reference to action that is to be rebound from the UI.")]
    [SerializeField]
    private InputActionReference m_Action;
    [Tooltip("List of derived actions that should mirror this action's binding if they share the same initial binding.")]
    [SerializeField]
    private List<InputActionReference> m_DerivedActions;
    [SerializeField]
    private string m_BindingId;
    [SerializeField]
    private DisplayStringOptions m_DisplayStringOptions;
    [SerializeField]
    private TextMeshProUGUI m_ActionLabel;
    [SerializeField]
    private TextMeshProUGUI m_BindingText;
    [SerializeField]
    private GameObject m_RebindOverlay;
    [SerializeField]
    private TextMeshProUGUI m_RebindText;
    [SerializeField]
    private UpdateBindingUIEvent m_UpdateBindingUIEvent;
    [SerializeField]
    private InteractiveRebindEvent m_RebindStartEvent;
    [SerializeField]
    private InteractiveRebindEvent m_RebindStopEvent;
    private RebindingOperation m_RebindOperation;
    private static List<RebindActionUI> s_RebindActionUIs;
    public static bool IsRebindingInProgress { get; }
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

    private void Start();
    public bool ResolveActionAndBinding(out InputAction action, out int bindingIndex);
    public bool IsRebinding();
    public void UpdateBindingDisplay();
    public void ResetToDefault();
    public void StartInteractiveRebind();
    private void PerformInteractiveRebind(InputAction action, int bindingIndex, bool allCompositeParts = false);
    private void SwapConflictingBindings(string oldPath, string newPath);
    private void SyncDerivedActions(string oldPath, string newPath);
    protected void OnEnable();
    protected void OnDisable();
    private static void OnActionChange(object obj, InputActionChange change);
    private void UpdateActionLabel();
}