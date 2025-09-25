using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class VehicleCollectionData : SaveData
{
    public VehicleData[] Vehicles;
    public VehicleCollectionData(VehicleData[] vehicles);
}