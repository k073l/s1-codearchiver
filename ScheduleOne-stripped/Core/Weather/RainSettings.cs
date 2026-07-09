using System;
using UnityEngine;

namespace ScheduleOne.Core.Weather;
[Serializable]
public class RainSettings : WeatherSettings
{
    public float RainStrength;
    public float RainSize;
    public Color RainColour;
}