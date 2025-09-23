using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class ItemSet
{
    public string[] Items;
    public SlotFilter[] SlotFilters;
    public ItemSet(List<ItemData> items);
    public string GetJSON();
    public ItemSet(List<ItemSlot> itemSlots);
    public ItemSet(ItemSlot[] itemSlots);
    public void LoadTo(List<ItemSlot> slots);
    public void LoadTo(ItemSlot[] slots);
    public void LoadTo(ItemSlot slot, int index = 0);
    public static bool TryDeserialize(string json, out DeserializedItemSet itemSet);
    public static bool TryDeserialize(ItemSet set, out DeserializedItemSet itemSet);
}