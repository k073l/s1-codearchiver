using System;
using ScheduleOne.Core.Items.Framework;
using UnityEngine;

namespace ScheduleOne.Core.Equipping.Framework;
public interface IEquippedItemHandler
{
    IEquippableUser User { get; }

    GameObject gameObject { get; }

    EquippableData EquippableData { get; }

    event Action OnUnequipped;
    void Equipped(IEquippableUser user, EquippableData equippableData);
    void EquippedWithItem(IEquippableUser user, EquippableData equippableData, BaseItemInstance itemInstance);
    void Unequipped();
}