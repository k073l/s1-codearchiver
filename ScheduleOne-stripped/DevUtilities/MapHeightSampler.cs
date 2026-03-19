using ScheduleOne.GamePhysics;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public static class MapHeightSampler
{
    private const float SampleHeight;
    private const float SampleDistance;
    public static bool TrySample(float x, float z, out Vector3 hitPoint);
}