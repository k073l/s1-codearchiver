using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne;
public class UISlider : UIOption
{
    [SerializeField]
    private bool canUpdateValueText;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float stepSize;
    [SerializeField]
    private TextMeshProUGUI valueText;
    public UnityEvent<float> OnChanged;
    protected override void Awake();
    protected override void OnUpdate();
    protected override void MoveLeft();
    protected override void MoveRight();
    private void UpdateSliderChanged();
    private void UpdateText();
}