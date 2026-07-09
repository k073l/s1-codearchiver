using System;
using Steamworks;
using UnityEngine;

namespace ScheduleOne.Platform;
public static class PlatformEvents
{
    public static event Action OnOverlayActivated;
    public static event Action OnOverlayDeactivated;
    public static event Action OnGameLoseFocus;
    public static event Action OnGameGainFocus;
    [RuntimeInitializeOnLoadMethod]
    private static void InitFocusCallback();
    private static void OnApplicationFocusChanged(bool hasFocus);
    [RuntimeInitializeOnLoadMethod]
    private static void InitOverlayCallback();
    private static void OverlayActivated(GameOverlayActivated_t pCallback);
}