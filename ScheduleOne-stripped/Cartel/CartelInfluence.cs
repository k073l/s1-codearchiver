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
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Cartel;
public class CartelInfluence : NetworkBehaviour
{
    [Serializable]
    public class RegionInfluenceData
    {
        private string name;
        public EMapRegion Region;
        [Range(0f, 1f)]
        public float Influence;
        public RegionInfluenceData(EMapRegion region, float influence = 0f);
    }

    public const float INFLUENCE_TO_UNLOCK_NEXT_REGION;
    [Header("Settings")]
    public RegionInfluenceData[] DefaultRegionInfluence;
    private List<RegionInfluenceData> regionInfluence;
    public Action<EMapRegion, float, float> OnInfluenceChanged;
    private bool NetworkInitialize___EarlyScheduleOne_002ECartel_002ECartelInfluenceAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ECartel_002ECartelInfluenceAssembly_002DCSharp_002Edll_Excuted;
    public RegionInfluenceData[] GetAllRegionInfluence();
    public override void Awake();
    private void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    protected override void OnValidate();
    public void ChangeInfluence(EMapRegion region, float amount);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SetInfluence(NetworkConnection conn, EMapRegion region, float influence);
    public float GetInfluence(EMapRegion region);
    private void OnSleepEnd();
    [ObserversRpc(RunLocally = true)]
    private void ChangeInfluence(EMapRegion region, float oldInfluence, float newInfluence);
    private RegionInfluenceData GetRegionData(EMapRegion region);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_SetInfluence_2071772313(NetworkConnection conn, EMapRegion region, float influence);
    public void RpcLogic___SetInfluence_2071772313(NetworkConnection conn, EMapRegion region, float influence);
    private void RpcReader___Observers_SetInfluence_2071772313(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetInfluence_2071772313(NetworkConnection conn, EMapRegion region, float influence);
    private void RpcReader___Target_SetInfluence_2071772313(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ChangeInfluence_1267088319(EMapRegion region, float oldInfluence, float newInfluence);
    private void RpcLogic___ChangeInfluence_1267088319(EMapRegion region, float oldInfluence, float newInfluence);
    private void RpcReader___Observers_ChangeInfluence_1267088319(PooledReader PooledReader0, Channel channel);
    private void Awake_UserLogic_ScheduleOne_002ECartel_002ECartelInfluence_Assembly_002DCSharp_002Edll();
}