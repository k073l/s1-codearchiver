using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.Money;
using ScheduleOne.NPCs.Relation;
using ScheduleOne.Quests;
using ScheduleOne.UI.Relations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class DealCompletionPopup : Singleton<DealCompletionPopup>
{
    [Header("References")]
    public Canvas Canvas;
    public RectTransform Container;
    public CanvasGroup Group;
    public Animation Anim;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI PaymentLabel;
    public TextMeshProUGUI SatisfactionValueLabel;
    public RelationCircle RelationCircle;
    public TextMeshProUGUI RelationshipLabel;
    public Gradient SatisfactionGradient;
    public AudioSourceController SoundEffect;
    public TextMeshProUGUI[] BonusLabels;
    [Header("Animations")]
    [SerializeField]
    private Animation _animation;
    private Coroutine routine;
    private AnimationState _animationState;
    public bool IsPlaying { get; protected set; }

    protected override void Awake();
    public void PlayPopup(Customer customer, float satisfaction, float originalRelationshipDelta, float basePayment, List<Contract.BonusPayment> bonuses);
    private IEnumerator PlayPopupRoutine(Customer customer, float satisfaction, float originalRelationshipDelta, float basePayment, List<Contract.BonusPayment> bonuses);
    private void SetRelationshipLabel(float delta);
}