using System;
using ScheduleOne.Configuration;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.Core.Settings;
using UnityEngine;

namespace ScheduleOne.Equipping.Framework;
[CreateAssetMenu(fileName = "EquipConfiguration", menuName = "ScheduleOne/Configurations/EquipConfiguration", order = 1)]
public class EquipConfiguration : Configuration<EquipSettings>
{
    [SerializeField]
    public EquippedItemHandler[] Handlers;
    public bool TryGetHandlerForData(Type handlerType, out IEquippedItemHandler handler);
}