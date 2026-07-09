using ScheduleOne.AvatarFramework;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.Tools;
public class EquipUtility : MonoBehaviour
{
    public AvatarEquippable Equippable;
    [Button]
    public void Equip();
    [Button]
    public void Unequip();
}