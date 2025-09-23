using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.UI.ATM;
public class ATMInterface : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    protected Canvas canvas;
    [SerializeField]
    protected ScheduleOne.Money.ATM atm;
    [SerializeField]
    protected AudioSourceController CompleteSound;
    [Header("Menu")]
    [SerializeField]
    protected RectTransform menuScreen;
    [SerializeField]
    protected Text menu_TitleText;
    [SerializeField]
    protected Button menu_DepositButton;
    [SerializeField]
    protected Button menu_WithdrawButton;
    [Header("Top bar")]
    [SerializeField]
    protected Text depositLimitText;
    [SerializeField]
    protected Text onlineBalanceText;
    [SerializeField]
    protected Text cleanCashText;
    [SerializeField]
    protected RectTransform depositLimitContainer;
    [Header("Amount screen")]
    [SerializeField]
    protected RectTransform amountSelectorScreen;
    [SerializeField]
    protected Text amountSelectorTitle;
    [SerializeField]
    protected List<Button> amountButtons;
    [SerializeField]
    protected Text amountLabelText;
    [SerializeField]
    protected RectTransform amountBackground;
    [SerializeField]
    protected RectTransform selectedButtonIndicator;
    [SerializeField]
    protected Button confirmAmountButton;
    [SerializeField]
    protected Text confirmButtonText;
    [Header("Processing screen")]
    [SerializeField]
    protected RectTransform processingScreen;
    [SerializeField]
    protected RectTransform processingScreenIndicator;
    [Header("Success screen")]
    [SerializeField]
    protected RectTransform successScreen;
    [SerializeField]
    protected Text successScreenSubtitle;
    [SerializeField]
    protected Button doneButton;
    private RectTransform activeScreen;
    public static int[] amounts;
    private bool depositing;
    private int selectedAmountIndex;
    private float selectedAmount;
    public bool isOpen { get; protected set; }
    private float relevantBalance { get; }
    private static float remainingAllowedDeposit => 10000f - ScheduleOne.Money.ATM.WeeklyDepositSum;

    private void Awake();
    private void OnDestroy();
    protected virtual void Start();
    private void PlayerSpawned();
    protected virtual void Update();
    protected virtual void LateUpdate();
    public virtual void SetIsOpen(bool o);
    public virtual void Exit(ExitAction action);
    public void SetActiveScreen(RectTransform screen);
    private void DefaultAmountSelection();
    public void DepositButtonPressed();
    public void WithdrawButtonPressed();
    public void CancelAmountSelection();
    public void AmountSelected(int amountIndex);
    private void SetSelectedAmount(float amount);
    public static float GetAmountFromIndex(int index, bool depositing);
    private void UpdateAvailableAmounts();
    public void AmountConfirmed();
    public void ChangeAmount(float amount);
    protected IEnumerator ProcessTransaction(float amount, bool depositing);
    public void DoneButtonPressed();
    public void ReturnToMenuButtonPressed();
}