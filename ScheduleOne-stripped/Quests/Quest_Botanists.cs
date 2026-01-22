using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.Quests;
public class Quest_Botanists : Quest_Employees
{
    public QuestEntry AssignSuppliesEntry;
    public QuestEntry AssignWorkEntry;
    public QuestEntry AssignDestinationEntry;
    protected override void OnMinPass();
    public override List<Employee> GetEmployees();
}