using System;
using System.Collections.Generic;

namespace ScheduleOne.Core.Avatar.Properties;
[Serializable]
public abstract class AvatarProperty<T> : AvatarPropertyBase
{
    public T Value => _value;
    protected T _value { get; private set; }

    public AvatarProperty(string name, bool editable, T value);
    public void SetValue(T value);
}