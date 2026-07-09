using System.Collections.Generic;
using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.Development.Experimental.OcclusionCulling;
public class OcclusionObject : MonoBehaviour
{
    [Header("Cube Definition")]
    public Vector3 cubeSize;
    [Header("Faces")]
    [SerializeField]
    private bool _includeLeft;
    [SerializeField]
    private bool _includeRight;
    [SerializeField]
    private bool _includeTop;
    [SerializeField]
    private bool _includeBottom;
    [SerializeField]
    private bool _includeFront;
    [SerializeField]
    private bool _includeBack;
    [Header("References")]
    [SerializeField]
    private List<LODGroup> _lodGroups;
    [SerializeField]
    private List<MeshRenderer> _meshRenderers;
    [Header("Slicing")]
    [Range(0f, 5f)]
    [Tooltip("0 = 6 chunks, 1 = 24 chunks, 2 = 96 chunks")]
    public int subdivisions;
    [Header("Gizmo Display")]
    public float gizmoSphereRadius;
    public Color centerColor;
    public Color boundsColor;
    private bool _isActive;
    public Vector3 Size => cubeSize;
    public int Subdivisions => subdivisions;
    public bool IncludeLeft => _includeLeft;
    public bool IncludeRight => _includeRight;
    public bool IncludeTop => _includeTop;
    public bool IncludeBottom => _includeBottom;
    public bool IncludeFront => _includeFront;
    public bool IncludeBack => _includeBack;

    private void Start();
    private void OnDrawGizmos();
    private void DrawFaceChunks(Vector3 localNormal, Vector3 localAxisU, Vector3 localAxisV, float sizeNormal, float sizeU, float sizeV, int N);
    public Vector3[] GetCornerPositions();
    public int GetNumberOfVertices(int subdivisions);
    public void SetObjectOcclusion(bool isActive);
    private void SetActive(bool isActive);
    [Button]
    private void CalculateNumberOfVertices();
}