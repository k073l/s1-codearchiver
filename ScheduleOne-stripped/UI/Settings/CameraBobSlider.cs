using ScheduleOne.DevUtilities;
using ScheduleOne.UI.MainMenu;
using UnityEngine;

namespace ScheduleOne.UI.Settings;
public class CameraBobSlider : SettingsSlider
{
    protected virtual void Start();
    protected override void OnValueChanged(float value);
}