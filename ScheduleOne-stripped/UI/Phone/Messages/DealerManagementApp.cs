using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.Product;
using ScheduleOne.UI.Tooltips;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.Messages;
public class DealerManagementApp : App<DealerManagementApp>
{
    private class InventoryItem
    {
        public string ID;
        public int Quantity;
        public int Quality;
        public InventoryItem(string id, int quantity, int quality);
    }

    [Header("References")]
    public Text NoDealersLabel;
    public RectTransform Content;
    public CustomerSelector CustomerSelector;
    [Header("Selector")]
    public Image SelectorImage;
    public Text SelectorTitle;
    public Button BackButton;
    public Button NextButton;
    [SerializeField]
    private DropdownUI _dropdown;
    [SerializeField]
    private Image _dropdownBackground;
    [SerializeField]
    private Image _dropdownCaptionImage;
    [SerializeField]
    private Text _dropDownCaptionText;
    [Header("Basic Info")]
    public Text CashLabel;
    public Text CutLabel;
    public Text HomeLabel;
    [Header("Inventory")]
    [SerializeField]
    private Text _inventoryTextLabel;
    [SerializeField]
    private RectTransform _inventoryEntryContainer;
    public RectTransform[] InventoryEntries;
    [Header("Customers")]
    public Text CustomerTitleLabel;
    public RectTransform[] CustomerEntries;
    public Button AssignCustomerButton;
    [Header("Fonts")]
    [SerializeField]
    private SpriteFont _uiGeneralSpriteFont;
    [SerializeField]
    private ColorFont _productColorFont;
    private List<Dealer> dealers;
    private bool _isOpen;
    public Dealer SelectedDealer { get; private set; }

    protected override void Awake();
    protected override void Start();
    protected override void OnDestroy();
    public void Refresh();
    public override void SetOpen(bool open);
    public void SetDisplayedDealer(Dealer dealer);
    private void AddDealer(Dealer dealer);
    private void AddCustomer(Customer customer);
    private void RemoveCustomer(Customer customer);
    private void BackPressed();
    private void NextPressed();
    public void AssignCustomer();
    private void RefreshDropdown();
    private void OnDropdownValueChanged(int value);
    private void OnDropdownOpen();
}