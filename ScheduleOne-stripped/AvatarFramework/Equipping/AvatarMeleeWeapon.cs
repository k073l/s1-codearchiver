using System;
using System.Collections;
using FishNet.Object;
using ScheduleOne.Audio;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.Vehicles;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Equipping;
public class AvatarMeleeWeapon : AvatarWeapon
{
    [Serializable]
    public class MeleeAttack
    {
        public float RangeMultiplier;
        public float DamageMultiplier;
        public string AnimationTrigger;
        public float DamageDelay;
        public float AttackSoundDelay;
        public AudioClip[] AttackClips;
        public AudioClip[] HitClips;
    }

    public const float GruntChance;
    [Header("References")]
    public AudioSourceController AttackSound;
    public AudioSourceController HitSound;
    [Header("Melee Weapon settings")]
    public EImpactType ImpactType;
    public float AttackRange;
    public float AttackRadius;
    public float Damage;
    public float ImpactForce;
    public MeleeAttack[] Attacks;
    private Coroutine attackRoutine;
    public override void Unequip();
    public override bool IsReadyToAttack();
    public override void Attack();
}