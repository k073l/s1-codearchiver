using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ScheduleOne.CustomUI;
public class UISliderTrigger : UITrigger
{
    public enum ESliderDirection
    {
        Horizontal,
        Vertical
    }

    private const float Deadzone;
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private ESliderDirection _sliderDirection;
    [SerializeField]
    private float _sliderSpeed;
    protected override void Awake();
    internal override void DetectTriggerInput(InputActionReference inputAction);
}