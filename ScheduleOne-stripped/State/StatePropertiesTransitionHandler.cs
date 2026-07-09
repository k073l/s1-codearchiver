namespace ScheduleOne.State;
public static class StatePropertiesTransitionHandler
{
    private static StateProperties _currentProperties;
    public static void Transition(StateProperties newProperties);
}