using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScheduleOne.Instancing;
public class InstancingManager : Singleton<InstancingManager>
{
    private class InstanceBuffer
    {
        public ComputeBuffer Buffer;
        public ComputeBuffer Args;
        public Mesh Mesh;
        public Material Material;
        public InstanceBuffer(int maxInstances, Mesh mesh, Material material);
    }

    [Header("Baked Data")]
    [SerializeField]
    private List<InstanceObjectData> BackedInstanceObjects;
    [Header("References")]
    [SerializeField]
    private ComputeShader _instancingShader;
    [Header("Settings")]
    [SerializeField]
    private bool _drawInstancedObjects;
    [SerializeField]
    [Tooltip("Rough radius of the mesh for frustum culling to prevent popping.")]
    private float _boundsRadius;
    private InstanceBuffer[] _instanceBuffers;
    private int _kernelID;
    private Camera _mainCamera;
    private Vector4[] _frustumPlanes;
    private float _lodBias;
    protected override void Start();
    private void Update();
    private void UpdateAndDrawInstances();
    protected override void OnDestroy();
    private void ReleaseBuffer(ref ComputeBuffer buffer);
    public void EnableInstancing();
    public void DisableInstancing();
    public bool TryAssignCamera();
    private void UpdateQualitySettings();
}