using System;
using UnityEngine;

namespace ScheduleOne.Combat;
public interface IPhysicsDamageable : IDamageable
{
    Rigidbody Rb { get; }

    event Action<Impact> OnImpacted;
}