using UnityEngine;

namespace ScheduleOne.Product;
public static class DrugTypeMethods
{
    public static string GetName(this EDrugType property);
    public static Color GetColor(this EDrugType property);
    public static string GetNameWithRichTextColor(this EDrugType property);
}