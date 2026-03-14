using System;
using System.Linq;
using UnityEngine;

namespace ScheduleOne.Audio;
public class PolygonalZone : MonoBehaviour
{
    public Transform PointContainer;
    public bool IsClosed;
    public float VerticalSize;
    [Header("Debug")]
    public Color ZoneColor;
    protected Vector3[] points;
    protected virtual void Awake();
    private void OnDrawGizmos();
    public bool IsPointInsidePolygon(Vector3 point);
    public bool IsPointInsideZone(Vector3 point);
    public float GetDistanceToClosestPointOnZone(Vector3 source);
    protected Vector3[] GetPoints();
    protected bool DoBoundsContainPoint(Vector3 point);
    protected Tuple<Vector3, Vector3> GetBoundingPoints();
    protected int CalculateWindingNumber(Vector2[] polygon, Vector2 point);
    protected Vector3 GetClosestPointOnPolygon(Vector3[] polyPoints, Vector3 point);
}