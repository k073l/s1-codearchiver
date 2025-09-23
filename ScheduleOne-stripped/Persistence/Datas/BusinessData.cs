using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class BusinessData : PropertyData
{
    public LaunderOperationData[] LaunderingOperations;
    public BusinessData(string propertyCode, bool isOwned, bool[] switchStates, bool[] toggleableStates, DynamicSaveData[] employees, DynamicSaveData[] objects, LaunderOperationData[] launderingOperations);
}