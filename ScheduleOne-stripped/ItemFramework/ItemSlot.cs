using System;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
[Serializable]
public class ItemSlot
{
    public Action onItemDataChanged;
    public Action onItemInstanceChanged;
    public Action onLocked;
    public Action onUnlocked;
    public Action onFilterChange;
    public ItemInstance ItemInstance { get; protected set; }
    public IItemSlotOwner SlotOwner { get; protected set; }
    private int SlotIndex => SlotOwner.ItemSlots.IndexOf(this);
    public int Quantity { get; }
    public bool IsAtCapacity { get; }
    public bool IsLocked => ActiveLock != null;
    public ItemSlotLock ActiveLock { get; protected set; }
    public bool IsRemovalLocked { get; protected set; }
    public bool IsAddLocked { get; protected set; }
    protected List<ItemFilter> HardFilters { get; set; } = new List<ItemFilter>();
    public bool CanPlayerSetFilter { get; set; }
    public SlotFilter PlayerFilter { get; set; } = new SlotFilter();
    public ItemSlotSiblingSet SiblingSet { get; set; }

    public void SetSlotOwner(IItemSlotOwner owner);
    public void SetSiblingSet(ItemSlotSiblingSet set);
    public ItemSlot();
    public ItemSlot(bool canPlayerSetFilter = false);
    public void ReplicateStoredInstance();
    public virtual void SetStoredItem(ItemInstance instance, bool _internal = false);
    public virtual void InsertItem(ItemInstance item);
    public virtual void AddItem(ItemInstance item, bool _internal = false);
    public virtual void ClearStoredInstance(bool _internal = false);
    public void SetQuantity(int amount, bool _internal = false);
    public void ChangeQuantity(int change, bool _internal = false);
    protected virtual void ItemDataChanged();
    protected virtual void ClearItemInstanceRequested();
    public void AddFilter(ItemFilter filter);
    public void ApplyLock(NetworkObject lockOwner, string lockReason, bool _internal = false);
    public void RemoveLock(bool _internal = false);
    public void SetIsRemovalLocked(bool locked);
    public void SetIsAddLocked(bool locked);
    public virtual bool DoesItemMatchHardFilters(ItemInstance item);
    public virtual bool DoesItemMatchPlayerFilters(ItemInstance item);
    public void SetFilterable(bool filterable);
    public void SetPlayerFilter(SlotFilter filter, bool _internal = false);
    public virtual int GetCapacityForItem(ItemInstance item, bool checkPlayerFilters = false);
    public virtual bool CanSlotAcceptCash();
    public static bool TryInsertItemIntoSet(List<ItemSlot> ItemSlots, ItemInstance item);
}