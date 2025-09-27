using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class VariableCollectionData : SaveData
{
    public VariableData[] Variables;
    public VariableCollectionData(VariableData[] variables);
}