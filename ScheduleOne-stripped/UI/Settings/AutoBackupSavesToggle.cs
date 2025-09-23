using ScheduleOne.DevUtilities;

namespace ScheduleOne.UI.Settings;
public class AutoBackupSavesToggle : SettingsToggle
{
    protected virtual void Start();
    protected override void OnValueChanged(bool value);
}