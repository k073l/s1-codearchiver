using System.Collections.Generic;

namespace ScheduleOne.State;
public interface IStateMachine : IState
{
    List<IState> Stack { get; }

    void Push(IState state);
    void Pop();
    void Remove(IState state);
    IState Peek();
    IState PeekRecursive();
    string StackToString(int indentation = 0);
}