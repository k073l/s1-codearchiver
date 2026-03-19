using System;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Equipping;
using ScheduleOne.UI.Items;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
[Serializable]
[CreateAssetMenu(fileName = "ItemDefinition", menuName = "ScriptableObjects/ItemDefinition", order = 1)]
public abstract class ItemDefinition : BaseItemDefinition
{
    public enum EEquipMode
    {
        Legacy,
        New
    }

    public bool AvailableInDemo;
    [Header("Legacy Equipping Settings")]
    public EEquipMode EquipMode;
    public Equippable Equippable;
    [Header("UI Settings")]
    public ItemUI CustomItemUI;
    public ItemInfoContent CustomInfoContent;
    public abstract ItemInstance GetDefaultInstance(int quantity = 1);
}