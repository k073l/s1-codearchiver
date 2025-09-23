using UnityEngine;

namespace ScheduleOne.ItemFramework;
public static class ItemQuality
{
    public const float Heavenly_Threshold;
    public const float Premium_Threshold;
    public const float Standard_Threshold;
    public const float Poor_Threshold;
    public static Color Heavenly_Color;
    public static Color Premium_Color;
    public static Color Standard_Color;
    public static Color Poor_Color;
    public static Color Trash_Color;
    public static EQuality GetQuality(float qualityScalar);
    public static Color GetColor(EQuality quality);
}