using System;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class Inventory
{
    [Serializable]
    public class WeightedItem
    {
        public ItemDefinition Item;
        public float Weight;
    }

    public int InventorySlotCount;
    public bool ClearInventoryOnNewDay;
    [Header("Random Inventory Settings")]
    public bool RandomizeInventory;
    public bool AllowDuplicateRandomItems;
    public WeightedItem[] RandomInventoryItems;
    [Header("Random Cash")]
    public bool RandomizeCash;
    [Range(0f, 1000f)]
    public int MinRandomCash;
    [Range(0f, 1000f)]
    public int MaxRandomCash;
    [Header("Starting Inventory")]
    public ItemDefinition[] StartingInventoryItems;
    [Header("Pickpocket Settings")]
    public bool CanBePickpocketed;
    public float PickpocketDifficulty;
    [Header("Combat")]
    public AvatarWeapon DefaultCombatWeapon;
    public Inventory GetCopy();
}