using ScheduleOne.DevUtilities;
using ScheduleOne.UI.MainMenu;
using UnityEngine;

namespace ScheduleOne.UI.Settings;
public class TargetFPSSlider : SettingsSlider
{
    protected virtual void OnEnable();
    protected override void OnValueChanged(float value);
}