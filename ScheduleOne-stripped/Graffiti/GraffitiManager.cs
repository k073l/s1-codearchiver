using System;
using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.Levelling;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Graffiti;
public class GraffitiManager : NetworkSingleton<GraffitiManager>, IBaseSaveable, ISaveable
{
    private const string SPRAY_PAINT_STOCK_VARIABLE;
    private const string SPRAY_PAINTS_PURCHASED_VARIABLE;
    private GraffitiLoader loader;
    private List<Tuple<SpraySurface, NetworkConnection>> surfaceReplicationQueue;
    private float timeUntilNextReplication;
    private bool NetworkInitialize___EarlyScheduleOne_002EGraffiti_002EGraffitiManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EGraffiti_002EGraffitiManagerAssembly_002DCSharp_002Edll_Excuted;
    public List<SpraySurface> SpraySurfaces { get; private set; } = new List<SpraySurface>();
    public string SaveFolderName => "Graffiti";
    public string SaveFileName => "Graffiti";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; } = true;
    public int LoadOrder { get; }

    public override void Awake();
    public override void OnStartServer();
    private void Update();
    public virtual void InitializeSaveable();
    private void SprayPaintPurchaseCountChanged(float newValue);
    private void RankChange(FullRank oldRank, FullRank newRank);
    private void UpdateSprayPaintStockVariable();
    public virtual string GetSaveString();
    public void QueueSurfaceToReplicate(SpraySurface surface, NetworkConnection conn);
    public void RemoveFromReplicationQueueIfPresent(SpraySurface surface);
    private void ReplicateSurface();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002EGraffiti_002EGraffitiManager_Assembly_002DCSharp_002Edll();
}