using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Weather;
[CreateAssetMenu(fileName = "WeatherProbeData", menuName = "ScriptableObjects/Weather/Weather Probe")]
public class WeatherProbe : ScriptableObject
{
    [Serializable]
    public class ProbeItem
    {
        public int TimeOfDay;
        public Cubemap Cubemap;
    }

    [Header("Weather Probes")]
    public List<ProbeItem> Probes;
}