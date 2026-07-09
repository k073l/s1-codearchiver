using System.Collections;
using UnityEngine;

namespace ScheduleOne.Tools;
public class SmoothedVelocityCalculator : MonoBehaviour
{
    public bool DEBUG;
    [Header("Settings")]
    [SerializeField]
    private float SampleLength;
    [SerializeField]
    private float MaxReasonableVelocity;
    [SerializeField]
    private int sampleCount;
    private RollingAverage<Vector3> velocityHistory;
    private Vector3 lastSamplePosition;
    private float timeOnLastSample;
    private float timeSinceLastSample;
    private bool zeroOut;
    private bool isTargetValid;
    private float sampleIntervalCached;
    private float maxReasonableVelocitySqrCached;
    public Transform Target { get; private set; }
    public virtual Vector3 Velocity { get; }

    private void Awake();
    private void Start();
    protected void LateUpdate();
    public void FlushBuffer();
    public void ZeroOut(float duration);
    public void SetTarget(Transform target);
    public void SetSampleLength(float length);
    public void SetMaxReasonableVelocity(float maxVelocity);
}