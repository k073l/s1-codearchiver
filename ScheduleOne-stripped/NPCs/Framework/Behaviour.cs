using System;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class Behaviour
{
    public bool IgnorePhysicsImpacts;
    public bool IgnoreCombatImpacts;
    [Range(0f, 1f)]
    public float DefaultAggression;
    public bool CanCallPolice;
    public Behaviour GetCopy();
}