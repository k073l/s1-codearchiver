using Funly.SkyStudio;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Tools;
using UnityEngine;
using VolumetricFogAndMist2;

namespace ScheduleOne.FX;
[ExecuteInEditMode]
public class EnvironmentFX : Singleton<EnvironmentFX>
{
    [Header("References")]
    [SerializeField]
    protected WindZone windZone;
    [SerializeField]
    protected TimeOfDayController timeOfDayController;
    public VolumetricFog VolumetricFog;
    public Light SunLight;
    public Light MoonLight;
    [Header("Height Fog")]
    [SerializeField]
    protected Gradient HeightFogColor;
    [SerializeField]
    protected AnimationCurve HeightFogIntensityCurve;
    [SerializeField]
    protected float HeightFogIntensityMultiplier;
    [SerializeField]
    protected AnimationCurve HeightFogDirectionalIntensityCurve;
    [Header("Volumetric Fog")]
    [SerializeField]
    protected Gradient VolumetricFogColor;
    [SerializeField]
    protected AnimationCurve VolumetricFogIntensityCurve;
    [SerializeField]
    protected float VolumetricFogIntensityMultiplier;
    [Header("Fog")]
    [SerializeField]
    private float fogEndDistanceMultiplier;
    [Header("God rays")]
    [SerializeField]
    protected AnimationCurve godRayIntensityCurve;
    [Header("Contrast")]
    [SerializeField]
    protected AnimationCurve contrastCurve;
    [SerializeField]
    protected float contractMultiplier;
    [Header("Saturation")]
    [SerializeField]
    protected AnimationCurve saturationCurve;
    [SerializeField]
    protected float saturationMultiplier;
    [Header("Grass")]
    [SerializeField]
    protected Material grassMat;
    [SerializeField]
    protected Gradient grassColorGradient;
    [Header("Trees")]
    public Material distanceTreeMat;
    public AnimationCurve distanceTreeColorCurve;
    [Header("Stealth settings")]
    public AnimationCurve environmentalBrightnessCurve;
    [Header("Bloom")]
    public AnimationCurve bloomThreshholdCurve;
    private bool started;
    public FloatSmoother FogEndDistanceController;
    public float normalizedEnvironmentalBrightness => environmentalBrightnessCurve.Evaluate(((float)NetworkSingleton<TimeManager>.Instance.DailyMinTotal + NetworkSingleton<TimeManager>.Instance.TimeOnCurrentMinute / 1f) / 1440f);
    public float FogEndDistanceMultiplier => fogEndDistanceMultiplier * FogEndDistanceController.CurrentValue;

    protected override void Start();
    private void Update();
    private void UpdateVisuals();
    protected override void OnDestroy();
}