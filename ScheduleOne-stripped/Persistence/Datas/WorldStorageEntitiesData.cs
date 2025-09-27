using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class WorldStorageEntitiesData : SaveData
{
    public WorldStorageEntityData[] Entities;
    public WorldStorageEntitiesData(WorldStorageEntityData[] entities);
}