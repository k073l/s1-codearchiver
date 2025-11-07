using System;
using System.Collections.Generic;
using ScheduleOne.Effects;
using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.Product;
[Serializable]
[CreateAssetMenu(fileName = "PropertyItemDefinition", menuName = "ScriptableObjects/PropertyItemDefinition", order = 1)]
public class PropertyItemDefinition : StorableItemDefinition
{
    [Header("Properties")]
    public List<Effect> Properties;
    public virtual void Initialize(List<Effect> properties);
    public bool HasProperty(Effect property);
}