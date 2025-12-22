using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class SpawnStationConfigurationData : RenamableConfigurationData
{
    public ObjectFieldData Destination;
    public SpawnStationConfigurationData(StringFieldData name, ObjectFieldData destination);
}