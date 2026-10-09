using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Managing.Timing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.MiniGames;
public class FlyingLantern : NetworkBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Transform _lanternObj;
    [SerializeField]
    private MeshRenderer _lanternRenderer;
    [SerializeField]
    private InteractableObject _interactableObject;
    [SerializeField]
    private ParticleSystem _particleSystem;
    [Header("Settings")]
    [SerializeField]
    private float _timeToLight;
    [SerializeField]
    private AnimationCurve _lightTransitionCurver;
    [SerializeField]
    private float _timeBeforeReset;
    private readonly List<float> _emissionRecord;
    private bool _isRunning;
    private float _startTime;
    private int _randomSeed;
    private MaterialPropertyBlock _lanternPropertyBlock;
    private bool NetworkInitialize___EarlyScheduleOne_002EMiniGames_002EFlyingLanternAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EMiniGames_002EFlyingLanternAssembly_002DCSharp_002Edll_Excuted;
    private void Start();
    public override void OnStartServer();
    public override void OnSpawnServer(NetworkConnection connection);
    private IEnumerator DoSpawnRoutine();
    private void SetLanternIntensity(float value);
    [Button]
    [Client]
    public void Spawn();
    private void RebuildParticles(List<float> emissionRecord, float timer, uint randomSeed);
    private float GetCurrentTime();
    [ServerRpc(RequireOwnership = false)]
    private void SpawnLantern_Server(NetworkConnection sender);
    [ObserversRpc]
    private void SpawnLantern_Client(NetworkConnection sender);
    [TargetRpc]
    private void RebuildLanterns_Client(NetworkConnection conn, List<float> emissionRecord, float timer, uint randomSeed);
    [ObserversRpc]
    private void InitialiseLanterns(uint randomSeed);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SpawnLantern_Server_328543758(NetworkConnection sender);
    private void RpcLogic___SpawnLantern_Server_328543758(NetworkConnection sender);
    private void RpcReader___Server_SpawnLantern_Server_328543758(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SpawnLantern_Client_328543758(NetworkConnection sender);
    private void RpcLogic___SpawnLantern_Client_328543758(NetworkConnection sender);
    private void RpcReader___Observers_SpawnLantern_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_RebuildLanterns_Client_1342101494(NetworkConnection conn, List<float> emissionRecord, float timer, uint randomSeed);
    private void RpcLogic___RebuildLanterns_Client_1342101494(NetworkConnection conn, List<float> emissionRecord, float timer, uint randomSeed);
    private void RpcReader___Target_RebuildLanterns_Client_1342101494(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_InitialiseLanterns_1489494155(uint randomSeed);
    private void RpcLogic___InitialiseLanterns_1489494155(uint randomSeed);
    private void RpcReader___Observers_InitialiseLanterns_1489494155(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}