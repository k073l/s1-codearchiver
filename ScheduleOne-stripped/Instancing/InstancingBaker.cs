using System.Collections.Generic;
using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.Instancing;
public class InstancingBaker : MonoBehaviour
{
    public class InstanceObjectBakeData
    {
        public Vector3 Position;
        public Vector4 Rotation;
        public float Scale;
    }

    [Header("References")]
    [SerializeField]
    private List<GameObject> _objects;
    [Header("Baking Settings")]
    [SerializeField]
    private int _textureResolution;
    [SerializeField]
    private string _fileName;
    [SerializeField]
    private Mesh _mesh;
    [SerializeField]
    private Material _material;
    private const string SAVE_PATH;
    [Button("Bake")]
    public void BakeGameObjects();
    public void Bake(List<InstanceObjectBakeData> bakingData);
}