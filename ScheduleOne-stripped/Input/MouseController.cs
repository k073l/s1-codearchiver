using ScheduleOne.DevUtilities;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Input;
public static class MouseController
{
    public static bool IsMouseVisible { get; private set; } = true;

    public static void LockMouse(bool showCrosshair = true);
    public static void FreeMouse(bool hideCrosshair = true);
}