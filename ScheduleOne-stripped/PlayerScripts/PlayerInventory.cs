using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Equipping;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.Product;
using ScheduleOne.Product.Packaging;
using ScheduleOne.UI;
using ScheduleOne.UI.Items;
using ScheduleOne.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.PlayerScripts;
public class PlayerInventory : PlayerSingleton<PlayerInventory>
{
    [Serializable]
    public class ItemVariable
    {
        public ItemDefinition Definition;
        public string VariableName;
    }

    [Serializable]
    private class ItemAmount
    {
        public ItemDefinition Definition;
        public int Amount;
    }

    public const float LABEL_DISPLAY_TIME;
    public const float LABEL_FADE_TIME;
    public const float DISCARD_TIME;
    public const int INVENTORY_SLOT_COUNT;
    [Header("Startup Items (Editor only)")]
    [SerializeField]
    private bool giveStartupItems;
    [SerializeField]
    private List<ItemAmount> startupItems;
    [Header("References")]
    public Transform equipContainer;
    public List<HotbarSlot> hotbarSlots;
    private ClipboardSlot clipboardSlot;
    private List<ItemSlotUI> slotUIs;
    private ItemSlot discardSlot;
    [Header("Item Variables")]
    public List<ItemVariable> ItemVariables;
    public Action<bool> onInventoryStateChanged;
    public Action<int> onEquippedSlotChanged;
    private int PriorEquippedSlotIndex;
    private int PreviousEquippedSlotIndex;
    public UnityEvent onPreItemEquipped;
    public UnityEvent onItemEquipped;
    private bool ManagementSlotEnabled;
    public float currentEquipTime;
    protected float currentDiscardTime;
    public int TOTAL_SLOT_COUNT => 9 + (ManagementSlotEnabled ? 1 : 0);
    public CashSlot cashSlot { get; private set; }
    public CashInstance cashInstance { get; protected set; }
    public int EquippedSlotIndex { get; protected set; } = -1;
    public bool HotbarEnabled { get; protected set; } = true;
    public bool EquippingEnabled { get; protected set; } = true;
    public Equippable equippable { get; protected set; }
    public HotbarSlot equippedSlot { get; }
    public bool isAnythingEquipped { get; }

    public HotbarSlot IndexAllSlots(int index);
    protected override void Awake();
    private void SetupInventoryUI();
    private void RepositionUI();
    protected override void Start();
    private void GiveStartupItems();
    protected virtual void Update();
    private void UpdateHotbarSelection();
    public void Equip(HotbarSlot slot);
    public void SetInventoryEnabled(bool enabled);
    public void SetEquippingEnabled(bool enabled);
    private void ClipboardAcquiredVarChange(bool newVal);
    public void SetManagementClipboardEnabled(bool enabled);
    public void SetViewmodelVisible(bool visible);
    public bool CanItemFitInInventory(ItemInstance item, int quantity = 1);
    public void AddItemToInventory(ItemInstance item);
    public uint GetAmountOfItem(string ID);
    public void RemoveAmountOfItem(string ID, uint amount = 1u);
    public void ClearInventory();
    public void RemoveProductFromInventory(EStealthLevel maxStealth);
    public void RemoveRandomItemsFromInventory();
    public void SetEquippable(Equippable eq);
    public void EquippedSlotChanged();
    public void Reequip();
    public List<ItemSlot> GetAllInventorySlots();
    private void UpdateInventoryVariables();
}