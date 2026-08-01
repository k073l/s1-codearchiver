using System;
using UnityEngine;

namespace ScheduleOne.Gamepad;
[Serializable]
public class HapticSettings
{
    [Tooltip("Base intensity of the haptic feedback")]
    [Range(0f, 1f)]
    public float Intensity;
    [Tooltip("Number of pulse cycles per second")]
    public float PulseCyclesPerSecond;
    [Tooltip("Intensity of the pulse")]
    [Range(0f, 1f)]
    public float PulseIntensity;
}