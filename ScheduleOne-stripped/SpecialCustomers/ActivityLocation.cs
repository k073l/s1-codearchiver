using System;
using ScheduleOne.NPCs;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers;
[Serializable]
public class ActivityLocation
{
    public Transform Location;
    public SpecialCustomer Occupant { get; private set; }

    public void SetOccupant(SpecialCustomer npc);
}