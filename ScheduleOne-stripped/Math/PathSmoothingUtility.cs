using System.Collections.Generic;
using System.Linq;
using FluffyUnderware.Curvy;
using UnityEngine;

namespace ScheduleOne.Math;
public class PathSmoothingUtility : MonoBehaviour
{
    public class SmoothedPath
    {
        public const float MARGIN;
        public List<Vector3> vectorPath;
        public List<Bounds> segmentBounds;
        public void InitializePath();
    }

    public const float MinControlPointDistance;
    private static CurvySpline spline;
    private void Awake();
    public static SmoothedPath CalculateSmoothedPath(List<Vector3> controlPoints, float maxCPDistance = 5f);
    public static void DrawPath(SmoothedPath path, Color col, float duration);
    private static List<Vector3> InsertIntermediatePoints(List<Vector3> points, float maxDistance);
}