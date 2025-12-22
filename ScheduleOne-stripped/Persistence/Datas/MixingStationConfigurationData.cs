using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class MixingStationConfigurationData : RenamableConfigurationData
{
    public ObjectFieldData Destination;
    public NumberFieldData Threshold;
    public MixingStationConfigurationData(StringFieldData name, ObjectFieldData destination, NumberFieldData threshold);
}