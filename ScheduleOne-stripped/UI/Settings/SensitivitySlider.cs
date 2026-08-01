using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.UI.Settings;
public class SensitivitySlider : SettingsSlider
{
    public enum ESensitivityType
    {
        Mouse,
        Gamepad
    }

    private const float Multiplier;
    [SerializeField]
    private ESensitivityType _sensitivityType;
    private float _sensitivity { get; set; }

    protected virtual void Start();
    protected override void OnValueChanged(float value);
}