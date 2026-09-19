using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Product;
using ScheduleOne.State;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.SpecialCustomers.UI;
public class IncomingSpecialCustomerInfoPopup : MonoBehaviour, ISleepEvent
{
    private const float SliderLerpDuration;
    [Header("References")]
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private GameObject _container;
    [SerializeField]
    private Button _continueButton;
    [SerializeField]
    private Animation _animation;
    [SerializeField]
    private AnimationClip _openAnimationClip;
    [SerializeField]
    private AnimationClip _closeAnimationClip;
    [SerializeField]
    private MonoState _state;
    [SerializeField]
    private TextMeshProUGUI _titleLabel;
    [SerializeField]
    private Slider _progressSlider;
    [SerializeField]
    private Image _sliderFillImage;
    [SerializeField]
    private Image _groupIconImage;
    [SerializeField]
    private TextMeshProUGUI[] _drugTypeLabels;
    private SpecialCustomerData _incomingGroupData;
    private int _daysUntilArrival;
    public bool IsInProgress { get; private set; }
    public int EventOrder { get; private set; } = 20;

    private void Awake();
    private void Start();
    private void OnDestroy();
    private void OnSpecialCustomersPhaseUpdate(string groupId, SpecialCustomerPhase phase, int daysLeftInPhase);
    public void StartEvent();
    private void Open();
    private IEnumerator LerpSlider(float startValue, float endValue, float duration);
    private void Close();
}