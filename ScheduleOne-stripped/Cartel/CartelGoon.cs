using System;
using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Cartel;
public class CartelGoon : NPC
{
    private List<CartelGoon> goonMates;
    private CartelGoonAppearance appearance;
    public Action onDespawn;
    private bool NetworkInitialize___EarlyScheduleOne_002ECartel_002ECartelGoonAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ECartel_002ECartelGoonAssembly_002DCSharp_002Edll_Excuted;
    public bool IsGoonSpawned { get; private set; }
    public GoonPool GoonPool => NetworkSingleton<Cartel>.Instance.GoonPool;

    protected override void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    public void Spawn(GoonPool pool, Vector3 spawnPoint);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void Spawn_Client(NetworkConnection conn);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void ConfigureGoonSettings(NetworkConnection conn, CartelGoonAppearance appearance, float moveSpeed);
    public void Despawn();
    [ObserversRpc(RunLocally = true)]
    private void Despawn_Client();
    public void AttackEntity(ICombatTargetable target, bool includeGoonMates = true);
    public void AddGoonMate(CartelGoon goonMate);
    public void RemoveGoonMate(CartelGoon goonMate);
    public bool IsMatesWith(CartelGoon otherGoon);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_Spawn_Client_328543758(NetworkConnection conn);
    private void RpcLogic___Spawn_Client_328543758(NetworkConnection conn);
    private void RpcReader___Observers_Spawn_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Spawn_Client_328543758(NetworkConnection conn);
    private void RpcReader___Target_Spawn_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ConfigureGoonSettings_3427656873(NetworkConnection conn, CartelGoonAppearance appearance, float moveSpeed);
    private void RpcLogic___ConfigureGoonSettings_3427656873(NetworkConnection conn, CartelGoonAppearance appearance, float moveSpeed);
    private void RpcReader___Observers_ConfigureGoonSettings_3427656873(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_ConfigureGoonSettings_3427656873(NetworkConnection conn, CartelGoonAppearance appearance, float moveSpeed);
    private void RpcReader___Target_ConfigureGoonSettings_3427656873(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_Despawn_Client_2166136261();
    private void RpcLogic___Despawn_Client_2166136261();
    private void RpcReader___Observers_Despawn_Client_2166136261(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}