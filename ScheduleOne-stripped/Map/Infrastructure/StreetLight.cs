using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Misc;
using UnityEngine;

namespace ScheduleOne.Map.Infrastructure;
public class StreetLight : MonoBehaviour
{
    private static Vector3 PowerOrigin;
    [Header("References")]
    [SerializeField]
    protected ToggleableLight _light;
    [Header("Timing")]
    public int StartTime;
    public int EndTime;
    private int _startTimeOffset;
    protected virtual void Awake();
    private void Start();
    private void UpdateState();
    private void SetState(bool on);
}