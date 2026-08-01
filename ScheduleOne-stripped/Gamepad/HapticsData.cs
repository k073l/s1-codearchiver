using UnityEngine;

namespace ScheduleOne.Gamepad;
[CreateAssetMenu(fileName = "HapticsData", menuName = "ScheduleOne/Gamepad/Haptics Data")]
public class HapticsData : ScriptableObject
{
    [Header("Control Settings")]
    public string Id;
    [Tooltip("Begin, Active and End durations of the haptic feedback in seconds")]
    public EHapticMode HapticMode;
    public Vector3 Duration;
    public AnimationCurve EnterCurve;
    public AnimationCurve ExitCurve;
    [Header("Haptic Settings")]
    public HapticSettings LowFrequencySettings;
    public HapticSettings HighFrequencySettings;
}