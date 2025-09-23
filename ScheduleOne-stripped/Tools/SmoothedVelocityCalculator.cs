using System.Collections;
using UnityEngine;

namespace ScheduleOne.Tools;
public class SmoothedVelocityCalculator : MonoBehaviour
{
    private const int sampleCount;
    public bool DEBUG;
    [Header("Settings")]
    public float SampleLength;
    public float MaxReasonableVelocity;
    private CircularQueue<Vector3> velocityHistory;
    private Vector3 lastSamplePosition;
    private float timeOnLastSample;
    private float timeSinceLastSample;
    private bool zeroOut;
    public Vector3 Velocity { get; protected set; } = Vector3.zero;
    public Transform Target { get; private set; }

    private void Start();
    protected virtual void FixedUpdate();
    private Vector3 GetAverageVelocity();
    public void FlushBuffer();
    public void ZeroOut(float duration);
    public void SetTarget(Transform target);
}