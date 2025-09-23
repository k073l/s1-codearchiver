using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.Management;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Persistence.Loaders;
public class LegacyPackagerLoader : LegacyEmployeeLoader
{
    public override string NPCType => typeof(PackagerData).Name;

    public override void Load(string mainPath);
}