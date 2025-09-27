using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.Management;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Persistence.Loaders;
public class LegacyCleanerLoader : LegacyEmployeeLoader
{
    public override string NPCType => typeof(CleanerData).Name;

    public override void Load(string mainPath);
}