using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class Equippable_PumpShotgun : Equippable_RangedWeapon
{
    [Header("Shotgun Settings")]
    public int PelletCount;
    protected override Vector3[] GetBulletDirections();
}