using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Platform;
using ScheduleOne.UI.MainMenu;
using UnityEngine;

namespace ScheduleOne.UI.Settings;
public class DisplayModeDropdown : SettingsDropdown
{
    private DisplaySettings.EDisplayMode[] displayModes => HardwarePlatformUtility.GetAvailableDisplayModes();

    protected virtual void OnEnable();
    protected virtual void OnDisable();
    protected override void OnValueChanged(int value);
    private void RegenerateOptions();
}