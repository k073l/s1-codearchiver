using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Interaction;
using ScheduleOne.Money;
using ScheduleOne.ObjectScripts.Cash;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Property;
using ScheduleOne.State;
using ScheduleOne.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class LaunderingInterface : MonoBehaviour
{
    private const float FoV;
    private const float LerpTime;
    private const int MinLaunderAmount;
    [Header("References")]
    [SerializeField]
    protected Transform cameraPosition;
    [SerializeField]
    protected InteractableObject intObj;
    [SerializeField]
    protected Button launderButton;
    [SerializeField]
    protected GameObject amountSelectorScreen;
    [SerializeField]
    protected Slider amountSlider;
    [SerializeField]
    protected TMP_InputField amountInputField;
    [SerializeField]
    protected RectTransform notchContainer;
    [SerializeField]
    protected TextMeshProUGUI currentTotalAmountLabel;
    [SerializeField]
    protected TextMeshProUGUI launderCapacityLabel;
    [SerializeField]
    protected TextMeshProUGUI insufficientCashLabel;
    [SerializeField]
    protected RectTransform entryContainer;
    [SerializeField]
    protected RectTransform noEntries;
    [SerializeField]
    protected RectTransform container;
    [SerializeField]
    protected CashStackVisuals[] cashStacks;
    [SerializeField]
    protected MonoState mainState;
    [SerializeField]
    protected MonoState amountSelectorState;
    [Header("Prefabs")]
    [SerializeField]
    protected GameObject timelineNotchPrefab;
    [SerializeField]
    protected GameObject entryPrefab;
    [Header("UI references")]
    [SerializeField]
    protected Canvas canvas;
    [SerializeField]
    protected ScrollRect scrollRect;
    private int selectedAmountToLaunder;
    private Dictionary<LaunderingOperation, RectTransform> operationToNotch;
    private List<RectTransform> notches;
    private bool ignoreSliderChange;
    private Dictionary<LaunderingOperation, RectTransform> operationToEntry;
    public bool IsOpen { get; }
    public Business Business { get; private set; }
    private int maxLaunderAmount => (int)Mathf.Min(Business.appliedLaunderLimit, NetworkSingleton<MoneyManager>.Instance.cashBalance);

    private void Awake();
    public void Initialize(Business bus);
    private void OnDestroy();
    protected virtual void MinPass();
    protected void UpdateTimeline();
    protected void UpdateCurrentTotal();
    private void CreateEntry(LaunderingOperation op);
    private void RemoveEntry(LaunderingOperation op);
    private void UpdateEntryTimes();
    private void UpdateCashStacks(LaunderingOperation op);
    private void RefreshLaunderButton();
    public void OpenAmountSelector();
    public void CloseAmountSelector();
    private void OnAmountSelectorClose();
    public void ConfirmAmount();
    public void SliderValueChanged();
    public void InputValueChanged();
    public void ChangeSelectorValue(int amount);
    public void Hovered();
    public void Interacted();
    public void Open();
    private void OnClose();
}