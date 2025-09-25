using System;
using ScheduleOne.Property;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class ManorData : PropertyData
{
    public Manor.EManorState ManorState;
    public int DaysSinceStateChange;
    public bool TunnelDug;
    public ManorData(string propertyCode, bool isOwned, bool[] switchStates, bool[] toggleableStates, DynamicSaveData[] employees, DynamicSaveData[] objects, Manor.EManorState state, int daysSinceStateChange, bool tunnelDug);
}