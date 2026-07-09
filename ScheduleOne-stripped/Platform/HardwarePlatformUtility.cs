using ScheduleOne.DevUtilities;
using Steamworks;
using UnityEngine.InputSystem;

namespace ScheduleOne.Platform;
public static class HardwarePlatformUtility
{
    public static EHardwarePlatform GetCurrentPlatform();
    public static bool IsAnyGamepadConnected();
    public static DisplaySettings.EDisplayMode[] GetAvailableDisplayModes();
}