using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Shop;
public class Cart : MonoBehaviour
{
    [Header("References")]
    public ShopInterface Shop;
    public Image CartIcon;
    public TextMeshProUGUI ViewCartText;
    public RectTransform CartEntryContainer;
    public TextMeshProUGUI ProblemText;
    public TextMeshProUGUI WarningText;
    public Button BuyButton;
    public RectTransform CartContainer;
    public Image CartArea;
    public TextMeshProUGUI TotalText;
    public Toggle LoadVehicleToggle;
    [Header("Prefabs")]
    public CartEntry EntryPrefab;
    public Dictionary<ShopListing, int> cartDictionary;
    private Coroutine cartIconBop;
    private List<CartEntry> cartEntries;
    protected virtual void Start();
    protected virtual void Update();
    public void AddItem(ShopListing listing, int quantity);
    public void RemoveItem(ShopListing listing, int quantity);
    public void ClearCart();
    public int GetCartCount(ShopListing listing);
    public void BopCartIcon();
    public bool CanPlayerAffordCart();
    public void Buy();
    private void UpdateEntries();
    private void UpdateTotal();
    private void UpdateProblem();
    private bool CanCheckout(out string reason);
    private bool GetWarning(out string warning);
    private void UpdateViewCartText();
    private void UpdateLoadVehicleToggle();
    private int GetItemSum();
    private float GetPriceSum();
    private CartEntry GetEntry(ShopListing listing);
    private bool IsMouseOverMenuArea();
    public int GetTotalSlotRequirement();
}