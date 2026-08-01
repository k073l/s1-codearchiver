using System;

namespace ScheduleOne.Core.Weather;
[Serializable]
public class WeightedWeatherSequence
{
    public WeatherSequence Sequence;
    public float Weight;
}