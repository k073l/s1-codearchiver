using FishNet;
using FishNet.Object;
using ScheduleOne.Cartel;
using ScheduleOne.Combat;
using ScheduleOne.Noise;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Responses;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Vehicles;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.Police;
public class NPCResponses_CartelGoon : NPCResponses
{
    [Header("References")]
    public CartelGoon Goon;
    protected override void Awake();
    public override void ExplosionHeard(NoiseEvent explosionSound);
    public override void GunshotHeard(NoiseEvent gunshotSound);
    public override void NoticePlayerDischargingWeapon(Player player);
    public override void PlayerFailedPickpocket(Player player);
    public override void HitByCar(LandVehicle vehicle);
    public override void ImpactReceived(Impact impact);
    public override void RespondToAimedAt(Player player);
    protected override void RespondToAnnoyingImpact(Player perpetrator, Impact impact);
}