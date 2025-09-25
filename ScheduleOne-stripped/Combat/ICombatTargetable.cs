using FishNet.Object;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Vision;
using UnityEngine;

namespace ScheduleOne.Combat;
public interface ICombatTargetable : IDamageable, ISightable
{
    new NetworkObject NetworkObject { get; }

    Vector3 CenterPoint => CenterPointTransform.position;

    Transform CenterPointTransform { get; }

    Vector3 LookAtPoint { get; }

    bool IsCurrentlyTargetable { get; }

    float RangedHitChanceMultiplier { get; }

    Vector3 Velocity { get; }

    bool IsPlayer => this is Player;

    Player AsPlayer => this as Player;

    void RecordLastKnownPosition(bool resetTimeSinceLastSeen);
    float GetSearchTime();
}