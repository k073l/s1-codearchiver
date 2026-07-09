using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.GamepadInput;
using ScheduleOne.Messaging;
using ScheduleOne.Money;
using ScheduleOne.Product;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone;
public class CounterofferInterface : MonoBehaviour
{
    public const int COUNTEROFFER_SUCCESS_XP;
    public const int MinQuantity;
    public int MaxQuantity;
    public const float MinPrice;
    public const float MaxPrice;
    public float IconAlignment;
    public GameObject ProductEntryPrefab;
    [Header("References")]
    public GameObject Container;
    public Text TitleLabel;
    public Button ConfirmButton;
    public Image ProductIcon;
    public Text ProductLabel;
    public Text FairPriceLabel;
    public CounterOfferProductSelector ProductSelector;
    public InputField ProductAmountInput;
    public AmountSelector PriceSelector;
    [Header("Gamepad")]
    [SerializeField]
    private InputValueRamp _productAmountInputRamp;
    [Header("Custom UI")]
    public UIScreen uiScreen;
    public UIPanel uiPanel;
    private Action<ProductDefinition, int, float> orderConfirmedCallback;
    private ProductDefinition selectedProduct;
    private int quantity;
    private Dictionary<ProductDefinition, RectTransform> productEntries;
    private bool mouseUp;
    private MSGConversation conversation;
    public bool IsOpen { get; private set; }

    private void Awake();
    private void Start();
    private void Update();
    public void Open(ProductDefinition product, int quantity, float price, MSGConversation _conversation, Action<ProductDefinition, int, float> _orderConfirmedCallback);
    private IEnumerator DelaySelectPanel();
    public void Close();
    public void Exit(ExitAction action);
    public void Send();
    private void UpdateFairPrice();
    private void ApplyFairPrice();
    private void SetProduct(ProductDefinition newProduct);
    private void DisplayProduct(ProductDefinition tempProduct);
    public void ChangeQuantity(float change);
    public void ChangeQuantity(string value);
    private void UpdateQuantityLabel(string productName);
    public void OpenProductSelector();
}