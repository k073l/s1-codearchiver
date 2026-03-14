using System;

namespace ScheduleOne.Weather;
[Serializable]
public struct DayNightPhaseTimes
{
    public int MinDawnHour;
    public int SunRiseHour;
    public int MaxDawnHour;
    public int MinDuskHour;
    public int SunSetHour;
    public int MaxDuskHour;
}