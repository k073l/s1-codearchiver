using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.UI;
public static class UnitsUtility
{
    public enum ERoundingType
    {
        None,
        Nearest,
        Up,
        Down
    }

    public static string FormatShortDistance(float meters, ERoundingType roundingType = ERoundingType.Nearest, int decimalPoints = 0);
    public static string FormatSpeed(float metersPerSecond, ERoundingType roundingType = ERoundingType.Nearest, int decimalPoints = 1);
    private static float RoundValue(float value, ERoundingType roundingType, int decimalPoints);
}