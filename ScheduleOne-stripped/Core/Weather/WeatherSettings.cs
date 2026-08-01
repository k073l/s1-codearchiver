using System;
using System.Collections.Generic;
using ScheduleOne.Core.Audio;
using ScheduleOne.Core.Effects;
using UnityEngine;

namespace ScheduleOne.Core.Weather;
[Serializable]
public class WeatherSettings
{
    public bool IsActive;
    public Vector2 MinMaxDistanceToPlayer;
    public AnimationCurve DistanceCurve;
    public AnimationCurve EnclosureCurve;
    public List<EffectSettings> EffectSettings;
    public List<AudioSettings> AudioSettings;
}