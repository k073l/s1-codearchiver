using System;
using UnityEngine;

namespace ScheduleOne.Weather;
[Serializable]
public class SkySettings
{
    [SerializeField]
    private DynamicGradient _skyUpperGradient;
    [SerializeField]
    private DynamicGradient _skyMiddleGradient;
    [SerializeField]
    private DynamicGradient _skyLowerGradient;
    [SerializeField]
    private DynamicGradient _cloudDensityGradient;
    [SerializeField]
    private DynamicGradient _cloudColorGradient;
    [SerializeField]
    private DynamicGradient _sunLightGradient;
    [SerializeField]
    private DynamicGradient _sunIntensityGradient;
    [SerializeField]
    private DynamicGradient _sunColorGradient;
    [SerializeField]
    private DynamicGradient _sunSizeGradient;
    [SerializeField]
    private DynamicGradient _moonLightGradient;
    [SerializeField]
    private DynamicGradient _moonIntensityGradient;
    [SerializeField]
    private DynamicGradient _moonColorGradient;
    [SerializeField]
    private DynamicGradient _moonSizeGradient;
    [SerializeField]
    private DynamicGradient _ambientSkyGradient;
    [SerializeField]
    private DynamicGradient _ambientEquatorGradient;
    [SerializeField]
    private DynamicGradient _ambientGroundGradient;
    [SerializeField]
    private DynamicGradient _fogColorGradient;
    [SerializeField]
    private DynamicGradient _fogDensityGradient;
    public Vector2 FogHeightFade;
    [SerializeField]
    private DynamicGradient _windIntensityGradient;
    public DynamicGradient SkyUpperGradient => _skyUpperGradient;
    public DynamicGradient SkyMiddleGradient => _skyMiddleGradient;
    public DynamicGradient SkyLowerGradient => _skyLowerGradient;
    public DynamicGradient CloudDensityGradient => _cloudDensityGradient;
    public DynamicGradient CloudColorGradient => _cloudColorGradient;
    public DynamicGradient SunLightColorGradient => _sunLightGradient;
    public DynamicGradient SunDiscColorGradient => _sunColorGradient;
    public DynamicGradient MoonLightColorGradient => _moonLightGradient;
    public DynamicGradient MoonDiscColorGradient => _moonColorGradient;
    public DynamicGradient SunIntensityGradient => _sunIntensityGradient;
    public DynamicGradient MoonIntensityGradient => _moonIntensityGradient;
    public DynamicGradient AmbientSkyGradient => _ambientSkyGradient;
    public DynamicGradient AmbientEquatorGradient => _ambientEquatorGradient;
    public DynamicGradient AmbientGroundGradient => _ambientGroundGradient;
    public DynamicGradient FogColorGradient => _fogColorGradient;
    public DynamicGradient FogDensityGradient => _fogDensityGradient;
    public DynamicGradient WindIntensityGradient => _windIntensityGradient;
    public DynamicGradient SunSizeGradient => _sunSizeGradient;
    public DynamicGradient MoonSizeGradient => _moonSizeGradient;

    public void Set(SkySettings settings);
}