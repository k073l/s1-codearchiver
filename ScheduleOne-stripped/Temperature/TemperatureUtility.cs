using ScheduleOne.DevUtilities;
using ScheduleOne.Variables;
using UnityEngine;

namespace ScheduleOne.Temperature;
public static class TemperatureUtility
{
    public static bool TemperatureSystemEnabled { get; }

    public static float ToFahrenheit(float celsius);
    public static string FormatCelsiusTemperature(float celsius, int decimalPoints);
    public static string FormatFahrenheitTemperature(float fahrenheit, int decimalPoints);
    public static string FormatTemperatureWithAppropriateUnit(float celsius, int decimalPoints = 1);
    public static float NormalizeTemperature(float celsius);
}