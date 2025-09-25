using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class GenericSaveablesData : SaveData
{
    public GenericSaveData[] Saveables;
    public GenericSaveablesData(GenericSaveData[] saveables);
}