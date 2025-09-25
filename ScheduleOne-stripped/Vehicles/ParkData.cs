using System;

namespace ScheduleOne.Vehicles;
[Serializable]
public class ParkData
{
    public Guid lotGUID;
    public int spotIndex;
    public EParkingAlignment alignment;
    public ParkData(Guid lotGUID, int spotIndex, EParkingAlignment alignment);
    public ParkData();
}