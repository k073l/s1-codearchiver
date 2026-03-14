using Beautify.Universal;
using CorgiGodRays;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tools;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.FX;
public class PostProcessingManager : Singleton<PostProcessingManager>
{
    [Header("References")]
    public UniversalRendererData rendererData;
    public Volume GlobalVolume;
    [Header("Vignette")]
    public float Vig_DefaultIntensity;
    public float Vig_DefaultSmoothness;
    [Header("Blur")]
    public float MinBlur;
    public float MaxBlur;
    [Header("Post exposre")]
    public AnimationCurve PostExposureCurve;
    public float PostExposureMultiplier;
    [Header("Smoothers")]
    public FloatSmoother ChromaticAberrationController;
    public FloatSmoother SaturationController;
    public FloatSmoother BloomController;
    public HDRColorSmoother ColorFilterController;
    private Vignette vig;
    private DepthOfField DoF;
    private GodRaysVolume GodRays;
    private ColorAdjustments ColorAdjustments;
    private Beautify beautifySettings;
    private Bloom bloom;
    private ChromaticAberration chromaticAberration;
    private ColorAdjustments colorAdjustments;
    private PsychedelicFullScreenFeature _psychedelicFullScreenFeature;
    protected override void Awake();
    public void Update();
    protected override void OnDestroy();
    private void UpdateEffects();
    public void OverrideVignette(float intensity, float smoothness);
    public void ResetVignette();
    public void SetGodRayIntensity(float intensity);
    public void SetContrast(float value);
    public void SetSaturation(float value);
    public void SetBloomThreshold(float threshold);
    public void SetBlur(float blurLevel);
    public void SetPsychedelicEffectActive(bool isActive);
    public void SetPsychedelicEffectProperties(PsychedelicFullScreenData data);
    public void SetPsychedelicEffectProperties(PsychedelicFullScreenFeature.MaterialProperties properties);
    public PsychedelicFullScreenFeature.MaterialProperties GetActivePsychedelicEffectProperties();
    public PsychedelicFullScreenData GetPsychedelicEffectDataPreset(string presetName);
    public void PrintValueOfPsychedelicEffectBlend();
}