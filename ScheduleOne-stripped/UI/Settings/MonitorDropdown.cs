using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI.MainMenu;
using UnityEngine;

namespace ScheduleOne.UI.Settings;
public class MonitorDropdown : SettingsDropdown
{
    protected override void Awake();
    protected virtual void OnEnable();
    protected virtual void OnDisable();
    protected override void OnValueChanged(int value);
    public static int GetCurrentDisplayNumber();
    private void SetCurrent();
}