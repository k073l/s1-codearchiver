using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Object;
using ScheduleOne.Combat;
using ScheduleOne.Dialogue;
using ScheduleOne.Law;
using ScheduleOne.Noise;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Vision;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.NPCs.Responses;
public class NPCResponses_Civilian : NPCResponses
{
    public enum EAttackResponse
    {
        None,
        Panic,
        Flee,
        CallPolice,
        Fight
    }

    public enum EThreatType
    {
        None,
        AimedAt,
        GunshotHeard,
        ExplosionHeard
    }

    [Header("Response Settings")]
    public bool CanCallPolice;
    public bool OverrideThreatResponses;
    public EAttackResponse ThreatResponseOverride;
    private EAttackResponse currentThreatResponse;
    private float lastThreatTime;
    private Coroutine resetCoroutine;
    protected override void Awake();
    private void ScheduleResetCoroutine();
    private IEnumerator ResetAttackResponse();
    public override void GunshotHeard(NoiseEvent gunshotSound);
    public override void ExplosionHeard(NoiseEvent explosionSound);
    public override void PlayerFailedPickpocket(Player player);
    protected override void RespondToFirstNonLethalAttack(Player perpetrator, Impact impact);
    protected override void RespondToAnnoyingImpact(Player perpetrator, Impact impact);
    protected override void RespondToLethalAttack(Player perpetrator, Impact impact);
    protected override void RespondToRepeatedNonLethalAttack(Player perpetrator, Impact impact);
    private void RespondToLethalOrRepeatedAttack(Player perpetrator, Impact impact);
    public override void RespondToAimedAt(Player player);
    private void ExecuteThreatResponse(EAttackResponse response, Player target, Vector3 threatOrigin, Crime crime = null);
    private EAttackResponse GetThreatResponse(EThreatType type, Player threatSource);
}