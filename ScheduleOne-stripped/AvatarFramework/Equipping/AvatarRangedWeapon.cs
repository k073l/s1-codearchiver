using System.Collections;
using System.Linq;
using FishNet.Object;
using ScheduleOne.Audio;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Vehicles;
using ScheduleOne.Vision;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Equipping;
public class AvatarRangedWeapon : AvatarWeapon
{
    [Header("Weapon Settings")]
    public int MagazineSize;
    public float ReloadTime;
    public float MaxFireRate;
    public float EquipTime;
    public float RaiseTime;
    public float Damage;
    public float ImpactForce;
    public bool CanShootWhileMoving;
    public int MaxMovingShotsBeforeReposition;
    public int MaxStationaryShotsBeforeReposition;
    public bool RepositionAfterHit;
    [Header("Accuracy")]
    public float HitChance_MinRange;
    public float HitChance_MaxRange;
    [Header("Aiming")]
    public float AimTime_Min;
    public float AimTime_Max;
    [Header("References")]
    public Transform MuzzlePoint;
    public AudioSourceController FireSound;
    [Header("Animation Settings")]
    public string LoweredAnimationTrigger;
    public string RaisedAnimationTrigger;
    public string RecoilAnimationTrigger;
    private bool isReloading;
    private float timeEquipped;
    private float timeRaised;
    private float timeSinceLastShot;
    private int currentAmmo;
    public bool IsRaised { get; protected set; }

    public override void Equip(Avatar _avatar);
    public virtual void SetIsRaised(bool raised);
    private void Update();
    public override void ReceiveMessage(string message, object data);
    public bool CanShoot();
    protected virtual void Shoot(Vector3 endPoint);
    public virtual void ApplyHitToDamageable(IDamageable damageable, Vector3 hitPoint);
    private IEnumerator Reload();
    public bool IsTargetInLoS(ICombatTargetable target);
    public virtual float GetIdealUseRange();
}