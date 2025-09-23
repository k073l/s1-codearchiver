using System;
using System.Linq;
using UnityEngine;

namespace ScheduleOne.Audio;
public class Zone : MonoBehaviour
{
    public const float UPDATE_INTERVAL;
    public Transform PointContainer;
    public bool IsClosed;
    public float VerticalSize;
    [Header("Debug")]
    public Color ZoneColor;
    protected Vector3[] points;
    protected virtual void Awake();
    private void OnDrawGizmos();
    protected Vector3[] GetPoints();
    protected bool DoBoundsContainPoint(Vector3 point);
    protected Tuple<Vector3, Vector3> GetBoundingPoints();
    public bool IsPointInsidePolygon(Vector3 point);
    protected int CalculateWindingNumber(Vector2[] polygon, Vector2 point);
    protected Vector3 GetClosestPointOnPolygon(Vector3[] polyPoints, Vector3 point);
}