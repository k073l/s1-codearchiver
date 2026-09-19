using System;
using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.SpecialCustomers;
[Serializable]
public class SpecialCustomerGroupSaveData
{
    public string GroupId;
    public int DaySinceLastVisit;
    public int VisitCount;
    public ItemSet GroupInventory;
    public SpecialCustomerGroupSaveData(string groupId, int daySinceLastVisit, int visitCount);
}