using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.Items;
using ScheduleOne.Variables;
using ScheduleOne.VoiceOver;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class PawnShopInterface : Singleton<PawnShopInterface>
{
    public enum EState
    {
        WaitingForOffer,
        Negotiating
    }

    public enum EPlayerResponse
    {
        None,
        Accept,
        Counter,
        Cancel
    }

    public enum EShopResponse
    {
        Accept,
        Counter,
        Refusal
    }

    public const float PAYMENT_MIN;
    public const float PAYMENT_MAX;
    public const float THINK_TIME;
    public const float MIN_VALUE_MULTIPLIER;
    public const float MAX_VALUE_MULTIPLIER;
    public const int PAWN_SLOT_COUNT;
    private EState CurrentState;
    private EPlayerResponse PlayerResponse;
    private int CurrentNegotiationRound;
    private float InitialShopOffer;
    private float LastShopOffer;
    private float LastRefusedAmount;
    public NPC PawnShopNPC;
    public AnimationCurve RandomCurve;
    [Header("References")]
    public Canvas Canvas;
    public RectTransform Container;
    public ItemSlotUI[] Slots;
    public TextMeshProUGUI[] ValueRangeLabels;
    public TextMeshProUGUI TotalValueLabel;
    public Button StartButton;
    public Animation Step1Animation;
    public CanvasGroup Step1CanvasGroup;
    public Animation Step2Animation;
    public CanvasGroup Step2CanvasGroup;
    public AnimationClip FadeInAnim;
    public AnimationClip FadeOutAnim;
    public TMP_InputField OfferInputField;
    public Slider AngerSlider;
    public TextMeshProUGUI AcceptCounterButtonLabel;
    [Header("Settings")]
    public string[] OfferLines;
    public string[] ThinkLines;
    public string[] AcceptLines;
    public string[] CounterLines;
    public string[] RefusalLines;
    public string[] DealFinalizedLines;
    public string[] AngeredLines;
    public string[] CrashOutLines;
    private ItemSlot[] PawnSlots;
    private Coroutine routine;
    public bool IsOpen { get; private set; }
    public float SelectedPayment { get; private set; }
    public float NPCAnger { get; private set; }

    protected override void Awake();
    protected override void Start();
    protected override void OnDestroy();
    public void Open();
    public void Close(bool returnItemsToPlayer);
    private void Exit(ExitAction action);
    private void OnMinPass();
    private void OnDayPass();
    private void Update();
    private List<ItemInstance> GetPawnItems();
    private void PawnSlotChanged();
    private void UpdateValueRangeLabels();
    public void StartButtonPressed();
    private void StartNegotiation();
    private void PlayShopResponse(EShopResponse response, float counter);
    private EShopResponse EvaluateCounter(float lastShopOffer, float playerOffer, out float counterAmount, out float angerChange);
    private void EndNegotiation();
    public void PaymentSubmitted(string value);
    public void ChangePayment(float change);
    public void SetSelectedPayment(float amount);
    public void SetPlayerResponse(EPlayerResponse response);
    public void AcceptOrCounter();
    public void Cancel();
    private void ChangeAnger(float change);
    private void SetAngeredToday(bool angered);
    private void Think();
    private void SetOffer(float amount);
    private void FinalizeDeal(float amount);
    private float GetTotalValue();
    private float RoundOffer(float offer);
    private float GetItemValue(ItemInstance item);
    private void ResetUI();
}