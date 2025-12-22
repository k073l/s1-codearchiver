using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.FX;
public class PsychedelicFullScreenFeature : ScriptableRendererFeature
{
    [Serializable]
    public class Settings
    {
        public string profilerTag;
        public RenderPassEvent renderPassEvent;
        public Material passMaterial;
        [Header("Active Properties")]
        public MaterialProperties ActiveProperties;
        [Header("Presets")]
        public List<MaterialPropertyPreset> MaterialPresets;
    }

    [Serializable]
    public class MaterialPropertyPreset
    {
        public string Name;
        public PsychedelicFullScreenData Data;
    }

    [Serializable]
    public class MaterialProperties
    {
        public float NoiseScale;
        public float Blend;
        public Vector2 PanSpeed;
        public bool DoesBounce;
        public float Amplitude;
        public MaterialProperties Clone();
    }

    [Header("Settings")]
    [SerializeField]
    private Settings _settings;
    private static readonly int BLEND_ID;
    private static readonly int NOISE_SCALE_ID;
    private static readonly int PAN_SPEED_ID;
    private static readonly int DOES_BOUNCE_ID;
    private static readonly int AMPLITUDE_ID;
    private PsychedelicFullScreenPass _psychedelicPass;
    public Settings FeatureSettings => _settings;
    public MaterialProperties ActiveMaterialProperties => _settings.ActiveProperties;

    public override void Create();
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData);
    public void SetActiveMaterialProperties(MaterialProperties properties);
    public void PrintMaterialValue();
    public PsychedelicFullScreenData GetMaterialPreset(string presetName);
}