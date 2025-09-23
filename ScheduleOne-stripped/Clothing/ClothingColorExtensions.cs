using System;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Clothing;
public static class ClothingColorExtensions
{
    public static Color GetActualColor(this EClothingColor color);
    public static Color GetLabelColor(this EClothingColor color);
    public static string GetLabel(this EClothingColor color);
    public unsafe static EClothingColor GetClothingColor(Color color);
    public static bool ColorEquals(Color a, Color b, float tolerance = 0.004f);
}