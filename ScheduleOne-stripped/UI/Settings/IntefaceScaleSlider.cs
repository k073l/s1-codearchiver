using ScheduleOne.DevUtilities;
using ScheduleOne.UI.MainMenu;
using UnityEngine;

namespace ScheduleOne.UI.Settings;
public class IntefaceScaleSlider : SettingsSlider
{
    public const float MULTIPLIER;
    public const float MinScale;
    public const float MaxScale;
    protected virtual void OnEnable();
    protected override void OnValueChanged(float value);
    protected override string GetDisplayValue(float value);
}