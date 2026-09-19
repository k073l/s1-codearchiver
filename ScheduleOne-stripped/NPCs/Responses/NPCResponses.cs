using System;
using ScheduleOne.Combat;
using ScheduleOne.Law;
using ScheduleOne.Noise;
using ScheduleOne.NPCs.Actions;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Vehicles;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.NPCs.Responses;
public class NPCResponses : MonoBehaviour
{
    private const float AssaultRelationshipChange;
    private const float DeadlyAssaultRelationshipChange;
    private const float AimedAtRelationshipChange;
    private const float PickpocketRelationshipChange;
    private const float RelationshipDecreaseCooldown;
    private const float RepeatedNonLethalAttackThreshold;
    public Action<Player> OnNonLethallyAttackedByPlayer;
    public Action<Player> OnRepeatedlyNonLethallyAttackedByPlayer;
    public Action<Player> OnLethallyAttackedByPlayer;
    public Action<Player> OnAimedAtByPlayer;
    protected float _timeOnLastImpact;
    protected float _timeOnLastAimedAt;
    protected NPC npc { get; private set; }
    protected bool IsNPCAwarenessActive => npc.Awareness.IsAwarenessActive;
    protected NPCActions actions => npc.Actions;

    protected virtual void Awake();
    public virtual void GunshotHeard(NoiseEvent gunshotSound);
    public virtual void ExplosionHeard(NoiseEvent explosionSound);
    public virtual void NoticedPettyCrime(Player player);
    public virtual void NoticedVandalism(Player player);
    public virtual void SawPickpocketing(Player player);
    public virtual void NoticePlayerBrandishingWeapon(Player player);
    public virtual void NoticePlayerDischargingWeapon(Player player);
    public virtual void PlayerFailedPickpocket(Player player);
    public virtual void NoticedDrugDeal(Player player);
    public virtual void NoticedViolatingCurfew(Player player);
    public virtual void NoticedWantedPlayer(Player player);
    public virtual void NoticedSuspiciousPlayer(Player player);
    public void HitByCar(LandVehicle vehicle);
    protected virtual void RespondToHitByCar(LandVehicle vehicle);
    public virtual void ImpactReceived(Impact impact);
    protected virtual void RespondToFirstNonLethalAttack(Player perpetrator, Impact impact);
    protected virtual void RespondToRepeatedNonLethalAttack(Player perpetrator, Impact impact);
    protected virtual void RespondToLethalAttack(Player perpetrator, Impact impact);
    protected virtual void RespondToAnnoyingImpact(Player perpetrator, Impact impact);
    public virtual void AimedAtByPlayer(Player player);
    protected virtual void RespondToAimedAt(Player player);
}