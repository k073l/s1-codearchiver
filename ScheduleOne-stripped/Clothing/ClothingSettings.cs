using ScheduleOne.Core.Settings.Framework;
using UnityEngine;

namespace ScheduleOne.Clothing;
[CreateAssetMenu(fileName = "ClothingSettings", menuName = "ScheduleOne/Configurations/Settings/Clothing Settings", order = -1)]
public class ClothingSettings : Settings
{
    public override SettingsObject[] GetSettingsObjects();
}