using System;
using System.Collections.Generic;
using ScheduleOne.Economy;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.Product;
using TMPro;
using UnityEngine;

namespace ScheduleOne.UI.Handover;
public class HandoverScreenOfferMode : HandoverScreenMode
{
    [Header("References")]
    [SerializeField]
    private GameObject _priceSelectorContainer;
    [SerializeField]
    private AmountSelector _priceSelector;
    [SerializeField]
    private TextMeshProUGUI _fairPriceLabel;
    private Customer _customer;
    private event Action<List<ItemInstance>, float> _onSubmitCallback;
    private event Action _onCancelCallback;
    private event Func<List<ItemInstance>, float, float> _successChanceMethod;
    private void Awake();
    public void Open(Customer customer, Action<List<ItemInstance>, float> onSubmitCallback, Action onCancelCallback, Func<List<ItemInstance>, float, float> getSuccessChance);
    protected override void OnClose();
    private void OnPriceChanged(float newPrice);
    protected override void OnHandoverItemsChanged(List<ItemInstance> items);
    private void Refresh();
    private bool GetError(out string errorMessage);
    private bool GetWarning(out string warningMessage);
    private float GetSuccessChance();
    public override void Submit();
    public override void Cancel();
}