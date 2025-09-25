using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.NPCs;
using UnityEngine;

namespace ScheduleOne.Map;
public class NPCPresenceAccessZone : AccessZone
{
    public const float CooldownTime;
    public Collider DetectionZone;
    public NPC TargetNPC;
    private float timeSinceNPCSensed;
    protected override void Awake();
    protected virtual void Start();
    protected virtual void MinPass();
}