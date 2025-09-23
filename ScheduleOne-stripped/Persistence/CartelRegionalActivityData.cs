using System;
using ScheduleOne.Map;

namespace ScheduleOne.Persistence;
[Serializable]
public class CartelRegionalActivityData
{
    public EMapRegion Region;
    public int CurrentActivityIndex;
    public int HoursUntilNextActivity;
    public CartelRegionalActivityData(EMapRegion region, int currentActivityIndex, int hoursUntilNextActivity);
}