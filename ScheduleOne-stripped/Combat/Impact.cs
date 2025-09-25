using System;
using FishNet.Object;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Combat;
[Serializable]
public class Impact
{
    public Vector3 HitPoint;
    public Vector3 ImpactForceDirection;
    public float ImpactForce;
    public float ImpactDamage;
    public EImpactType ImpactType;
    public NetworkObject ImpactSource;
    public int ImpactID;
    public Impact(Vector3 hitPoint, Vector3 impactForceDirection, float impactForce, float impactDamage, EImpactType impactType, NetworkObject impactSource, int impactID = 0);
    public Impact();
    public static bool IsLethal(EImpactType impactType);
    public bool IsPlayerImpact(out Player player);
}