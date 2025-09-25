using System;

namespace ScheduleOne.Variables;
[Serializable]
public class Conditions
{
    public enum EEvaluationType
    {
        And,
        Or
    }

    public EEvaluationType EvaluationType;
    public Condition[] ConditionList;
    public QuestCondition[] QuestConditionList;
    public bool Evaluate();
}