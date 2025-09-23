using System;

namespace ScheduleOne.Law;
[Serializable]
public class DeadlyAssault : Crime
{
    public override string CrimeName { get; protected set; } = "Assault with a deadly weapon";
}