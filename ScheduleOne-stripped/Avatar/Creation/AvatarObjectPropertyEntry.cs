using System;
using ScheduleOne.Core.Avatar.Properties;
using TMPro;
using UnityEngine;

namespace ScheduleOne.Avatar.Creation;
public abstract class AvatarObjectPropertyEntry<T> : MonoBehaviour where T : AvatarPropertyBase
{
    [SerializeField]
    private TextMeshProUGUI _propertyNameLabel;
    protected T _property;
    public virtual void Initialize(T property);
    private void OnDestroy();
    protected virtual void PropertyValueChanged();
}