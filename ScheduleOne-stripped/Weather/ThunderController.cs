using System;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Audio;
using ScheduleOne.Combat;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.Effects;
using ScheduleOne.Employees;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Weather;
public class ThunderController : WeatherEffectController
{
    private const float _npcLightningStrikeDistanceFromPlayer;
    [Header("Thunder Settings")]
    [SerializeField]
    private float _maxThunderDelay;
    [SerializeField]
    private Vector2 _timeBetweenThunders;
    [SerializeField]
    [Range(0f, 1f)]
    private float _chanceForLightingStrike;
    [SerializeField]
    [Range(0f, 1f)]
    private float _chanceForLightingToHitPlayer;
    [SerializeField]
    [Range(0f, 1f)]
    private float _chanceForLightingToHitNPC;
    private float _sqrDistanceToPlayer;
    private float _thundertimer;
    private float _timeUntilNextThunder;
    private float _effectNormalisedDistanceToPlayer;
    private RandomizedAudioSourceController _thunderAudio;
    private RandomizedAudioSourceController _lightningAudio;
    private VFXEffectHandler _lightningEffect;
    private VFXEffectHandler _thunderEffect;
    private Vector3 _debugThunderLocation;
    private bool NetworkInitialize___EarlyScheduleOne_002EWeather_002EThunderControllerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EWeather_002EThunderControllerAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    private void Start();
    protected override void Update();
    [Button]
    private void TriggerThunder();
    public void TriggerRandomLightningStrike();
    public void TriggerRandomPlayerLightningStrike();
    public void TriggerPlayerLightningStrike(Player player);
    public void TriggerRandomNPCLightningStrike();
    public void TriggerNPCLightningStrike(NPC targetNPC);
    [ServerRpc(RequireOwnership = false)]
    private void TriggerLightningStrike_Server(Vector3 position);
    [ObserversRpc]
    private void TriggerLightningStrike_Client(Vector3 position);
    public void TriggerDistantThunder();
    [ObserversRpc]
    private void TriggerDistantThunder_Client(Vector3 location);
    private void RandomiseThunderTimer();
    public override void UpdateAudio();
    private Vector3 GetRandomPointInVolume();
    private void UpdateAudio(AudioSourceController audioSource, bool useEffectDistance);
    public override void UpdateProperties(Vector3 anchorPosition, Vector3 playerPosition, float sqrDistanceToPlayer, float enclosureBlend);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_TriggerLightningStrike_Server_4276783012(Vector3 position);
    private void RpcLogic___TriggerLightningStrike_Server_4276783012(Vector3 position);
    private void RpcReader___Server_TriggerLightningStrike_Server_4276783012(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_TriggerLightningStrike_Client_4276783012(Vector3 position);
    private void RpcLogic___TriggerLightningStrike_Client_4276783012(Vector3 position);
    private void RpcReader___Observers_TriggerLightningStrike_Client_4276783012(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_TriggerDistantThunder_Client_4276783012(Vector3 location);
    private void RpcLogic___TriggerDistantThunder_Client_4276783012(Vector3 location);
    private void RpcReader___Observers_TriggerDistantThunder_Client_4276783012(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002EWeather_002EThunderController_Assembly_002DCSharp_002Edll();
}