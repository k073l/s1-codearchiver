using System;
using System.Collections.Generic;
using System.Linq;
using FishNet.Connection;
using FishNet.Object;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
public interface IItemSlotOwner
{
    List<ItemSlot> ItemSlots { get; set; }

    void SetStoredInstance(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    void SetItemSlotQuantity(int itemSlotIndex, int quantity);
    void SetSlotLocked(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    void SetSlotFilter(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    void SendItemSlotDataToClient(NetworkConnection conn);
    private void Send(NetworkConnection conn2);
    }int GetQuantitySum();
    int GetQuantityOfItem(string id);
    int GetNonEmptySlotCount();
    ItemSlot GetFirstSlotContaining(string id);
}