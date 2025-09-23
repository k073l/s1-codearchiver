using FishNet.Connection;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Quests;
using UnityEngine.Events;

namespace ScheduleOne.Variables;
public class Variable<T> : BaseVariable
{
    public T Value;
    public UnityEvent<T> OnValueChanged;
    public Variable(string name, EVariableReplicationMode replicationMode, bool persistent, EVariableMode mode, Player owner, T value);
    public override object GetValue();
    public override void SetValue(object value, bool replicate);
    public virtual bool TryDeserialize(string valueString, out T value);
    public override void ReplicateValue(NetworkConnection conn);
}