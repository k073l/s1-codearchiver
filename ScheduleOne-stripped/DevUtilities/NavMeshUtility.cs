using System.Collections.Generic;
using ScheduleOne.EntityFramework;
using ScheduleOne.Management;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence;
using UnityEngine;
using UnityEngine.AI;

namespace ScheduleOne.DevUtilities;
public static class NavMeshUtility
{
    public const float SAMPLE_MAX_DISTANCE;
    public const float SAMPLE_CACHE_MAX_DIST;
    public const float SAMPLE_CACHE_MAX_SQR_DIST;
    public const float MAX_CACHE_SIZE;
    public static Dictionary<Vector3, Vector3> SampleCache;
    public static List<Vector3> sampleCacheKeys;
    public static float GetPathLength(NavMeshPath path);
    public static Transform GetReachableAccessPoint(ITransitEntity entity, NPC npc);
    public static bool IsAtTransitEntity(ITransitEntity entity, NPC npc, float distanceThreshold = 0.4f);
    public static int GetNavMeshAgentID(string name);
    public static bool SamplePosition(Vector3 sourcePosition, out NavMeshHit hit, float maxDistance, int areaMask, bool useCache = true);
    private static void CacheSampleResult(Vector3 sourcePosition, Vector3 hitPosition);
    private static Vector3 Quantize(Vector3 position, float precision = 0.1f);
    public static void ClearCache();
}