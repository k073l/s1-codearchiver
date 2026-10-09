using UnityEngine;

namespace ScheduleOne.Instancing;
public class InstanceWorldObject : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private MeshFilter _meshFilter;
    [SerializeField]
    private MeshRenderer _meshRenderer;
    [Header("Settings")]
    [SerializeField]
    private string _id;
    public string Id => _id;

    public void Set(string Id, Mesh mesh, Material material);
}