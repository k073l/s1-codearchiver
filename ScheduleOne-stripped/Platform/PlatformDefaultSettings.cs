using ScheduleOne.DevUtilities;
using ScheduleOne.Gamepad;
using UnityEngine;

namespace ScheduleOne.Platform;
[CreateAssetMenu(fileName = "PlatformDefaultSettings", menuName = "ScheduleOne/Platform/PlatformDefaultSettings", order = 0)]
public class PlatformDefaultSettings : ScriptableObject
{
    public EHardwarePlatform Platform;
    public DisplaySettings DisplaySettings;
    public GraphicsSettings GraphicsSettings;
    public InputSettings InputSettings;
    public GamepadSettings GamepadSettings;
}