using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScheduleOne.Weather;
public class MaskController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private ComputeShader _wetMaskShader;
    [SerializeField]
    private ComputeShader _maskDownsampleShader;
    [SerializeField]
    private RenderTexture _wetMaskTexture;
    [Header("General Settings")]
    [SerializeField]
    private int _worldSize;
    [Header("Wet Mask Settings")]
    [SerializeField]
    private int _wetMaskResolution;
    [SerializeField]
    private float _wetGrowthRate;
    [SerializeField]
    private float _wetDecayRate;
    [SerializeField]
    private float _sunEvapMultiplier;
    [SerializeField]
    private AnimationCurve _wetnessGrowthCurve;
    [Header("Height Settings")]
    [SerializeField]
    private Texture2D _heightMask;
    [SerializeField]
    private int _downsampledResolution;
    [SerializeField]
    private Vector2 _minMaxHeight;
    [Header("Debugging & Development")]
    [SerializeField]
    private RenderTexture _debugTexture;
    private Vector2[] _weatherVolumeOrigins;
    private float[] _weatherRainValues;
    private float[] _weatherSunValues;
    private ComputeBuffer _volumeOriginsBuffer;
    private ComputeBuffer _volumeRainBuffer;
    private ComputeBuffer _volumeSunBuffer;
    private Coroutine _heightConversionCo;
    private float[] _heightMap;
    public float WorldSize => _worldSize;
    public int HeightMapResolution => _downsampledResolution;
    public float[] HeightMap => _heightMap;
    public Vector2 MinMaxHeight => _minMaxHeight;

    public void Initialise(int weatherVolumeCount, float blendAmount, Vector3 weatherVolumeSize);
    public void RunWetMaskShader(List<WeatherVolume> weatherVolumes);
    public void ConvertHeightToArray();
    private IEnumerator DoHeightConversionRoutine();
    private void OnDestroy();
}