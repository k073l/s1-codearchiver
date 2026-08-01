using UnityEngine;

namespace ScheduleOne.Instancing;
[CreateAssetMenu(fileName = "InstanceObjectData", menuName = "ScheduleOne/Instancing/Instanced Object Data", order = 1)]
public class InstanceObjectData : ScriptableObject
{
    public Mesh Mesh;
    public Material Material;
    public int TextureResolution;
    public int InstanceCount;
    public Vector3 PositionOffset;
    public Vector2Int MinMaxLodDistance;
    public Texture2D PositionData;
    public Texture2D RotationData;
}