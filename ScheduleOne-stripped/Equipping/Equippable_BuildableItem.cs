using ScheduleOne.Building;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class Equippable_BuildableItem : Equippable_StorableItem
{
    protected bool isBuilding;
    protected override void Update();
    public override void Unequip();
}