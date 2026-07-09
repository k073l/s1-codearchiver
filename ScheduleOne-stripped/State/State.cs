using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.UI.Input;
using ScheduleOne.UI.Items;
using UnityEngine;

namespace ScheduleOne.State;
public class State : IState
{
    private IStateMachine _defaultParent;
    private bool _customStateProperties;
    private StateProperties.EPreset _preset;
    private StateProperties _properties;
    private IState.EFlag[] _flags;
    [Header("Input")]
    private bool _autoSetupExitListeners;
    private int _exitListenerPriority;
    private bool _enableItemQuickMove;
    [Header("Input Prompts")]
    private InputPromptsData _defaultInputPrompts;
    private List<ItemSlot> _quickMoveSlots;
    private StateInputHandler _inputHandler;
    public string name { get; private set; }
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
    public State(string name, IStateMachine defaultParent = null, StateProperties.EPreset preset = StateProperties.EPreset.Unenforced, InputPromptsData _defaultInputPrompts = null);
    public void EnableAutoExitListener(int priority = 0);
    public void EnableItemQuickMove(List<ItemSlot> quickMoveSlots);
    public virtual void OnActivate();
    public virtual void OnDeactivate();
    public void InitializeDefaultParent(IStateMachine parent);
    public void PushToDefaultParent();
    public void PopFromDefaultParent();
    public void RemoveFromDefaultParent();
    public void NotifyRemovedFromStack();
    public void NotifyAddedToStack();
    public void NotifyBecomeTopSibling();
    public void NotifyNoLongerTopSibling();
    private void OnExit(ExitAction action);
    public void LoadModule(InputPromptsData module);
    public void UnloadModule(InputPromptsData module);
}