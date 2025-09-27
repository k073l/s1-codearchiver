using System;

namespace ScheduleOne.Law;
[Serializable]
public class PossessingControlledSubstances : Crime
{
    public override string CrimeName { get; protected set; } = "Possession of controlled substances";
}