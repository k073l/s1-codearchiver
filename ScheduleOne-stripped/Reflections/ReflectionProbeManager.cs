using System;
using System.Collections.Generic;
using ScheduleOne.Core.Weather;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Weather;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace ScheduleOne.Reflections;
public class ReflectionProbeManager : MonoBehaviour
{
    [Serializable]
    public class WeatherProbe
    {
        public WeatherProfile Profile;
        public List<ProbeItem> Probes;
    }

    [Serializable]
    public class ProbeItem
    {
        public int TimeOfDay;
        public Cubemap Probe;
    }

    [Header("Weather Probes")]
    [SerializeField]
    private ReflectionProbe _probe;
    [SerializeField]
    private ComputeShader _shader;
    [SerializeField]
    private Cubemap _defaultMap;
    [SerializeField]
    private List<WeatherProbe> WeatherProbes;
    [Header("Debugging & Development: Blending")]
    private RenderTexture _stagingArray;
    private RenderTexture _blendedCube;
    private int _kernal;
    private Cubemap[] _cubemaps;
    private float _timeBlend;
    public ReflectionProbe ReflectionProbe => _probe;

    private void Start();
    public void Update();
    public void UpdateProbes();
    private void SetCubemaps(string activeProfile, string neighbourProfile);
    private int GetWrappedIndex(int index, int length);
    private int GetOffset24HourTime(int time, int offset);
    private void OnDestroy();
}