using System.Collections.Generic;
using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.SpecialCustomers;
public class SpecialCustomerSaveData : SaveData
{
    public string GroupId;
    public SpecialCustomerPhase Phase;
    public int DaysLeftInPhase;
    public int RunningBudget;
    public float ChanceToAppear;
    public List<SpecialCustomerGroupSaveData> GroupData;
    public List<string> DesiredEffects;
    public SpecialCustomerSaveData(string groupId, SpecialCustomerPhase phase, int daysLeftInPhase, int runningBudget, float chanceToAppear, List<string> desiredEffects, List<SpecialCustomerGroupSaveData> groupData);
}