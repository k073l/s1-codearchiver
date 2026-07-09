using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.CustomUI;
public class UISelectable_Slider : UISelectable
{
    private const float DelayBeforeRepeat;
    private const float SlowestRepeatDelay;
    private const float FastestRepeatDelay;
    private const float VerticalMoveThreshold;
    private const float SliderMoveThreshold;
    private const float TimeToReachFastestRepeat;
    [SerializeField]
    private float _increment;
    [SerializeField]
    private bool _bigIncrements;
    [SerializeField]
    private float _bigIncrement;
    private bool _wasNavPressedLastFrame;
    private float _timeBeforeNextRepeat;
    private float _timeSinceNavStart;
    private Slider _slider;
    protected override void Awake();
    private void Update();
    protected virtual void DetectInput();
    public override void OnSelect(BaseEventData eventData);
    private void Increment(float amount);
}