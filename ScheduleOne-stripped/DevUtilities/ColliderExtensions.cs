using UnityEngine;

namespace ScheduleOne.DevUtilities;
public static class ColliderExtensions
{
    public static bool IsPointWithinCollider(this BoxCollider collider, Vector3 point);
}