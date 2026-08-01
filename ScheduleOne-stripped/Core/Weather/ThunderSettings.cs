using System;
using UnityEngine;

namespace ScheduleOne.Core.Weather;
[Serializable]
public class ThunderSettings : WeatherSettings
{
    public float MaxThunderDelay;
    public Vector2 TimeBetweenThunders;
    public float ChanceForLightningStrike;
    public float ChanceForLightningStrikeToHitPlayer;
    public float ChanceForLightningStrikeToHitNPC;
}