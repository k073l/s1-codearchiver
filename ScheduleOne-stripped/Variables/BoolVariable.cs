using ScheduleOne.PlayerScripts;

namespace ScheduleOne.Variables;
public class BoolVariable : Variable<bool>
{
    public BoolVariable(string name, EVariableReplicationMode replicationMode, bool persistent, EVariableMode mode, Player owner, bool value);
    public override bool TryDeserialize(string valueString, out bool value);
    public override bool EvaluateCondition(Condition.EConditionType operation, string value);
}