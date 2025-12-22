using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class PackagingStationConfigurationData : RenamableConfigurationData
{
    public ObjectFieldData Destination;
    public PackagingStationConfigurationData(StringFieldData name, ObjectFieldData destination);
}