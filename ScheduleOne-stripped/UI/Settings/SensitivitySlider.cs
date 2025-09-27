using ScheduleOne.DevUtilities;

namespace ScheduleOne.UI.Settings;
public class SensitivitySlider : SettingsSlider
{
    public const float MULTIPLIER;
    protected virtual void Start();
    protected override void OnValueChanged(float value);
}