using System.Collections;
using ScheduleOne.Audio;
using ScheduleOne.Combat;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Equipping;
public class Taser : AvatarRangedWeapon
{
    public const float TaseDuration;
    public const float TaseMoveSpeedMultiplier;
    [Header("References")]
    public GameObject FlashObject;
    public AudioSourceController ChargeSound;
    [Header("Prefabs")]
    public GameObject RayPrefab;
    private Coroutine flashRoutine;
    public override void Equip(Avatar _avatar);
    protected override void Shoot(Vector3 endPoint);
    public override void ApplyHitToDamageable(IDamageable damageable, Vector3 hitPoint);
    public override void SetIsRaised(bool raised);
    private IEnumerator Flash(Vector3 endPoint);
    public override float GetIdealUseRange();
}