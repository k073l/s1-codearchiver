using ScheduleOne.PlayerScripts;

namespace ScheduleOne.Variables;
public class NumberVariable : Variable<float>
{
    public NumberVariable(string name, EVariableReplicationMode replicationMode, bool persistent, EVariableMode mode, Player owner, float value);
    public override bool TryDeserialize(string valueString, out float value);
    public override bool EvaluateCondition(Condition.EConditionType operation, string value);
}