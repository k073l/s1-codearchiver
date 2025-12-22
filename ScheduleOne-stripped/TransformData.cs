using UnityEngine;

namespace ScheduleOne;
public struct TransformData
{
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Scale;
    public TransformData(Vector3 position, Quaternion rotation, Vector3 scale);
    public void ApplyToWorldTransform(Transform transform);
    public void ApplyToLocalTransform(Transform transform, bool setScale = true);
    public static TransformData FromTransform(Transform transform);
    public static TransformData Lerp(TransformData a, TransformData b, float t);
}