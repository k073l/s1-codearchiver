using UnityEngine;

namespace ScheduleOne.Core;
public class ConditionalAttribute : PropertyAttribute
{
    public string ConditionalSourceField;
    public bool Invert;
    public object CompareValue;
    public object[] CompareValues;
    public ConditionalAttribute(string conditionalSourceField, bool invert = false);
    public ConditionalAttribute(string conditionalSourceField, object compareValue, bool invert = false);
    public ConditionalAttribute(string conditionalSourceField, bool invert, params object[] compareValues);
}