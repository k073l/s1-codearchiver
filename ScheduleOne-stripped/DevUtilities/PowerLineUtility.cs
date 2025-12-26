using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public class PowerLineUtility
{
    public static int MinSegmentCount;
    public static int MaxSegmentCount;
    public static int GetSegmentCount(Vector3 startPoint, Vector3 endPoint);
    public static void DrawPowerLine(Vector3 startPoint, Vector3 endPoint, List<Transform> segments, float lengthFactor);
    private static void PositionSegments(List<Vector3> points, List<Transform> segments);
    private static List<Vector3> GetCatenaryPoints(Vector3 startPoint, Vector3 endPoint, int pointCount, float l);
}