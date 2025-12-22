using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class MushroomBedConfigurationData : RenamableConfigurationData
{
    public ItemFieldData Spawn;
    public ItemFieldData Additive1;
    public ItemFieldData Additive2;
    public ItemFieldData Additive3;
    public ObjectFieldData Destination;
    public MushroomBedConfigurationData(StringFieldData name, ItemFieldData spawn, ItemFieldData additive1, ItemFieldData additive2, ItemFieldData additive3, ObjectFieldData destination);
}