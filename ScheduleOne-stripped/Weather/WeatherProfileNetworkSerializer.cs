using FishNet.Serializing;
using ScheduleOne.Core.Weather;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Weather;
public static class WeatherProfileNetworkSerializer
{
    private const string Null;
    public static void WriteWeatherProfile(this Writer writer, WeatherProfile value);
    public static WeatherProfile ReadWeatherProfile(this Reader reader);
}