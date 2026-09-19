using System;
using System.Collections.Generic;
using ScheduleOne.Economy;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.Product;
using ScheduleOne.Quests;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Handover;
public class HandoverScreenContractMode : HandoverScreenMode
{
    [Header("References")]
    [SerializeField]
    private TextMeshProUGUI _contractDescriptionLabel;
    [SerializeField]
    private RectTransform[] _expectationEntries;
    private bool _requireFullChanceOfSuccess;
    public Contract CurrentContract { get; protected set; }
    public Customer CurrentCustomer { get; }

    private event Action<List<ItemInstance>> _onSubmitCallback;
    private event Action _onCancelCallback;
    public void Open(Contract contract, Action<List<ItemInstance>> onSubmitCallback, Action onCancelCallback, bool requireFullChanceOfSuccess = false);
    protected override void OnClose();
    protected override void OnHandoverItemsChanged(List<ItemInstance> items);
    private void Refresh();
    private float GetSuccessChance();
    private bool GetError(out string errorMessage);
    private bool GetWarning(out string warningMessage);
    public override void Submit();
    public override void Cancel();
}