using System.Collections;
using System.IO;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Weather;
using UnityEngine;

namespace ScheduleOne.Experimental;
public class WorldPerformanceCapture : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Camera _captureCamera;
    [SerializeField]
    private Renderer _debugHeatmapRenderer;
    [Header("Settings")]
    [SerializeField]
    private Vector3 _captureSize;
    [SerializeField]
    private int _chunkSize;
    [SerializeField]
    private int _captureRotationAmount;
    [SerializeField]
    private float _timeBetweenFPSCapture;
    [Tooltip("The target resolution for the output heatmap texture.")]
    [SerializeField]
    private Vector2Int _targetTextureSize;
    [SerializeField]
    private bool _saveToPNG;
    [SerializeField]
    private bool _saveToJSON;
    [Header("Debug & Visualization")]
    [SerializeField]
    private bool _debugShowChunks;
    [SerializeField]
    private bool _showLoadedDataGizmos;
    [Tooltip("Drag the generated JSON file here to visualize the captured data in the scene.")]
    [SerializeField]
    private TextAsset _performanceDataAsset;
    [Header("Output")]
    public Texture2D FpsHeatmapTexture;
    private int _currentChunkSize;
    private int _currentCaptureRotationAmount;
    private float _currentTimeBetweenFPSCapture;
    private int _chunkAmountX;
    private int _chunkAmountY;
    private int _pixelsPerChunkX;
    private int _pixelsPerChunkY;
    private float[] _captureData;
    private float _customDeltaTime;
    private float _fps;
    private TextAsset _lastLoadedAsset;
    private PerformanceDataSave _loadedData;
    private void Start();
    private void Update();
    public void Set(int chunkSize, int captureRotationAmount, float timeBetweenFPSCapture);
    [Button]
    public void Capture();
    public void Capture(int chunkSize, int captureRotationAmount, float timeBetweenFPSCapture);
    private IEnumerator DoCaptureRoutine();
    private void SaveTextureToPNG();
    private void SaveDataToJson(Vector2 minMaxFps, Vector3 startPos);
    private void OnDrawGizmos();
    private void DrawLoadedDataGizmos();
    [Button]
    public void TestCameraChange();
}