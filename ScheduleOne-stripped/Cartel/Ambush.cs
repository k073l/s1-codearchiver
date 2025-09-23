using System;
using System.Collections;
using System.Collections.Generic;
using FishNet;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.Economy;
using ScheduleOne.Levelling;
using ScheduleOne.Map;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Police;
using ScheduleOne.Product;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.Cartel;
public class Ambush : CartelActivity
{
    public const float MIN_DISTANCE_TO_POLICE_OFFICER;
    public const int CANCEL_AMBUSH_AFTER_MINS;
    public const float AMBUSH_DEFEATED_INFLUENCE_CHANGE;
    public static FullRank MIN_RANK_FOR_RANGED_WEAPONS;
    private CartelRegionActivities _regionActivities;
    [Header("Settings")]
    public AvatarWeapon[] RangedWeapons;
    public AvatarWeapon[] MeleeWeapons;
    public override void Activate(EMapRegion region);
    protected override void Deactivate();
    protected override void MinPassed();
    private bool CanPlayerBeAmbushed(Player player);
    private void ContractReceiptRecorded(ContractReceipt receipt);
    private void SpawnAmbush(Player target, Vector3[] potentialSpawnPoints);
}