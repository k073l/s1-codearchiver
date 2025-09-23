using System;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Variables;
[Serializable]
public class Condition
{
    public enum EConditionType
    {
        GreaterThan,
        LessThan,
        EqualTo,
        NotEqualTo,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo
    }

    public string VariableName;
    public EConditionType Operator;
    public string Value;
    public bool Evaluate();
}