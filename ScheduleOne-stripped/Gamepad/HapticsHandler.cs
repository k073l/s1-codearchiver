using UnityEngine;

namespace ScheduleOne.Gamepad;
public static class HapticsHandler
{
    private static IHapticsManager _hapticsManager;
    public static void SetManager(IHapticsManager hapticsManager);
    public static void RemoveManager(IHapticsManager hapticsManager);
    public static void Begin(string preset, float intensityMultiplier = 1f);
    public static void Begin(HapticsData data, float intensityMultiplier = 1f);
    public static void End();
    public static void Cancel();
    public static void SetMultiplier(float multiplier);
    public static float ForceToMultiplier(EHapticImpact impact, float force);
    private static bool IsManagerValid();
}