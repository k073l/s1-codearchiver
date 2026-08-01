using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.State;
public class MonoStateMachine : MonoState, IStateMachine, IState
{
    public List<IState> Stack { get; private set; } = new List<IState>();

    public override void OnActivate();
    public void Push(IState state);
    public void Pop();
    public void Remove(IState state);
    public IState Peek();
    public IState PeekRecursive();
    public bool IsAnyChildStateAcceptingInput();
    string IState.get_name();
}