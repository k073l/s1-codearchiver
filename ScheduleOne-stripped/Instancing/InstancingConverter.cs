using System;
using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.Instancing;
public class InstancingConverter : MonoBehaviour
{
    [Header("Instancing Creator")]
    [SerializeField]
    private ComputeShader _shader;
    [SerializeField]
    private InstanceObjectData _data;
    [SerializeField]
    private Transform _objContainer;
    [SerializeField]
    private InstanceWorldObject _objectPrefab;
    [Button]
    public void CreateInstanceMeshes();
}