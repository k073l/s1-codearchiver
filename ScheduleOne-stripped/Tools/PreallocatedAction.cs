using System;
using System.Collections.Generic;

namespace ScheduleOne.Tools;
public class PreallocatedAction
{
    private readonly List<Action> _listeners;
    public int Count => _listeners.Count;

    public PreallocatedAction(int capacity = 16);
    public static PreallocatedAction operator +(PreallocatedAction evt, Action listener)
    {
        evt.Add(listener);
        return evt;
    }

    public static PreallocatedAction operator -(PreallocatedAction evt, Action listener)
    {
        evt.Remove(listener);
        return evt;
    }

    public void Add(Action listener);
    public void Remove(Action listener);
    public void Invoke();
}