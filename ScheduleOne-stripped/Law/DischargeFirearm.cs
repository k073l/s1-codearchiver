using System;

namespace ScheduleOne.Law;
[Serializable]
public class DischargeFirearm : Crime
{
    public override string CrimeName { get; protected set; } = "Discharge of a firearm in a public place";
}