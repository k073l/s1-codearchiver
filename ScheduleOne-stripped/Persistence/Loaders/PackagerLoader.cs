using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.Management;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Persistence.Loaders;
public class PackagerLoader : EmployeeLoader
{
    public override string NPCType => typeof(PackagerData).Name;

    public override void Load(DynamicSaveData saveData);
}