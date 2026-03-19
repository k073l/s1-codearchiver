using ScheduleOne.Core.Settings.Framework;
using UnityEngine;

namespace ScheduleOne.Core.Settings;
[CreateAssetMenu(fileName = "EquipSettings", menuName = "ScheduleOne/Configurations/Settings/Equip Settings", order = -1)]
public class EquipSettings : ScheduleOne.Core.Settings.Framework.Settings
{
    public override SettingsObject[] GetSettingsObjects();
}