using ScheduleOne.Audio;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.AvatarFramework.Equipping;
public class AvatarWeapon : AvatarEquippable
{
    [Header("Range settings")]
    public float MinUseRange;
    public float MaxUseRange;
    [Header("Cooldown settings")]
    public float CooldownDuration;
    [Header("Equipping")]
    public AudioClip[] EquipClips;
    public AudioSourceController EquipSound;
    public float EquipDuration;
    public UnityEvent onSuccessfulHit;
    private float _timeOnEquip;
    public float LastUseTime { get; private set; }

    public override void Equip(Avatar _avatar);
    public virtual void Attack();
    public virtual bool IsReadyToAttack();
}