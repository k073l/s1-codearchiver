using System.Collections;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Equipping;
public class AvatarGun : AvatarRangedWeapon
{
    [Header("References")]
    public Animation Anim;
    public ParticleSystem ShellParticles;
    public ParticleSystem SmokeParticles;
    public Transform FlashObject;
    [Header("Prefabs")]
    public GameObject RayPrefab;
    private Coroutine flashRoutine;
    protected override void Shoot(Vector3 endPoint);
    private IEnumerator Flash(Vector3 endPoint);
}