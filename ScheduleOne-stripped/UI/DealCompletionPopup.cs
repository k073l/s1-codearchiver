using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.Money;
using ScheduleOne.NPCs.Relation;
using ScheduleOne.Quests;
using ScheduleOne.SpecialCustomers;
using ScheduleOne.UI.Relations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class DealCompletionPopup : Singleton<DealCompletionPopup>
{
    private const float SCPaymentDisplayDelay;
    private const float SCPaymentDisplayDuration;
    [Header("References")]
    [SerializeField]
    private Canvas _canvas;
    [Header("Standard Deal")]
    public Animation StandardDealAnimation;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI PaymentLabel;
    public TextMeshProUGUI SatisfactionValueLabel;
    public RelationCircle RelationCircle;
    public TextMeshProUGUI RelationshipLabel;
    public Gradient SatisfactionGradient;
    public AudioSourceController SoundEffect;
    public TextMeshProUGUI[] BonusLabels;
    [Header("Special Customers Deal")]
    [SerializeField]
    private Animation _specialCustomerDealAnimation;
    [SerializeField]
    private TextMeshProUGUI _specialCustomerDealTitle;
    [SerializeField]
    private TextMeshProUGUI _specialCustomerDealPaymentLabel;
    [SerializeField]
    private AudioSourceController _specialCustomerCashSound;
    [SerializeField]
    private AudioSourceController _specialCustomerDealSoundEffectSource;
    private Coroutine _activePopupRoutine;
    public bool IsPlaying { get; protected set; }

    protected override void Awake();
    protected override void Start();
    protected override void OnDestroy();
    [Button]
    private void Test();
    private void ResetEverything();
    private void Begin();
    private void End();
    public void PlayPopup(Customer customer, float satisfaction, float originalRelationshipDelta, float basePayment, List<Contract.BonusPayment> bonuses);
    private void SetRelationshipLabel(float delta);
    private void PlaySpecialCustomerPopup(SpecialCustomerDealReceipt receipt);
}