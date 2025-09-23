using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class TrashGeneratorData : SaveData
{
    public string GUID;
    public string[] GeneratedItems;
    public TrashGeneratorData(string guid, string[] generatedItems);
}