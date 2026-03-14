using System;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.Cartel;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.Levelling;
using ScheduleOne.Map;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Graffiti;
public class WorldSpraySurface : SpraySurface, IGUIDRegisterable
{
    public const int RemoveCartelGraffitiXP;
    private const float RemoveCartelGraffitiInfluenceChange;
    private const float CartelInfluenceChange;
    [Header("Settings")]
    public string BakedGUID;
    [SerializeField]
    private float StandPointWallOffset;
    private bool NetworkInitialize___EarlyScheduleOne_002EGraffiti_002EWorldSpraySurfaceAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EGraffiti_002EWorldSpraySurfaceAssembly_002DCSharp_002Edll_Excuted;
    public Guid GUID { get; protected set; }
    public EMapRegion Region { get; private set; }
    public bool HasEverBeenMarkedByPlayer { get; private set; }

    [field: SerializeField]
    public Transform NPCStandPoint { get; private set; }

    [field: SerializeField]
    public bool CanBeSprayedByNPCs { get; private set; } = true;

    public override void Awake();
    private void Start();
    private void OnDrawGizmos();
    public override void OnEditingFinished();
    public override void CleanGraffiti();
    private void Reward();
    public override void ReplicateTo(NetworkConnection conn);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void Set(NetworkConnection conn, SprayStroke[] strokes, bool hasBeenFinalized, bool isCartelGraffiti);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void MarkDrawingFinalized();
    [ObserversRpc(RunLocally = true)]
    private void SetFinalized();
    public override bool ShouldSave();
    public void SetGUID(Guid guid);
    [Button]
    public void RegenerateGUID();
    [Button]
    private void GroundNPCStandPoint();
    public new WorldSpraySurfaceData GetSaveData();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_Set_3759704962(NetworkConnection conn, SprayStroke[] strokes, bool hasBeenFinalized, bool isCartelGraffiti);
    public void RpcLogic___Set_3759704962(NetworkConnection conn, SprayStroke[] strokes, bool hasBeenFinalized, bool isCartelGraffiti);
    private void RpcReader___Observers_Set_3759704962(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Set_3759704962(NetworkConnection conn, SprayStroke[] strokes, bool hasBeenFinalized, bool isCartelGraffiti);
    private void RpcReader___Target_Set_3759704962(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_MarkDrawingFinalized_2166136261();
    public void RpcLogic___MarkDrawingFinalized_2166136261();
    private void RpcReader___Server_MarkDrawingFinalized_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetFinalized_2166136261();
    private void RpcLogic___SetFinalized_2166136261();
    private void RpcReader___Observers_SetFinalized_2166136261(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002EGraffiti_002EWorldSpraySurface_Assembly_002DCSharp_002Edll();
}