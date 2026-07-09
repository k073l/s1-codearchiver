using UnityEngine;

namespace ScheduleOne.Core;
public abstract class ValueProviderScriptableObject<T> : ScriptableObject, IValueProvider<T>
{
    public abstract T GetValue();
}