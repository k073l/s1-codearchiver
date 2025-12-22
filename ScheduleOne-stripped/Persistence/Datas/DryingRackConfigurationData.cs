using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class DryingRackConfigurationData : RenamableConfigurationData
{
    public QualityFieldData TargetQuality;
    public ObjectFieldData Destination;
    public DryingRackConfigurationData(StringFieldData name, QualityFieldData targetquality, ObjectFieldData destination);
}