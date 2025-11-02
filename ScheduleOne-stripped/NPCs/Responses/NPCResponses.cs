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
    public const float ASSAULT_RELATIONSHIPCHANGE;
    public const float DEADLYASSAULT_RELATIONSHIPCHANGE;
    public const float AIMED_AT_RELATIONSHIPCHANGE;
    public const float PICKPOCKET_RELATIONSHIPCHANGE;
    private const float INITIALIZED_TIME_OFFSET;
    private const float TIME_THRESHOLD;
    protected float timeSinceLastImpact;
    protected float timeSinceAimedAt;
    protected NPC npc { get; private set; }
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
    public virtual void HitByCar(LandVehicle vehicle);
    public virtual void ImpactReceived(Impact impact);
    protected virtual void RespondToFirstNonLethalAttack(Player perpetrator, Impact impact);
    protected virtual void RespondToRepeatedNonLethalAttack(Player perpetrator, Impact impact);
    protected virtual void RespondToLethalAttack(Player perpetrator, Impact impact);
    protected virtual void RespondToAnnoyingImpact(Player perpetrator, Impact impact);
    public virtual void RespondToAimedAt(Player player);
}