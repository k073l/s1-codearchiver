using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EasyButtons;
using FishNet;
using ScheduleOne.Audio;
using ScheduleOne.Delivery;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Levelling;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Storage;
using ScheduleOne.Variables;
using ScheduleOne.Vehicles;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Shop;
public class ShopInterface : MonoBehaviour, ISaveable
{
    public enum EPaymentType
    {
        Cash,
        Online,
        PreferCash,
        PreferOnline
    }

    public static List<ShopInterface> AllShops;
    public const int MAX_ITEM_QUANTITY;
    [Header("Settings")]
    public string ShopName;
    public string ShopCode;
    public EPaymentType PaymentType;
    public bool ShowCurrencyHint;
    [Header("Listings")]
    public List<ShopListing> Listings;
    [Header("References")]
    public Canvas Canvas;
    public RectTransform Container;
    public RectTransform ListingContainer;
    public TextMeshProUGUI StoreNameLabel;
    public Cart Cart;
    public StorageEntity[] DeliveryBays;
    public VehicleDetector LoadingBayDetector;
    public ShopInterfaceDetailPanel DetailPanel;
    public ScrollRect ListingScrollRect;
    public ShopAmountSelector AmountSelector;
    public DeliveryVehicle DeliveryVehicle;
    [Header("Audio")]
    public AudioSourceController AddItemSound;
    public AudioSourceController RemoveItemSound;
    public AudioSourceController CheckoutSound;
    [Header("Prefabs")]
    public ListingUI ListingUIPrefab;
    public UnityEvent onOrderCompleted;
    [SerializeField]
    private List<CategoryButton> categoryButtons;
    private EShopCategory categoryFilter;
    private string searchTerm;
    private List<ListingUI> listingUI;
    private ListingUI selectedListing;
    private bool dropdownMouseUp;
    private ShopLoader loader;
    public bool IsOpen { get; protected set; }
    public string SaveFolderName => SaveManager.MakeFileSafe(ShopCode);
    public string SaveFileName => SaveManager.MakeFileSafe(ShopCode);
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; } = true;

    protected virtual void Awake();
    protected virtual void Start();
    public virtual void InitializeSaveable();
    private void OnDestroy();
    private void OnValidate();
    protected virtual void Update();
    protected void OnDayPass();
    protected void OnWeekPass();
    [Button]
    public void Open();
    public virtual void SetIsOpen(bool isOpen);
    private void Hint();
    protected virtual void Exit(ExitAction action);
    private void CreateListingUI(ShopListing listing);
    public void SelectCategory(EShopCategory category);
    public virtual void ListingClicked(ListingUI listingUI);
    private void ShowCartAnimation(ListingUI listing);
    public void CategorySelected(EShopCategory category);
    private void PullStockVariables();
    private void DeselectCurrentCategory();
    private void RefreshShownItems();
    private void RefreshUnlockStatus();
    private void RestockAllListings();
    public bool CanCartFitItem(ShopListing listing);
    public bool WillCartFit();
    public bool WillCartFit(List<ItemSlot> availableSlots);
    public virtual bool HandoverItems();
    public List<ItemSlot> GetAvailableSlots();
    public LandVehicle GetLoadingBayVehicle();
    public void PlaceItemInDeliveryBay(ItemInstance item);
    public void QuantitySelected(int amount);
    public void OpenAmountSelector(ListingUI listing);
    private void DropdownClicked(ListingUI listing);
    private void EntryHovered(ListingUI listing);
    private void EntryUnhovered();
    public void Load(ShopData data);
    public bool ShouldSave();
    public ShopListing GetListing(string itemID);
    public virtual ShopData GetSaveData();
    public string GetSaveString();
}