using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Settings;
public class SettingsSlider : MonoBehaviour
{
    public float ValueDisplayTime;
    public bool DisplayValue;
    protected Slider slider;
    [SerializeField]
    protected TextMeshProUGUI valueLabel;
    protected float timeOnValueChange;
    protected virtual void Awake();
    protected virtual void Update();
    protected virtual void OnValueChanged(float value);
    protected void SetDisplayValue(float value);
    protected void SetValueWithoutNotify(float value);
    protected virtual string GetDisplayValue(float value);
}