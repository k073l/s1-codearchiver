using System.Collections.Generic;
using System.Linq;
using FluffyUnderware.Curvy;
using UnityEngine;

namespace ScheduleOne.Math;
public static class PathSmoothingUtility
{
    public class SmoothedPath
    {
        public const float MARGIN;
        public List<Vector3> vectorPath;
        public List<Bounds> segmentBounds;
        public void InitializePath();
    }

    private const float MinControlPointDistance;
    private static CurvySpline _spline;
    private static void EnsureSplineInitialized();
    public static SmoothedPath CalculateSmoothedPath(List<Vector3> controlPoints, float maxCPDistance = 5f);
    private static void DrawPath(SmoothedPath path, Color col, float duration);
    private static List<Vector3> InsertIntermediatePoints(List<Vector3> points, float maxDistance);
}