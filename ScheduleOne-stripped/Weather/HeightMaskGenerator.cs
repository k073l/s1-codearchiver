using System;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Weather;
public class HeightMaskGenerator : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private ComputeShader _maskShader;
    [Header("Settings")]
    [SerializeField]
    private float _size;
    [SerializeField]
    private int _resolution;
    [SerializeField]
    private Vector2 _minMaxHeight;
    [SerializeField]
    private LayerMask _heightmapLayerMask;
    [Header("Debugging & Development")]
    [SerializeField]
    private float _debugTileSize;
    [SerializeField]
    private RenderTexture _heightTexture;
    [SerializeField]
    private Material _debugMaterial;
    private int _kernal;
    private float _tileSize;
    private float _tileHalfSize;
    private Vector3 _origin;
    private ComputeBuffer _heightBuffer;
    public void InitialiseMaskMap();
    private void GenerateMaskMap();
    private void OnDestroy();
    [Button]
    private void GenerateHeightMapDebug();
    [Button]
    private void Dispose();
    private void OnDrawGizmos();
}