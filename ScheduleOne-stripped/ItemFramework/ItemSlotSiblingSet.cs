using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
public class ItemSlotSiblingSet
{
    public List<ItemSlot> Slots;
    public ItemSlotSiblingSet(params ItemSlot[] slots);
    public ItemSlotSiblingSet(List<ItemSlot> slots);
    public void AddSlot(ItemSlot slot);
}