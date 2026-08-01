using UnityEngine;

namespace ScheduleOne.Core.Utilities;
public static class GeometryUtility
{
    public static bool PointInsideCube(Vector3 point, Vector3 center, Vector3 halfExtents);
    public static bool PointInsideRectangle(Vector2 point, Vector2 center, Vector2 halfExtents);
    public static Vector2 ClosestPointOnSegment(Vector2 point, Vector2 a, Vector2 b);
    public static Vector3 ClosestPointOnSegment(Vector3 point, Vector3 a, Vector3 b);
    public static float GetNormalizedPositionAlongSegment(Vector2 a, Vector2 b, Vector2 c);
    public static float GetNormalizedPositionAlongSegment(Vector3 a, Vector3 b, Vector3 c);
    public static Plane CreatePlaneFromPoints(Vector3 p1, Vector3 p2, Vector3 p3);
    public static Vector3 ClosestPointOnPlane(in Plane plane, in Vector3 point);
    public static Vector3 ClosestPointOnPlane(in Vector3 normal, float distance, in Vector3 point);
    public static Vector3 ClosestPointOnQuad(Vector3 point, Vector3 origin, Vector3 axisU, Vector3 axisV, float halfU, float halfV);
}