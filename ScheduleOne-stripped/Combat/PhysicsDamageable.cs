using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Combat;
public class PhysicsDamageable : MonoBehaviour, IDamageable
{
    public const int VELOCITY_HISTORY_LENGTH;
    public Rigidbody Rb;
    public float ForceMultiplier;
    private List<int> impactHistory;
    public Action<Impact> onImpacted;
    private List<Vector3> velocityHistory;
    public Vector3 averageVelocity { get; private set; } = Vector3.zero;

    public void OnValidate();
    public virtual void SendImpact(Impact impact);
    public virtual void ReceiveImpact(Impact impact);
    GameObject IDamageable.get_gameObject();
}