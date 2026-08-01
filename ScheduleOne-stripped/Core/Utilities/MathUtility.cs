using UnityEngine;

namespace ScheduleOne.Core.Utilities;
public static class MathUtility
{
    public static bool BetweenValues(float value, float min, float max, bool maxInclusive = false, bool minInclusive = false);
    public static float Normalise(float value, float min, float max);
    public static float SqrDistance(Vector3 a, Vector3 b);
    public static float InverseDistance01(Vector3 a, Vector3 b, float minDist, float maxDist);
    public static float InverseDistance01(float sqrDist, float minDist, float maxDist);
    public static bool NearlyEqual(float a, float b, float tolerance);
    public static float LogLerp(float a, float b, float t);
}