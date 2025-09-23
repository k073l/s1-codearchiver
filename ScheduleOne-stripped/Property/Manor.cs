using System;
using EasyButtons;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.Audio;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Property;
public class Manor : Property
{
    public enum EManorState
    {
        Original,
        Destroyed,
        Rebuilt
    }

    public const int REBUILD_AFTER_DAYS;
    public const int REBUILD_DURATION_DAYS;
    [Header("References")]
    public GameObject OriginalContainer;
    public GameObject DestroyedContainer;
    public GameObject RebuiltContainer;
    public GameObject DestructionFXContainer;
    public GameObject TunnelBlocker;
    public GameObject TunnelCollapse;
    public GameObject ConstructionContainer;
    public AudioSourceController[] ExplosionSounds;
    public GameObject[] DisableOnRebuild;
    public Action onRebuildComplete;
    private bool NetworkInitialize___EarlyScheduleOne_002EProperty_002EManorAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EProperty_002EManorAssembly_002DCSharp_002Edll_Excuted;
    public EManorState ManorState { get; private set; }
    public int DaysSinceStateChange { get; private set; } = 999;
    public bool TunnelDug { get; set; }

    public override void Awake();
    public override void OnSpawnServer(NetworkConnection connection);
    protected override void Start();
    protected override void RecieveOwned();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetManorState(NetworkConnection conn, EManorState state, bool resetStateChangeTimer);
    [Button]
    public void Explode();
    [Button]
    public void Rebuild();
    public void SetDestroyedIfOriginal();
    public void DigTunnel();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SetTunnelDug(NetworkConnection conn, bool dug);
    public override bool CanBePurchased();
    private void OnSleepEnd();
    public override bool ShouldSave();
    public override string GetSaveString();
    public override void Load(PropertyData propertyData, string dataString);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_SetManorState_365422978(NetworkConnection conn, EManorState state, bool resetStateChangeTimer);
    private void RpcLogic___SetManorState_365422978(NetworkConnection conn, EManorState state, bool resetStateChangeTimer);
    private void RpcReader___Observers_SetManorState_365422978(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetManorState_365422978(NetworkConnection conn, EManorState state, bool resetStateChangeTimer);
    private void RpcReader___Target_SetManorState_365422978(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetTunnelDug_214505783(NetworkConnection conn, bool dug);
    public void RpcLogic___SetTunnelDug_214505783(NetworkConnection conn, bool dug);
    private void RpcReader___Observers_SetTunnelDug_214505783(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetTunnelDug_214505783(NetworkConnection conn, bool dug);
    private void RpcReader___Target_SetTunnelDug_214505783(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002EProperty_002EManor_Assembly_002DCSharp_002Edll();
}