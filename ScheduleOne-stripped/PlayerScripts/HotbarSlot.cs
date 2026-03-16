using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Equipping;
using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.PlayerScripts;
public class HotbarSlot : ItemSlot
{
    public delegate void EquipEvent(bool equipped);
    public EquipEvent onEquipChanged;
    private Equippable _equippable;
    private IEquippedItemHandler _equippedItem;
    public bool IsSelected { get; protected set; }

    public override void SetStoredItem(ItemInstance instance, bool _internal = false);
    public override void ClearStoredInstance(bool _internal = false);
    public virtual void Select();
    private void Equip();
    private void Unequip();
    public virtual void Deselect();
    public override bool CanSlotAcceptCash();
}