using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Combat;
public class PhysicsDamageable : MonoBehaviour, IPhysicsDamageable, IDamageable
{
    public float ForceMultiplier;
    private List<int> _impactHistory;
    public Rigidbody Rb { get; private set; }

    public event Action<Impact> OnImpacted;
    protected virtual void Awake();
    public virtual void SendImpact(Impact impact);
    public virtual void ReceiveImpact(Impact impact);
    GameObject IDamageable.get_gameObject();
}