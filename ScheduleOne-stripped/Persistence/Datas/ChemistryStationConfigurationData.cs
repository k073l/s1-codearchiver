using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class ChemistryStationConfigurationData : RenamableConfigurationData
{
    public StationRecipeFieldData Recipe;
    public ObjectFieldData Destination;
    public ChemistryStationConfigurationData(StringFieldData name, StationRecipeFieldData recipe, ObjectFieldData destination);
}