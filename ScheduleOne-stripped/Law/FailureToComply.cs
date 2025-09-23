using System;

namespace ScheduleOne.Law;
[Serializable]
public class FailureToComply : Crime
{
    public override string CrimeName { get; protected set; } = "Failure to comply with police instruction";
}