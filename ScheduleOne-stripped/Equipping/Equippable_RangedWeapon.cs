using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using ScheduleOne.Audio;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.ItemFramework;
using ScheduleOne.Noise;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Storage;
using ScheduleOne.Trash;
using ScheduleOne.UI;
using ScheduleOne.Vision;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Equipping;
public class Equippable_RangedWeapon : Equippable_AvatarViewmodel
{
    public enum EReloadType
    {
        Magazine,
        Incremental
    }

    public const float NPC_AIM_DETECTION_RANGE;
    public int MagazineSize;
    [Header("Aim Settings")]
    public float AimDuration;
    public float AimFOVReduction;
    [Header("Firing")]
    public AudioSourceController FireSound;
    public AudioSourceController EmptySound;
    public float FireCooldown;
    public string[] FireAnimTriggers;
    public float AccuracyChangeDuration;
    [Header("Raycasting")]
    public float Range;
    public float RayRadius;
    [Header("Spread")]
    public float MinSpread;
    public float MaxSpread;
    [Header("Damage")]
    public float Damage;
    public float ImpactForce;
    [Header("Reloading")]
    public bool CanReload;
    public EReloadType ReloadType;
    public StorableItemDefinition Magazine;
    public float ReloadStartTime;
    public float ReloadIndividalTime;
    public float ReloadEndTime;
    public string ReloadStartAnimTrigger;
    public string ReloadIndividualAnimTrigger;
    public string ReloadEndAnimTrigger;
    public TrashItem ReloadTrash;
    [Header("Cocking")]
    public bool MustBeCocked;
    public bool CockedByDefault;
    public bool AutoCockAfterReload;
    public float CockTime;
    public string CockAnimTrigger;
    [Header("Effects")]
    public float TracerSpeed;
    public UnityEvent onFire;
    public UnityEvent onReloadStart;
    public UnityEvent onReloadIndividual;
    public UnityEvent onReloadEnd;
    public UnityEvent onCockStart;
    protected IntegerItemInstance weaponItem;
    private bool fovOverridden;
    private float aimVelocity;
    private Coroutine reloadRoutine;
    private bool shotQueued;
    private bool reloadQueued;
    private float timeSincePrimaryClick;
    private float timeSinceReloadStart;
    private bool interruptReload;
    public float Aim { get; private set; }
    public float Accuracy { get; private set; }
    public float TimeSinceFire { get; set; } = 1000f;
    public bool IsReloading { get; private set; }
    public bool IsCocked { get; private set; }
    public bool IsCocking { get; private set; }
    public int Ammo { get; }
    private float aimFov => Singleton<Settings>.Instance.CameraFOV - AimFOVReduction;

    public override void Equip(ItemInstance item);
    public override void Unequip();
    protected override void Update();
    private void UpdateInput();
    private void UpdateAnim();
    private bool CanAim();
    public virtual void Fire();
    protected virtual Vector3[] GetBulletDirections();
    protected static Vector3 SpreadDirection(Vector3 direction, float maxAngle);
    public virtual void Reload();
    protected virtual void NotifyIncrementalReload();
    private bool IsReloadReady(bool ignoreTiming);
    protected virtual bool GetMagazine(out StorableItemInstance mag);
    private bool CanFire(bool checkAmmo = true);
    private bool CanCock();
    private void Cock();
    protected float GetSpreadAngle();
    private void CheckAimingAtNPC();
}