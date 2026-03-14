using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.Equipping.Framework;
public abstract class GenericEquippableItemDefinition<T> : StorableItemDefinition where T : EquippableData
{
    public T EquippableData { get; private set; }

    public override void ValidateDefinition();
}