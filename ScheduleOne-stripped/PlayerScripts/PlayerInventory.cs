using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Equipping;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.Product;
using ScheduleOne.Product.Packaging;
using ScheduleOne.State;
using ScheduleOne.UI;
using ScheduleOne.UI.Items;
using ScheduleOne.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ScheduleOne.PlayerScripts;
public class PlayerInventory : PlayerSingleton<PlayerInventory>, IFirstPersonReferencesProvider
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

    public const int InventorySlotCount;
    private const float LabelDisplayTime;
    private const float LabelFadeTime;
    private const float DiscardDuration;
    [Header("Startup Items (Editor only)")]
    [SerializeField]
    private bool giveStartupItems;
    [SerializeField]
    private List<ItemAmount> startupItems;
    [Header("References")]
    [SerializeField]
    private Transform equipContainer;
    public List<HotbarSlot> hotbarSlots;
    private ClipboardSlot clipboardSlot;
    private List<ItemSlotUI> slotUIs;
    private List<HotbarSlot> equippableSlots;
    private ItemSlot discardSlot;
    [Header("Input")]
    [SerializeField]
    private InputActionReference _holsterAction;
    [Header("Item Variables")]
    public List<ItemVariable> ItemVariables;
    private int _equippedSlotIndex;
    public Action<bool> onInventoryStateChanged;
    public Action<int> onEquippedSlotChanged;
    public UnityEvent onPreItemEquipped;
    public UnityEvent onItemEquipped;
    private int PriorEquippedSlotIndex;
    private int PreviousEquippedSlotIndex;
    private bool _managementSlotEnabled;
    private float _currentDiscardTime;
    protected UIPanel uiPanel;
    protected UIPanel originalSelectedPanel;
    private int EquippableSlotCount => 9 + (_managementSlotEnabled ? 1 : 0);
    public Transform EquipContainer => equipContainer;
    public CashSlot cashSlot { get; private set; }
    public List<ItemSlotUI> SlotUIs => slotUIs;
    public CashInstance cashInstance { get; protected set; }
    public int EquippedSlotIndex { get; set; }
    public bool HotbarEnabled { get; protected set; } = true;
    public bool EquippingEnabled { get; protected set; } = true;
    public bool HolsterEnabled { get; set; } = true;
    public Equippable Equippable { get; protected set; }
    public float CurrentEquipTime { get; private set; }
    public UIScreen AttachedScreen { get; private set; }
    public HotbarSlot equippedSlot { get; }
    public ItemInstance EquippedItem { get; }
    public bool isAnythingEquipped => EquippedItem != null;

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
    public void AttachToScreen(UIScreen screen, bool alsoSelectInventoryPanel = true);
    public void DetachFromScreen();
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
    private void HotbarSlotSelected(HotbarSlot slot);
    private void UpdateInventoryVariables();
}