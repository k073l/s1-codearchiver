using System;
using ScheduleOne.GamepadInput;
using ScheduleOne.Money;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.UI.Shop;
public class ListingUI : MonoBehaviour
{
    public static Color32 PriceLabelColor_Normal;
    public static Color32 PriceLabelColor_NoStock;
    [Header("Colors")]
    public Color32 StockLabelDefault;
    public Color32 StockLabelNone;
    [Header("References")]
    public Image Icon;
    public TextMeshProUGUI NameLabel;
    public TextMeshProUGUI PriceLabel;
    public TextMeshProUGUI StockLabel;
    public GameObject LockedContainer;
    public Button BuyButton;
    public Button DropdownButton;
    public EventTrigger Trigger;
    public RectTransform DetailPanelAnchor;
    public RectTransform DropdownAnchor;
    public RectTransform TopDropdownAnchor;
    public Button AddItemButton;
    public Button RemoveItemButton;
    public TMP_InputField ItemAmountInput;
    public UISelectable Selectable;
    [Header("Gamepad")]
    [SerializeField]
    private InputValueRamp _inputValueRamp;
    public Action hoverStart;
    public Action hoverEnd;
    public Action onClicked;
    public Action onDropdownClicked;
    public Action<int> onSetAmount;
    public Action<int> onAdjustAmount;
    public Action onAddItem;
    public Action onRemoveItem;
    public ShopListing Listing { get; protected set; }

    public virtual void Initialize(ShopListing listing);
    public virtual RectTransform GetIconCopy(RectTransform parent);
    public void Update();
    private void AddItem();
    private void RemoveItem();
    private void SetAmount(string amount);
    private void AdjustAmount(int amount);
    private void SetAmount(int amount);
    private void DropdownClicked();
    private void HoverStart();
    private void HoverEnd();
    private void StockChanged();
    public void Reset();
    private void UpdatePrice();
    private void UpdateStock();
    public void UpdateQuantityInCart();
    private void UpdateButtons();
    public bool CanAddToCart();
    public bool CanRemoveFromCart();
    public void UpdateLockStatus();
}