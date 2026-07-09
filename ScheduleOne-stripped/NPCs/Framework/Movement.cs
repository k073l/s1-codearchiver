using System;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class Movement
{
    public float WalkSpeed;
    public float SprintSpeed;
    public bool CanOpenDoors;
    public Movement GetCopy();
}