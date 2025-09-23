using System;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class PackagerData : EmployeeData
{
    public MoveItemData MoveItemData;
    public PackagerData(string id, string assignedProperty, string firstName, string lastName, bool male, int appearanceIndex, Vector3 position, Quaternion rotation, Guid guid, bool paidForToday, MoveItemData moveItemData);
}