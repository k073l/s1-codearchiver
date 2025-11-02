using System.Collections.Generic;
using System.Linq;
using FishNet.Connection;
using FishNet.Object;

namespace ScheduleOne.ItemFramework;
public interface IItemSlotOwner
{
    List<ItemSlot> ItemSlots { get; set; }

    void SetStoredInstance(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    void SetItemSlotQuantity(int itemSlotIndex, int quantity);
    void SetSlotLocked(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    void SetSlotFilter(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    void SendItemSlotDataToClient(NetworkConnection conn);
    int GetTotalItemCount();
    int GetItemCount(string id);
    int GetNonEmptySlotCount();
}