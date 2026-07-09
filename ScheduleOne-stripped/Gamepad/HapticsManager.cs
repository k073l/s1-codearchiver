using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScheduleOne.Gamepad;
public class HapticsManager : MonoBehaviour, IHapticsManager
{
    [Header("Control Settings")]
    [SerializeField]
    [Range(0f, 1f)]
    private float _hapticsMultipler;
    [SerializeField]
    private AnimationCurve _hapticsCurve;
    [Header("Haptic Settings")]
    [SerializeField]
    private Vector2 _minMaxForce;
    [SerializeField]
    private List<HapticsData> _hapticsDataList;
    [Header("Haptic Forces")]
    [SerializeField]
    private float _LightForceMax;
    [SerializeField]
    private float _MediumForceMax;
    [SerializeField]
    private float _HeavyForceMax;
    [Header("Debugging")]
    [SerializeField]
    private string _debugHapticsId;
    [SerializeField]
    private bool _enableHaptics;
    [SerializeField]
    private bool _bypassInputCheck;
    private Dictionary<string, HapticsData> _hapticsRegistry;
    private HapticsData _currentHapticsData;
    private Coroutine _hapticsCo;
    private float _hapticsTimer;
    private bool _canExit;
    private void Start();
    public void Begin(string preset, float intensityMultiplier = 1f);
    public void Begin(HapticsData data, float intensityMultiplier = 1f);
    public void End();
    public void Cancel();
    public void SetMultiplier(float multiplier);
    private IEnumerator DoHapticsRoutine(HapticsData data);
    private float GetHapticsIntensity(HapticSettings settings, float timer);
    private void SetHaptics(float lowFrequencyIntensity, float highFrequencyIntensity);
    public float ForceToMultiplier(EHapticImpact impact, float force);
    [Button]
    public void DebugTriggerHaptics();
    [Button]
    public void DebugEndHaptics();
    private void OnDestroy();
}