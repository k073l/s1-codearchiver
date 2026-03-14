using ScheduleOne.Core;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class EquipTester : MonoBehaviour
{
    public EquippableData TestEquippable;
    private IEquippedItemHandler _equippedItemHandler;
    [Button]
    public void Equip();
    [Button]
    public void EquipLocally();
    [Button]
    public void Unequip();
    [Button]
    public void UnequipAll();
}