using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class RenamableConfigurationData : SaveData
{
    public StringFieldData Name;
    public RenamableConfigurationData(StringFieldData name);
}