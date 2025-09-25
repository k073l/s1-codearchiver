using UnityEngine;

namespace ScheduleOne.Combat;
public interface IDamageable
{
    GameObject gameObject { get; }

    void SendImpact(Impact impact);
    void ReceiveImpact(Impact impact);
}