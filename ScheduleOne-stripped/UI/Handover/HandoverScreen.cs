using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.Quests;
using ScheduleOne.State;
using ScheduleOne.UI.Items;
using ScheduleOne.Vision;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Handover;
public class HandoverScreen : Singleton<HandoverScreen>
{
    public enum EMode
    {
        Contract,
        Sample,
        Offer
    }

    public enum EHandoverOutcome
    {
        Cancelled,
        Finalize
    }

    private const int CustomerSlotCount;
    private const float VehicleMaxDistance;
    [Header("Settings")]
    public Gradient SuccessColorMap;
    [Header("References")]
    public Canvas Canvas;
    public GameObject Container;
    public CanvasGroup CanvasGroup;
    public TextMeshProUGUI InstructionLabel;
    public TextMeshProUGUI ContractDescriptionLabel;
    public RectTransform[] ExpectationEntries;
    public RectTransform VehicleSlotContainer;
    public RectTransform CustomerSlotContainer;
    public TextMeshProUGUI VehicleSubtitle;
    public TextMeshProUGUI SuccessLabel;
    public TextMeshProUGUI ErrorLabel;
    public TextMeshProUGUI WarningLabel;
    public Button DoneButton;
    public RectTransform VehicleContainer;
    public TextMeshProUGUI TitleLabel;
    public AmountSelector PriceSelector;
    public TextMeshProUGUI FairPriceLabel;
    public HandoverScreenDetailPanel DetailPanel;
    public MonoState State;
    private EMode _mode;
    private ItemSlotUI[] _vehicleSlotUIs;
    private ItemSlotUI[] _customerSlotUIs;
    private ItemSlot[] _customerSlots;
    private bool _ignoreCustomerChangedEvents;
    private bool _requireFullChanceOfSuccess;
    private EHandoverOutcome _outcome;
    public bool IsOpen { get; protected set; }
    public Contract CurrentContract { get; protected set; }
    public Customer CurrentCustomer { get; private set; }

    public event Action<EMode> OnHandoverScreenOpened;
    public event Action OnHandoverScreenClosed;
    private event Action<EHandoverOutcome, List<ItemInstance>, float> _onHandoverCompleteCallback;
    private event Func<List<ItemInstance>, float, float> _successChanceMethod;
    protected override void Start();
    private void Update();
    [Button]
    public void TestOpen();
    public void Open(Contract contract, Customer customer, EMode mode, Action<EHandoverOutcome, List<ItemInstance>, float> callback, Func<List<ItemInstance>, float, float> successChanceMethod, bool requireFullChanceOfSuccess = false);
    public void Close(EHandoverOutcome outcome);
    private void OnClose();
    public void DonePressed();
    private void Exit(ExitAction action);
    public void ClearCustomerSlots(bool returnToOriginals);
    private void CustomerItemsChanged();
    private void UpdateDoneButton();
    private void PriceChanged(float newPrice);
    private void UpdateSuccessChance();
    private bool GetError(out string err);
    private bool GetWarning(out string warning);
    private List<ItemInstance> GetCustomerItems(bool onlyPackagedProduct = true);
    private float GetCustomerItemsValue();
    private int GetCustomerItemsCount(bool onlyPackagedProduct = true);
}