using System;
using ScheduleOne.DevUtilities;

namespace ScheduleOne.UI.Settings;
public class AntiAliasingDropdown : SettingsDropdown
{
    protected override void Awake();
    protected override void Start();
    protected override void OnValueChanged(int value);
}