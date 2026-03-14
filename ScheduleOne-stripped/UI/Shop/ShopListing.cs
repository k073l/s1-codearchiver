using System;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.Shop;
[Serializable]
public class ShopListing
{
    [Serializable]
    public class CategoryInstance
    {
        public EShopCategory Category;
    }

    public enum ERestockRate
    {
        Daily,
        Weekly,
        Never
    }

    public string name;
    public StorableItemDefinition Item;
    [Header("Pricing")]
    [SerializeField]
    protected bool OverridePrice;
    [SerializeField]
    protected float OverriddenPrice;
    [Header("Stock")]
    public bool LimitedStock;
    public int DefaultStock;
    public ERestockRate RestockRate;
    public bool TieStockToNumberVariable;
    public string StockVariableName;
    [Header("Purchase Tracking")]
    public bool TrackPurchases;
    public string PurchasedQuantityVariableName;
    [Header("Settings")]
    public bool EnforceMinimumGameCreationVersion;
    public float MinimumGameCreationVersion;
    public bool CanBeDelivered;
    [Header("Color")]
    public bool UseIconTint;
    public Color IconTint;
    [Header("Visibility")]
    public bool ConditionalVisibility;
    public string ConditionalVisibilityVariableName;
    public Action onStockChanged;
    private NumberVariable stockVariable;
    private NumberVariable purchasedQuantityVariable;
    private BoolVariable conditionalVisibilityVariable;
    public bool IsInStock => true;
    public float Price { get; }
    public bool IsUnlimitedStock => !LimitedStock;
    public ShopInterface Shop { get; private set; }
    public int CurrentStock { get; protected set; }
    public int QuantityInCart { get; private set; }
    public int CurrentStockMinusCart => CurrentStock - QuantityInCart;

    public void Initialize(ShopInterface shop);
    public void Restock(bool network);
    public void RemoveStock(int quantity);
    public void SetStock(int quantity, bool network = true);
    public void PullStockFromVariable();
    private void StockVariableChanged(float newValue);
    public virtual bool ShouldShow();
    public virtual bool DoesListingMatchCategoryFilter(EShopCategory category);
    public virtual bool DoesListingMatchSearchTerm(string searchTerm);
    public void SetQuantityInCart(int quantity);
}