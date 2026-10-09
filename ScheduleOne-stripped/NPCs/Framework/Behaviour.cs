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
    [Range(0f, 1f)]
    public float DefaultFortitude;
    public bool CanCallPolice;
    public Behaviour GetCopy();
}