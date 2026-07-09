using UnityEngine;

namespace ScheduleOne;
public static class RigidbodyExtensions
{
    public static TransformData GetWorldTransformData(this Rigidbody rb);
    public static void SetLocalTransformData(this Rigidbody rb, TransformData data, bool setScale = true);
    public static void SetWorldTransformData(this Rigidbody rb, TransformData data);
}