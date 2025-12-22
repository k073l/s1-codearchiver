using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class CauldronConfigurationData : RenamableConfigurationData
{
    public ObjectFieldData Destination;
    public CauldronConfigurationData(StringFieldData name, ObjectFieldData destination);
}