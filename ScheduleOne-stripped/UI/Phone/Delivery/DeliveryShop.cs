using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Configuration;
using ScheduleOne.Delivery;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Money;
using ScheduleOne.Property;
using ScheduleOne.UI.Shop;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.Delivery;
public class DeliveryShop : MonoBehaviour
{
    [Header("References")]
    public Button BackButton;
    public RectTransform ListingContainer;
    public Text DeliveryFeeLabel;
    public Text ItemTotalLabel;
    public Text OrderTotalLabel;
    public Text DeliveryTimeLabel;
    public Button OrderButton;
    public Text OrderButtonNote;
    public Dropdown DestinationDropdown;
    public Dropdown LoadingDockDropdown;
    [Header("Settings")]
    public string MatchingShopInterfaceName;
    public Color ShopColor;
    public bool AvailableByDefault;
    public ListingEntry ListingEntryPrefab;
    private List<ListingEntry> listingEntries;
    private ScheduleOne.Property.Property destinationProperty;
    private int loadingDockIndex;
    private Action<DeliveryShop> _onSelect;
    public ShopInterface MatchingShop { get; private set; }
    public bool IsOpen { get; private set; }
    public Action<DeliveryShop> OnSelect { get; set; }

    public void Initialize();
    private void FixedUpdate();
    public void Open();
    public void Close();
    public void SubmitOrder(string originalDeliveryID);
    private int GetDeliveryTime(int itemCount);
    public void Reorder(DeliveryReceipt receipt);
    public bool CanReorder(DeliveryReceipt receipt, out string reason);
    public float GetDeliveryCost(DeliveryReceipt receipt);
    public void RefreshShop();
    public void ResetCart();
    private void RefreshCart();
    private void RefreshOrderButton();
    public bool CanOrder(out string reason);
    public bool HasActiveDelivery();
    public bool WillCartFitInVehicle();
    public void RefreshDestinationUI();
    private void DestinationDropdownSelected(int index);
    private List<ScheduleOne.Property.Property> GetPotentialDestinations();
    public void RefreshLoadingDockUI();
    private void LoadingDockDropdownSelected(int index);
    private float GetCartCost();
    private float GetDeliveryFee();
    private int GetOrderItemCount();
    private void RefreshEntryOrder();
    private void RefreshEntriesLocked();
}