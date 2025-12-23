using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class PlantData : SaveData
{
    public string SeedID;
    public float GrowthProgress;
    public int[] ActiveBuds;
    public PlantData(string seedID, float growthProgress, int[] activeBuds);
}