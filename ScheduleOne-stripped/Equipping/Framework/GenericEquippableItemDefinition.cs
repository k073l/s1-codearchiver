using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.Equipping.Framework;
public abstract class GenericEquippableItemDefinition<T> : StorableItemDefinition where T : EquippableData
{
    public new T EquippableData { get; private set; }

    public override void ValidateDefinition();
}