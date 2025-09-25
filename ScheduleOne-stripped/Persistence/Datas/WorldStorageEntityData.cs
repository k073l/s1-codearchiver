using System;
using ScheduleOne.GameTime;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class WorldStorageEntityData : SaveData
{
    public string GUID;
    public ItemSet Contents;
    public GameDateTime LastContentChangeTime;
    public WorldStorageEntityData(Guid guid, ItemSet contents, GameDateTime lastContentChangeTime);
}