using System;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class WeatherBehaviour
{
    [Range(0f, 1f)]
    public float UseUmbrellaChance;
    [Range(0f, 1f)]
    public float RainTolerance;
    [Range(0f, 10f)]
    public float MaxWalkSpeedInRainMultiplier;
    public WeatherBehaviour GetCopy();
}