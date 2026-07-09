using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI.MainMenu;
using UnityEngine;

namespace ScheduleOne.UI.Settings;
public class VSyncToggle : SettingsToggle
{
    protected virtual void OnEnable();
    protected virtual void OnDisable();
    protected override void OnValueChanged(bool value);
    private void Redraw();
}