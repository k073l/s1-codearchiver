using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Weather;
public class BasicEnclosure : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private Vector3 _center;
    [SerializeField]
    private Vector3 _size;
    [SerializeField]
    private bool _isBlendZone;
    [Header("Debug")]
    [SerializeField]
    private float _backRadius;
    [SerializeField]
    private float _frontRadius;
    [SerializeField]
    private bool _debugMode;
    private Vector3 _debugClosestPoint;
    private Vector3 _debugOppositePoint;
    private float _debugBlendValue;
    private float _debugActiveRadius;
    public Vector3 StartPoint => ((Component)this).transform.TransformPoint(_center) - ((Component)this).transform.forward * (_size.z / 2f);
    public Vector3 EndPoint => ((Component)this).transform.TransformPoint(_center) + ((Component)this).transform.forward * (_size.z / 2f);
    public Vector3 Size { get; }
    public bool IsBlendZone => _isBlendZone;

    public bool WithinEnclosure(Vector3 targetPosition);
    public float GetEnclosureBlend(Vector3 targetPosition);
    public Vector3 GetClosestPointOnZFaces(Vector3 targetPosition);
    public Vector3 GetOppositeFacePoint(Vector3 surfacePoint);
}