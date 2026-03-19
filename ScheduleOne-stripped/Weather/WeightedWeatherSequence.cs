using System;

namespace ScheduleOne.Weather;
[Serializable]
public class WeightedWeatherSequence
{
    public WeatherSequence Sequence;
    public float Weight;
}