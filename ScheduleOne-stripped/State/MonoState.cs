using System;
using System.Collections.Generic;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.UI.Input;
using ScheduleOne.UI.Items;
using UnityEngine;

namespace ScheduleOne.State;
public class MonoState : MonoBehaviour, IState
{
    [SerializeField]
    private MonoStateMachine _defaultParent;
    [Header("State Properties")]
    [SerializeField]
    private bool _customStateProperties;
    [Conditional("_customStateProperties", true)]
    [SerializeField]
    private StateProperties.EPreset _preset;
    [Conditional("_customStateProperties", false)]
    [SerializeField]
    private StateProperties _properties;
    [Header("Input")]
    [SerializeField]
    private bool _autoSetupExitListeners;
    [Conditional("_autoSetupExitListeners", false)]
    [SerializeField]
    private int _exitListenerPriority;
    [SerializeField]
    private bool _enableItemQuickMove;
    [Header("Flags")]
    [SerializeField]
    private IState.EFlag[] _flags;
    [Header("Input Prompts")]
    [Tooltip("If specified, this input prompt module will be added to this state on Awake/Initialization.")]
    [SerializeField]
    private InputPromptsData _defaultInputPrompts;
    [SerializeField]
    private bool _subscribeToInputPromptModuleEvents;
    private List<ItemSlot> _quickMoveSlots;
    private StateInputHandler _inputHandler;
    public bool IsActive => SceneState.ActiveState == this;
    public bool IsAcceptingInput { get; }
    public StateProperties Properties { get; set; }
    public IState.EFlag[] Flags => _flags;

    public event Action OnAddedToStack;
    public event Action OnRemovedFromStack;
    public event Action OnStateActivate;
    public event Action OnStateDeactivate;
    public event Action OnBecomeTopSibling;
    public event Action OnNoLongerTopSibling;
    protected virtual void Awake();
    protected virtual void Start();
    public void AssertDefaultParent();
    public virtual void OnActivate();
    public virtual void OnDeactivate();
    public void InitializeDefaultParent(MonoStateMachine parent);
    public void PushToDefaultParent();
    public void PopFromDefaultParent();
    public void RemoveFromDefaultParent();
    public void NotifyRemovedFromStack();
    public void NotifyAddedToStack();
    public void NotifyBecomeTopSibling();
    public void NotifyNoLongerTopSibling();
    public void SetQuickMoveSecondarySlots(List<ItemSlot> slots);
    private void OnExit(ExitAction action);
    private void CreateInputHandler();
    public void AddFlag(IState.EFlag flag);
    public void LoadModule(InputPromptsData module, string displayTextOverride = null);
    public void UnloadModule(InputPromptsData module);
    string IState.get_name();
}