using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pathfinding;
using ScheduleOne.DevUtilities;
using ScheduleOne.Math;
using UnityEngine;

namespace ScheduleOne.Vehicles.AI;
public class NavigationUtility
{
    public enum ENavigationCalculationResult
    {
        Success,
        Failed
    }

    public delegate void NavigationCalculationCallback(ENavigationCalculationResult result, PathSmoothingUtility.SmoothedPath path);
    public delegate void PathGroupEvent(PathGroup calculatedGroup);
    public const float ROAD_MULTIPLIER;
    public const float OFFROAD_MULTIPLIER;
    public static Coroutine CalculatePath(Vector3 startPosition, Vector3 destination, NavigationSettings navSettings, DriveFlags flags, Seeker generalSeeker, Seeker roadSeeker, NavigationCalculationCallback callback);
    private static void AdjustExitPoint(PathGroup group);
    private static void AdjustEntryPoint(PathGroup group);
    private static bool DoesCloseDistanceExist(List<Vector3> vectorList, Vector3 point, float thresholdDistance);
    private static IEnumerator GenerateNavigationGroup(Vector3 startPoint, Vector3 entryPoint, NodeLink exitLink, Vector3 exitPoint, Vector3 destination, Seeker generalSeeker, Seeker roadSeeker, PathGroupEvent callback);
    public static void DrawPath(PathGroup group, float duration = 10f);
    private static PathSmoothingUtility.SmoothedPath GetSmoothedPath(PathGroup group);
    public static Vector3 SampleVehicleGraph(Vector3 destination);
    public static Vector3 GetClosestPointOnFiniteLine(Vector3 point, Vector3 line_start, Vector3 line_end);
}