using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI.MainMenu;
using UnityEngine;

namespace ScheduleOne.UI.Settings;
public class ResolutionDropdown : SettingsDropdown
{
    protected virtual void OnEnable();
    protected virtual void OnDisable();
    protected override void OnValueChanged(int value);
    private void RegenerateOptions();
}