using System;
using System.Collections;
using ScheduleOne.Growing;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScheduleOne.Development;
public class DevTesting : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private ComputeShader _coverShader;
    public GrowContainer GrowContainer;
    public MeshRenderer MeshRenderer;
    [Header("Settings")]
    public float SuccessfulCoverageThreshold;
    [SerializeField]
    private bool _flipX;
    [SerializeField]
    private bool _flipZ;
    private const int TextureSize;
    private const int Radius;
    private const int Hardness;
    private const float Opacity;
    private const int UpdatesPerSecond;
    private const float CoveredPixelThreshold;
    private const float FixedScale;
    private int _resetCountKernel;
    private int _countKernel;
    private int _pourKernel;
    private int _clearKernel;
    private float _updateTimer;
    private bool _readbackPending;
    private bool _isActive;
    private float _activationDelay;
    private RenderTexture _coverTexture;
    private ComputeBuffer _coverageBuffer;
    private Coroutine _updateCo;
    private float _coverage;
    private float _applicationStrength;
    private Vector3 _worldPosition;
    public float ApplicationStrength { get; set; }

    private void Start();
    private void Setup();
    public void ConfigureAppearance(Color col, float transparency);
    public void UpdateFill();
    public void SetActive(bool isActive, float delay = 0f);
    public void SetFillPosition(Vector3 worldPosition);
    public void ResetCover();
    private void Fill();
    public void FillForDuration(float duration = 0.1f);
    private IEnumerator DoFillRoutine(float duration);
    private void ResetCoverageCount();
    private void RequestCoverage();
    private void OnCoverageReadback(AsyncGPUReadbackRequest request);
    private Vector2Int WorldToPixel(Vector3 worldPos);
    public float GetNormalizedProgress();
    private void OnDestroy();
}