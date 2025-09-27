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
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Map;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;

namespace ScheduleOne.Cartel;
public class Cartel : NetworkSingleton<Cartel>, IBaseSaveable, ISaveable
{
    public bool TEST_MODE;
    [Header("References")]
    public CartelActivities Activities;
    public CartelInfluence Influence;
    public GoonPool GoonPool;
    public CartelDealManager DealManager;
    public Action<ECartelStatus, ECartelStatus> OnStatusChange;
    private CartelLoader loader;
    private bool NetworkInitialize___EarlyScheduleOne_002ECartel_002ECartelAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ECartel_002ECartelAssembly_002DCSharp_002Edll_Excuted;
    public ECartelStatus Status { get; private set; }
    public int HoursSinceStatusChange { get; private set; } = 9999;
    public string SaveFolderName => "Cartel";
    public string SaveFileName => "Cartel";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder { get; } = 10;

    protected override void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    private void HourPass();
    public virtual void InitializeSaveable();
    public virtual string GetSaveString();
    public void Load(CartelData data);
    [ServerRpc(RequireOwnership = false)]
    public void SetStatus_Server(ECartelStatus status, bool resetStatusChangedTimer);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SetStatus(NetworkConnection conn, ECartelStatus newStatus, bool resetStatusChangeTimer);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetStatus_Server_2366206100(ECartelStatus status, bool resetStatusChangedTimer);
    public void RpcLogic___SetStatus_Server_2366206100(ECartelStatus status, bool resetStatusChangedTimer);
    private void RpcReader___Server_SetStatus_Server_2366206100(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetStatus_3666943613(NetworkConnection conn, ECartelStatus newStatus, bool resetStatusChangeTimer);
    public void RpcLogic___SetStatus_3666943613(NetworkConnection conn, ECartelStatus newStatus, bool resetStatusChangeTimer);
    private void RpcReader___Observers_SetStatus_3666943613(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetStatus_3666943613(NetworkConnection conn, ECartelStatus newStatus, bool resetStatusChangeTimer);
    private void RpcReader___Target_SetStatus_3666943613(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}