using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Levelling;
using ScheduleOne.StationFramework;
using ScheduleOne.Storage;
using ScheduleOne.UI.Shop;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
[Serializable]
[CreateAssetMenu(fileName = "StorableItemDefinition", menuName = "ScriptableObjects/StorableItemDefinition", order = 1)]
public class StorableItemDefinition : ItemDefinition
{
    [Header("Purchasing")]
    public float BasePurchasePrice;
    public List<ShopListing.CategoryInstance> ShopCategories;
    public bool RequiresLevelToPurchase;
    public FullRank RequiredRank;
    [Header("Reselling")]
    [Range(0f, 1f)]
    public float ResellMultiplier;
    [Header("Storable Item")]
    public StoredItem StoredItem;
    [Range(0.1f, 5f)]
    public float PickpocketDifficultyMultiplier;
    [Tooltip("Optional station item if this item can be used at a station.")]
    public StationItem StationItem;
    [Header("Other Settings")]
    [Range(0f, 1f)]
    public float CombatUtilityForNPCs;
    public bool IsPurchasable { get; }

    public override ItemInstance GetDefaultInstance(int quantity = 1);
}