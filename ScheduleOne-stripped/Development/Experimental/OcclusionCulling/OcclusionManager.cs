using System.Collections.Generic;
using System.Diagnostics;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Development.Experimental.OcclusionCulling;
public class OcclusionManager : Singleton<OcclusionManager>
{
    [Header("Settings")]
    [SerializeField]
    private Vector3 Bounds;
    [SerializeField]
    private float _cellSize;
    [SerializeField]
    private float _maxDistance;
    [SerializeField]
    private float _visibilityThreshold;
    [Header("Data")]
    [SerializeField]
    private OcclusionData _occlusionDataAsset;
    [Header("References")]
    [SerializeField]
    private List<Collider> _inclusionZones;
    [Header("Objects")]
    [SerializeField]
    private List<OcclusionObject> _occlusionObjects;
    [Header("Raycasting")]
    [SerializeField]
    private LayerMask _occlusionLayerMask;
    [SerializeField]
    private LayerMask _treeLayerMask;
    [Header("Gizmos")]
    [SerializeField]
    private bool _debugDrawGizmos;
    [SerializeField]
    private bool _debugDrawCells;
    [SerializeField]
    private Color _boundsColor;
    [SerializeField]
    private Color _inclusionZoneColor;
    [SerializeField]
    private Color _cellColor;
    [Header("Debugging")]
    [SerializeField]
    private bool _debugDrawRays;
    [SerializeField]
    private Transform _cellLocation;
    [SerializeField]
    private bool _showCellStateForSpecifiedObject;
    [SerializeField]
    private int _debugSpecifiedObjectIndex;
    [SerializeField]
    private float _debugSphereSize;
    private Coroutine _bakeRoutine;
    private Stopwatch _stopwatch;
    private int _debugCellCount;
    private int _debugRayCount;
    private int _treeLayer;
    private bool _isActive;
    private RaycastHit[] hits;
    [Button("Run Occlusion Bake")]
    public void RunOcclusionBake();
    private void Update();
    public void SetActive(bool isActive);
    private void DoOcclusionBakeRoutine();
    private bool IsObjectVisible(Vector3 point, OcclusionObject obj);
    private bool IsObjectCornersVisible(Vector3 point, Vector3[] corners);
    private bool IsObjectFaceVisible(Vector3 cell, Vector3 origin, Vector3 normal, Vector3 axisU, Vector3 axisV, float sizeNormal, float sizeU, float sizeV, int N);
    private bool IsPointVisible(Vector3 p1, Vector3 p2);
    private Vector3Int WorldToCellIndex(Vector3 worldPos, Vector3 origin, Vector3 cellSize);
    private bool GetObjectVisiblityState(int dataIndex, int objectIndex);
    public void SetObjectStateBasedOnPosition(Vector3 worldPos);
    public bool GetStateAtWorldPosition(Vector3 worldPos, int objectIndex);
    public int WorldPositionToOcclusionIndex(Vector3 worldPos);
    [Button("Debug Cell Rays")]
    private void DebugCellRays();
    [Button("Calculate Cells")]
    private void CalculateCells();
    private void OnDrawGizmos();
    private void DebugSpecifiedObjectState();
    [Button("Check Occlusion Data")]
    public void CheckData();
}