using System;
using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;

namespace ScheduleOne.FX;
public class ShaderFlicker : MonoBehaviour
{
    [Header("General")]
    [SerializeField]
    private Vector2Int _minMaxTimeOfDay;
    [Header("Shader Property")]
    [SerializeField]
    private string propertyName;
    [Header("Flicker Bounds")]
    [SerializeField]
    private float minIntensity;
    [SerializeField]
    private float maxIntensity;
    [Header("Stable Period (Light Solid ON)")]
    [Tooltip("Minimum seconds the light stays steadily turned on")]
    [SerializeField]
    private float minStableTime;
    [Tooltip("Maximum seconds the light stays steadily turned on")]
    [SerializeField]
    private float maxStableTime;
    [Header("Flicker Burst Duration")]
    [Tooltip("Minimum length of a flickering fit in seconds")]
    [SerializeField]
    private float minBurstDuration;
    [Tooltip("Maximum length of a flickering fit in seconds")]
    [SerializeField]
    private float maxBurstDuration;
    [Header("Flicker Speed (During Burst)")]
    [Tooltip("Fastest delay between quick on/off switches")]
    [SerializeField]
    private float minFlickerInterval;
    [Tooltip("Slowest delay between quick on/off switches")]
    [SerializeField]
    private float maxFlickerInterval;
    private Material targetMaterial;
    private int propertyID;
    private Coroutine _flickeringCo;
    private bool _isActive;
    private void Start();
    public void StartFlickering();
    public void StopFlickering();
    private IEnumerator DoFlickerPatternRoutine();
    private void OnUncappedMin();
}