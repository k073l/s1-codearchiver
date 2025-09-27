using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Property;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class LegacyEmployeeLoader : LegacyNPCLoader
{
    public override string NPCType => typeof(EmployeeData).Name;

    public Employee LoadAndCreateEmployee(string mainPath);
}