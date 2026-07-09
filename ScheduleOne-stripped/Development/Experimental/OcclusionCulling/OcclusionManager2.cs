using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace ScheduleOne.Development.Experimental.OcclusionCulling;
public class OcclusionManager2 : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private Vector3 _bounds;
    [SerializeField]
    private float _cellSize;
    [SerializeField]
    private float _maxDistance;
    [Header("References")]
    [SerializeField]
    private List<Collider> _inclusionZones;
    [SerializeField]
    private List<OcclusionObject> _occlusionObjects;
    [SerializeField]
    private LayerMask _occlusionLayerMask;
    private NativeArray<byte> _visibilityData;
    private int _cellsX;
    private int _cellsY;
    private int _cellsZ;
    private int _totalCells;
    private Coroutine _bakeRoutine;
    [ContextMenu("Run Occlusion Bake")]
    public void RunOcclusionBake();
    private IEnumerator DoOcclusionBakeRoutine();
    private void OnDestroy();
}