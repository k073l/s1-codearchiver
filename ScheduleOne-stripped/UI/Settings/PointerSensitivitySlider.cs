using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.UI.Settings;
public class PointerSensitivitySlider : SettingsSlider
{
    private const float MULTIPLIER;
    protected virtual void Start();
    protected override void OnValueChanged(float value);
    private float MapSensitivity(float value);
    private float InverseMapSensitivity(float sensitivity);
}