using System;

namespace ScheduleOne.Core;
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class ButtonAttribute : Attribute
{
    public string ButtonName { get; private set; }
    public string ConditionName { get; private set; }

    public ButtonAttribute();
    public ButtonAttribute(string buttonName);
    public ButtonAttribute(string buttonName, string conditionName);
}