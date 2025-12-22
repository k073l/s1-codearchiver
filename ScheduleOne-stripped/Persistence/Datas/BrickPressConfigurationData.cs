using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class BrickPressConfigurationData : RenamableConfigurationData
{
    public ObjectFieldData Destination;
    public BrickPressConfigurationData(StringFieldData name, ObjectFieldData destination);
}