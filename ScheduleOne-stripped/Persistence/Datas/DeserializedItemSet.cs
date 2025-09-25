using System.Collections.Generic;
using ScheduleOne.ItemFramework;

namespace ScheduleOne.Persistence.Datas;
public class DeserializedItemSet
{
    public ItemInstance[] Items;
    public SlotFilter[] SlotFilters;
    public ItemInstance GetItemAt(int index);
    public SlotFilter GetSlotFilterAt(int index);
    public void LoadTo(List<ItemSlot> slots);
}