using System;
using System.Collections.Generic;
using System.Linq;
using FishNet.Object;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.ItemFramework;
using ScheduleOne.NPCs;
using UnityEngine;

namespace ScheduleOne.Management;
public interface ITransitEntity
{
    public enum ESlotType
    {
        Input,
        Output,
        Both
    }

    string Name { get; }

    List<ItemSlot> InputSlots { get; set; }

    List<ItemSlot> OutputSlots { get; set; }

    Transform LinkOrigin { get; }

    Transform[] AccessPoints { get; }

    bool Selectable { get; }

    bool IsAcceptingItems { get; }

    bool IsDestroyed { get; }

    Guid GUID { get; }

    void ShowOutline(Color color);
    void HideOutline();
    void InsertItemIntoInput(ItemInstance item, NPC inserter = null);
    void InsertItemIntoOutput(ItemInstance item, NPC inserter = null);
    int GetInputCapacityForItem(ItemInstance item, NPC asker = null, bool checkPlayerFilters = true);
    int GetOutputCapacityForItem(ItemInstance item, NPC asker = null);
    ItemSlot GetOutputItemContainer(ItemInstance item);
    List<ItemSlot> ReserveInputSlotsForItem(ItemInstance item, NetworkObject locker);
    void RemoveSlotLocks(NetworkObject locker);
    ItemSlot GetFirstSlotContainingItem(string id, ESlotType searchType);
    ItemSlot GetFirstSlotContainingTemplateItem(ItemInstance templateItem, ESlotType searchType);
}