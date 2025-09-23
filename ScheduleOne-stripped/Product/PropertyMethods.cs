using UnityEngine;

namespace ScheduleOne.Product;
public static class PropertyMethods
{
    public static string GetName(this EProperty property);
    public static string GetDescription(this EProperty property);
    public static Color GetColor(this EProperty property);
}