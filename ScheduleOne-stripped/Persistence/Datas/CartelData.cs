using System;
using ScheduleOne.Cartel;
using ScheduleOne.Map;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class CartelData : SaveData
{
    [Serializable]
    public class RegionIntDict : SerializableDictionary<EMapRegion, int>
    {
    }

    public ECartelStatus Status;
    public int HoursSinceStatusChange;
    public CartelInfluence.RegionInfluenceData[] RegionInfluence;
    public int HoursUntilNextGlobalActivity;
    public CartelRegionalActivityData[] RegionalActivityData;
    public CartelDealInfo ActiveCartelDeal;
    public int HoursUntilNextDealRequest;
    public CartelData(ECartelStatus status, int hoursSinceStatusChange, CartelInfluence.RegionInfluenceData[] regionInfluence, int hoursUntilNextGlobalActivity, CartelRegionalActivityData[] regionalActivityData, CartelDealInfo activeCartelDeal, int hoursUntilNextDealRequest);
}