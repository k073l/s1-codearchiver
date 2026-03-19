using System;
using ScheduleOne.Combat;
using ScheduleOne.Core.Audio;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio;
[RequireComponent(typeof(Rigidbody))]
public class RBImpactSounds : MonoBehaviour
{
    public const float MinImpactMomentum;
    public const float SoundCooldown;
    [SerializeField]
    [FormerlySerializedAs("Material")]
    private EImpactSound _material;
    private float _lastImpactTime;
    private Rigidbody _rb;
    private void Awake();
    private void OnImpacted(Impact impact);
    private void OnCollisionEnter(Collision collision);
}