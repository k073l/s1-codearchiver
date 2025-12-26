using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class LabOvenConfigurationData : RenamableConfigurationData
{
    public ObjectFieldData Destination;
    public LabOvenConfigurationData(StringFieldData name, ObjectFieldData destination);
}