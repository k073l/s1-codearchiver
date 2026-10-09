using System;
using UnityEngine;

namespace ScheduleOne.Core.Avatar.Properties;
[Serializable]
public abstract class AvatarPropertyBase
{
    public enum EType
    {
        Color
    }

    public Action OnValueChanged;
    [SerializeField]
    protected string _name;
    [SerializeField]
    protected bool _editable;
    public string Name => _name;
    public EType Type => GetPropertyType();
    public bool Editable => _editable;

    public AvatarPropertyBase(string name, bool editable = true);
    protected abstract EType GetPropertyType();
}