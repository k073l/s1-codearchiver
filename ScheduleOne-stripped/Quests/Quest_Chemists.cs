using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.Management;

namespace ScheduleOne.Quests;
public class Quest_Chemists : Quest_Employees
{
    public QuestEntry AssignWorkEntry;
    protected override void OnMinPass();
    public override List<Employee> GetEmployees();
}