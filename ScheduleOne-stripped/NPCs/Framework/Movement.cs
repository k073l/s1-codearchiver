using System;
using UnityEngine.Serialization;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class Movement
{
    public float WalkSpeed;
    [FormerlySerializedAs("SprintSpeed")]
    public float MaxSpeed;
    public bool CanOpenDoors;
    public Movement GetCopy();
}