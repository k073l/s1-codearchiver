using ScheduleOne.Core;

namespace ScheduleOne.State;
public class InGameStateMachine : MonoStateMachine
{
    [Button]
    public void PopUntilDefault();
}