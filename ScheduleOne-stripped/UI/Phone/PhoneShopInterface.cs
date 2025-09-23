using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Levelling;
using ScheduleOne.Messaging;
using ScheduleOne.Money;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone;
public class PhoneShopInterface : MonoBehaviour
{
    [Serializable]
    public class Listing
    {
        public StorableItemDefinition Item;
        public float Price => Item.BasePurchasePrice;

        public Listing(StorableItemDefinition item);
    }

    [Serializable]
    public class CartEntry
    {
        public Listing Listing;
        public int Quantity;
        public CartEntry(Listing listing, int quantity);
    }

    public RectTransform EntryPrefab;
    public Color ValidAmountColor;
    public Color InvalidAmountColor;
    [Header("References")]
    public GameObject Container;
    public Text TitleLabel;
    public Text SubtitleLabel;
    public RectTransform EntryContainer;
    public Text OrderTotalLabel;
    public Text OrderLimitLabel;
    public Text DebtLabel;
    public Button ConfirmButton;
    public GameObject ItemLimitContainer;
    public Text ItemLimitLabel;
    private List<RectTransform> _entries;
    private List<Listing> _items;
    private List<CartEntry> _cart;
    private float orderLimit;
    private Action<List<CartEntry>, float> orderConfirmedCallback;
    private MSGConversation conversation;
    public bool IsOpen { get; private set; }

    private void Start();
    public void Open(string title, string subtitle, MSGConversation _conversation, List<Listing> listings, float _orderLimit, float debt, Action<List<CartEntry>, float> _orderConfirmedCallback);
    public void Close();
    public void Exit(ExitAction action);
    private void ChangeListingQuantity(Listing listing, int change);
    private void CartChanged();
    private void ConfirmOrderPressed();
    private bool CanConfirmOrder();
    private void UpdateOrderTotal();
    private float GetOrderTotal(out int itemCount);
}