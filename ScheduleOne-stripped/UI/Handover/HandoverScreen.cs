using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.ItemFramework;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.Quests;
using ScheduleOne.State;
using ScheduleOne.UI.Items;
using ScheduleOne.Vehicles;
using ScheduleOne.Vision;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ScheduleOne.UI.Handover;
public class HandoverScreen : Singleton<HandoverScreen>
{
    public enum EMode
    {
        Contract,
        Sample,
        Offer,
        SpecialCustomers
    }

    private const int CustomerSlotCount;
    private const float VehicleMaxDistance;
    [Header("Settings")]
    [FormerlySerializedAs("SuccessColorMap")]
    [SerializeField]
    private Gradient _successColorMap;
    [Header("References")]
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private GameObject _mainContainer;
    [SerializeField]
    private TextMeshProUGUI _titleLabel;
    [SerializeField]
    private TextMeshProUGUI _instructionLabel;
    [SerializeField]
    private RectTransform _vehicleContainer;
    [SerializeField]
    private RectTransform _customerSlotContainer;
    [SerializeField]
    private TextMeshProUGUI _vehicleSubtitle;
    [SerializeField]
    private TextMeshProUGUI _successLabel;
    [SerializeField]
    private TextMeshProUGUI _errorLabel;
    [SerializeField]
    private TextMeshProUGUI _warningLabel;
    [SerializeField]
    private Button _doneButton;
    [SerializeField]
    private TextMeshProUGUI _doneLabel;
    [SerializeField]
    private HandoverScreenCustomerInfoPanel _customerInfoPanel;
    [SerializeField]
    private MonoState _state;
    [Header("Modes")]
    [SerializeField]
    private HandoverScreenContractMode _contractMode;
    [SerializeField]
    private HandoverScreenSampleMode _sampleMode;
    [SerializeField]
    private HandoverScreenOfferMode _offerMode;
    [SerializeField]
    private HandoverScreenSpecialCustomerMode _specialCustomerMode;
    private HandoverScreenMode _activeMode;
    private ItemSlotUI[] _vehicleSlotUIs;
    private ItemSlotUI[] _customerSlotUIs;
    private ItemSlot[] _customerSlots;
    public bool IsOpen { get; private set; }

    public event Action<List<ItemInstance>> onHandoverItemsChanged;
    public event Action<EMode> OnHandoverScreenOpened;
    public event Action OnHandoverScreenClosed;
    protected override void Start();
    private void Exit(ExitAction action);
    public void Open_Contract(Contract contract, Action<List<ItemInstance>> onSubmitCallback, Action onCancelCallback, bool requireFullChanceOfSuccess = false);
    public void Open_Sample(Customer customer, Action<List<ItemInstance>> onSubmitCallback, Action onCancelCallback, Func<List<ItemInstance>, float> getSuccessChance);
    public void Open_Offer(Customer customer, Action<List<ItemInstance>, float> onSubmitCallback, Action onCancelCallback, Func<List<ItemInstance>, float, float> getSuccessChance);
    public void Open_SpecialCustomer(SpecialCustomerLeader groupLeader, Action<List<ItemInstance>> onSubmitCallback, Action onCancelCallback);
    public void Close();
    private void OnOpen(EMode mode);
    private void OnStateRemovedFromStack();
    private void OnClose();
    private void SetActiveMode(HandoverScreenMode mode);
    private bool TryGetNearbyVehicle(out LandVehicle vehicle);
    public void DestroyCustomerItems();
    public void TransferCustomerItemsToNPC(NPC npc);
    public void ReturnCustomerItems();
    private void HandoverItemsChanged();
    public void SetTitle(string title);
    public void SetInstruction(string instruction);
    public void OpenCustomerInfoPanel(Customer customer);
    public void CloseCustomerInfoPanel();
    public void SetDoneButtonLabel(string label);
    public void SetDoneButtonInteractable(bool interactable);
    public void SetError(string error);
    public void ClearError();
    public void SetWarning(string warning);
    public void ClearWarning();
    private void DoneButtonPressed();
    public void ShowSuccessChance(float chance);
    public void HideSuccessChance();
    public float GetPackagedProductMarketValue();
    public List<ItemInstance> GetHandoverItems();
    public List<ProductItemInstance> GetHandoverProducts(bool filterForPackagedOnly);
    public int GetHandoverProductsTotalQuantity(bool filterForPackagedOnly);
}