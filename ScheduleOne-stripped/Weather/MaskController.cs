using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Core;
using ScheduleOne.Core.Weather;
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
    private RenderTexture _maskRenderTexture;
    [SerializeField]
    private Texture2D _heightMask;
    [SerializeField]
    private int _downsampledResolution;
    [SerializeField]
    private Vector2 _minMaxHeight;
    [Header("Mask Map Modifications")]
    [SerializeField]
    private ComputeShader _maskModificationShader;
    [SerializeField]
    private List<MaskModificationData> _modifications;
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
    private int _modificationKernel;
    [SerializeField]
    private Texture2DArray _modificationTextureArray;
    private int[] _modificationStates;
    private ComputeBuffer _modificationStatesBuffer;
    private ComputeBuffer _modificationDataBuffer;
    private const string ModificationPath;
    public Texture2D MaskTexture => _heightMask;
    public Vector2 MinMaxHeight => _minMaxHeight;
    public float WorldSize => _worldSize;
    public int HeightMapResolution => _downsampledResolution;
    public float[] HeightMap => _heightMap;

    public void Initialise(int weatherVolumeCount, float blendAmount, Vector3 weatherVolumeSize);
    public void RunWetMaskShader(List<WeatherVolume> weatherVolumes);
    public void UpdateMaskMap();
    public void ConvertHeightToArray();
    private IEnumerator DoHeightConversionRoutine();
    public Coroutine BuildTextureArrayAsync(Action onComplete = null);
    private IEnumerator BuildTextureArrayRoutine(Action onComplete);
    private static bool TryGetArrayParams(List<MaskModificationData> modifications, out int width, out int height, out TextureFormat format);
    private static bool TryCopySlice(Texture2DArray array, int index, MaskModificationData modification, int width, int height, TextureFormat format);
    public void SetModificationState(MaskModificationData modification, bool isActive);
    public void ApplyModifications();
    private bool HasActiveModifications();
    [Button]
    public void AddHippieModification();
    [Button]
    public void RemoveHippieModification();
    private void OnDestroy();
}