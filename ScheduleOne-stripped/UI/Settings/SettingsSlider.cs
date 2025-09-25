using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Settings;
public class SettingsSlider : MonoBehaviour
{
    private const float VALUE_DISPLAY_TIME;
    public bool DisplayValue;
    protected Slider slider;
    protected TextMeshProUGUI valueLabel;
    protected float timeOnValueChange;
    protected virtual void Awake();
    protected virtual void Update();
    protected virtual void OnValueChanged(float value);
    protected virtual string GetDisplayValue(float value);
}