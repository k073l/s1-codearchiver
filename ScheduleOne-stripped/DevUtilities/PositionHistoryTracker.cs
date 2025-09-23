using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public class PositionHistoryTracker : MonoBehaviour
{
    [Tooltip("Frequency (in seconds) to record the position.")]
    public float recordingFrequency;
    [Tooltip("Duration (in seconds) to store the position history.")]
    public float historyDuration;
    public List<Vector3> positionHistory;
    private float lastRecordTime;
    public float RecordedTime => (float)positionHistory.Count * recordingFrequency;

    private void Start();
    private void Update();
    private void RecordPosition();
    public Vector3 GetPositionXSecondsAgo(float secondsAgo);
    public void ClearHistory();
}