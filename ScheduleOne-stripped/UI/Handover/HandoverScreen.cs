using System;
using System.Collections.Generic;
using EasyButtons;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.Quests;
using ScheduleOne.UI.Compass;
using ScheduleOne.UI.Items;
using ScheduleOne.Variables;
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

    private enum EItemSource
    {
        Player,
        Vehicle
    }

    public const int CUSTOMER_SLOT_COUNT;
    public const float VEHICLE_MAX_DIST;
    [Header("Settings")]
    public Gradient SuccessColorMap;
    [Header("References")]
    public Canvas Canvas;
    public GameObject Container;
    public CanvasGroup CanvasGroup;
    public TextMeshProUGUI DescriptionLabel;
    public TextMeshProUGUI CustomerSubtitle;
    public TextMeshProUGUI FavouriteDrugLabel;
    public TextMeshProUGUI FavouritePropertiesLabel;
    public TextMeshProUGUI[] PropertiesEntries;
    public RectTransform[] ExpectationEntries;
    public GameObject NoVehicle;
    public RectTransform VehicleSlotContainer;
    public RectTransform CustomerSlotContainer;
    public TextMeshProUGUI VehicleSubtitle;
    public TextMeshProUGUI SuccessLabel;
    public TextMeshProUGUI ErrorLabel;
    public TextMeshProUGUI WarningLabel;
    public Button DoneButton;
    public RectTransform VehicleContainer;
    public TextMeshProUGUI TitleLabel;
    public HandoverScreenPriceSelector PriceSelector;
    public TextMeshProUGUI FairPriceLabel;
    public Animation TutorialAnimation;
    public RectTransform TutorialContainer;
    public HandoverScreenDetailPanel DetailPanel;
    public Action<EHandoverOutcome, List<ItemInstance>, float> onHandoverComplete;
    public Func<List<ItemInstance>, float, float> SuccessChanceMethod;
    private ItemSlotUI[] VehicleSlotUIs;
    private ItemSlotUI[] CustomerSlotUIs;
    private ItemSlot[] CustomerSlots;
    private Dictionary<ItemInstance, EItemSource> OriginalItemLocations;
    private bool ignoreCustomerChangedEvents;
    private bool requireFullChanceOfSuccess;
    public Contract CurrentContract { get; protected set; }
    public bool IsOpen { get; protected set; }
    public bool TutorialOpen { get; private set; }
    public EMode Mode { get; protected set; }
    public Customer CurrentCustomer { get; private set; }

    protected override void Start();
    private void Update();
    private void OpenTutorial();
    public void CloseTutorial();
    [Button]
    public void TestOpen();
    public virtual void Open(Contract contract, Customer customer, EMode mode, Action<EHandoverOutcome, List<ItemInstance>, float> callback, Func<List<ItemInstance>, float, float> successChanceMethod, bool _requireFullChanceOfSuccess = false);
    public virtual void Close(EHandoverOutcome outcome);
    public void DonePressed();
    private void RecordOriginalLocations();
    private void Exit(ExitAction action);
    public void ClearCustomerSlots(bool returnToOriginals);
    private void CustomerItemsChanged();
    private void UpdateDoneButton();
    private void UpdateSuccessChance();
    private bool GetError(out string err);
    private bool GetWarning(out string warning);
    private List<ItemInstance> GetCustomerItems(bool onlyPackagedProduct = true);
    private float GetCustomerItemsValue();
    private int GetCustomerItemsCount(bool onlyPackagedProduct = true);
}