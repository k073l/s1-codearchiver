using System;
using UnityEngine;

namespace ScheduleOne.Core;
[Serializable]
public class ValueOrReference<T, T0>
    where T : class where T0 : ValueProviderScriptableObject<T>
{
    public enum Mode
    {
        Inline,
        Reference
    }

    public Mode mode;
    [SerializeField]
    private T inlineValue;
    [SerializeField]
    private T0 reference;
    public ValueOrReference(T inlineValue);
    public ValueOrReference(T0 reference);
    public ValueOrReference(Mode mode, T inlineValue, T0 reference);
    public T GetValue();
}