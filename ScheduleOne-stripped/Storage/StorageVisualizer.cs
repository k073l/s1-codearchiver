using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Storage;
public class StorageVisualizer : MonoBehaviour
{
    [Header("References")]
    public StorageGrid[] StorageGrids;
    public Transform ItemContainer;
    [Header("Settings")]
    [Tooltip("Should storage visuals be fully recalculated when item(s) are removed?")]
    public bool FullRefreshOnItemRemoved;
    protected List<ItemSlot> itemSlots;
    protected int totalFootprintCapacity;
    protected Dictionary<StorableItemInstance, List<StoredItem>> activeStoredItems;
    public bool BlockRefreshes;
    protected bool updateVisuals;
    protected virtual void Awake();
    protected virtual void Update();
    public void AddSlot(ItemSlot slot, bool update = false);
    public Dictionary<StorableItemInstance, int> GetVisualRepresentation();
    public virtual void RefreshVisuals();
    private List<StoredItem> EnsureSufficientStoredItems(StorableItemInstance item, int quantityRequirement);
    private void DestroyExcessStoredItems(StorableItemInstance item, int quantityRequirement);
    public Dictionary<StorableItemInstance, int> GetContentsDictionary();
    protected void QueueRefresh();
}