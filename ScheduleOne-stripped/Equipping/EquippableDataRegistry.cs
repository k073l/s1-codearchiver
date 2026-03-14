using System;
using System.Collections.Generic;
using ScheduleOne.Core;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class EquippableDataRegistry : PersistentSingleton<EquippableDataRegistry>
{
    [ReadOnly]
    [SerializeField]
    private List<EquippableData> _equippableDataList;
    public EquippableData GetEquippableData(Guid guid);
    private void RegisterEquippableData(EquippableData data);
}