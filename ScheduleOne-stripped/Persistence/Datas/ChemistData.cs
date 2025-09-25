using System;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class ChemistData : EmployeeData
{
    public MoveItemData MoveItemData;
    public ChemistData(string id, string assignedProperty, string firstName, string lastName, bool male, int appearanceIndex, Vector3 position, Quaternion rotation, Guid guid, bool paidForToday, MoveItemData moveItemData);
}