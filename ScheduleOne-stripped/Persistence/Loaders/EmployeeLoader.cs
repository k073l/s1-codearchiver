using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Property;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class EmployeeLoader : NPCLoader
{
    public override string NPCType => typeof(EmployeeData).Name;

    public override void Load(DynamicSaveData saveData);
    protected virtual Employee CreateAndLoadEmployee(DynamicSaveData saveData);
}