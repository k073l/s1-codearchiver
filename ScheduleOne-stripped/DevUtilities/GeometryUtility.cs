using UnityEngine;

namespace ScheduleOne.DevUtilities;
public static class GeometryUtility
{
    public static bool TryGetIntersection(Vector2 p0, Vector2 d1, Vector2 q0, Vector2 d2, out Vector2 intersection, out float t);
    public static bool TryRayLineIntersection(Vector2 p0, Vector2 d1, Vector2 r0, Vector2 d2, out Vector2 intersection, out float t);
    public static bool LineIntersection(Vector2 p, Vector2 r, Vector2 a, Vector2 b, out float t, out float u);
    public static float Cross(Vector2 a, Vector2 b);
}