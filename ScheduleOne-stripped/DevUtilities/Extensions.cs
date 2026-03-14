using System.Collections.Generic;

namespace ScheduleOne.DevUtilities;
public static class Extensions
{
    public static T[] ShiftLeft<T>(this T[] array);
    public static T[] ShiftRight<T>(this T[] array);
    public static List<T> ShiftLeft<T>(this List<T> array);
    public static List<T> ShiftRight<T>(this List<T> array);
}