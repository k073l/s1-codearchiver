using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Configuration;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Core.Settings.Framework;
using ScheduleOne.Delivery;
using ScheduleOne.DevUtilities;
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
    public Image HeaderImage;
    public Button HeaderButton;
    public RectTransform ContentsContainer;
    public RectTransform ListingContainer;
    public Text DeliveryFeeLabel;
    public Text ItemTotalLabel;
    public Text OrderTotalLabel;
    public Button OrderButton;
    public Text OrderButtonNote;
    public Dropdown DestinationDropdown;
    public Dropdown LoadingDockDropdown;
    [Header("Settings")]
    public string MatchingShopInterfaceName;
    public bool AvailableByDefault;
    public ListingEntry ListingEntryPrefab;
    public Sprite HeaderImage_Hidden;
    public Sprite HeaderImage_Expanded;
    public RectTransform HeaderArrow;
    private List<ListingEntry> listingEntries;
    private ScheduleOne.Property.Property destinationProperty;
    private int loadingDockIndex;
    public ShopInterface MatchingShop { get; private set; }
    public bool IsExpanded { get; private set; }
    public bool IsAvailable { get; private set; }

    private void Start();
    private void FixedUpdate();
    public void SetIsExpanded(bool expanded);
    public void SetIsAvailable();
    public void OrderPressed();
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
    private float GetOrderTotal();
    private int GetOrderItemCount();
    private void RefreshEntryOrder();
    private void RefreshEntriesLocked();
}