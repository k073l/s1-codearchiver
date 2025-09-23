using System;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Audio;
[RequireComponent(typeof(Rigidbody))]
public class ImpactSoundEntity : MonoBehaviour
{
    public enum EMaterial
    {
        Wood,
        HollowMetal,
        Cardboard,
        Glass,
        Plastic,
        Basketball,
        SmallHollowMetal,
        PlasticBag,
        Punch,
        BaseballBat
    }

    public const float MIN_IMPACT_MOMENTUM;
    public const float COOLDOWN;
    public EMaterial Material;
    private float lastImpactTime;
    private Rigidbody rb;
    public void Awake();
    private void OnImpacted(Impact impact);
    private void OnCollisionEnter(Collision collision);
}