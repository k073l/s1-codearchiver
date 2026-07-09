using System;
using UnityEngine;

namespace ScheduleOne;
[Serializable]
public class NavigationOverride<T>
{
    [Serializable]
    public class OverrideElement<S>
    {
        public S Element;
        public bool IsExplicit;
        public bool IsReciprocated;
    }

    public OverrideElement<T> Up;
    public OverrideElement<T> Down;
    public OverrideElement<T> Left;
    public OverrideElement<T> Right;
    public bool HasOverride(Vector2 direction, out T component);
}