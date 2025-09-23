using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class TrashData : SaveData
{
    public TrashItemData[] Items;
    public TrashGeneratorData[] Generators;
    public TrashData(TrashItemData[] trash, TrashGeneratorData[] generators);
}