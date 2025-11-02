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
    private RollingAverage<Vector3> velocityHistory;
    private Vector3 lastSamplePosition;
    private float timeOnLastSample;
    private float timeSinceLastSample;
    private bool zeroOut;
    private bool isTargetValid;
    public Transform Target { get; private set; }
    public virtual Vector3 Velocity { get; }

    private void Start();
    protected virtual void FixedUpdate();
    public void FlushBuffer();
    public void ZeroOut(float duration);
    public void SetTarget(Transform target);
}