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
using ScheduleOne.Map;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Levelling;
public class LevelManager : NetworkSingleton<LevelManager>, IBaseSaveable, ISaveable
{
    public const int TIERS_PER_RANK;
    public const int XP_PER_TIER_MIN;
    public const int XP_PER_TIER_MAX;
    private int rankCount;
    public Action<FullRank, FullRank> onRankUp;
    public Action<FullRank, FullRank> onRankChanged;
    public Dictionary<FullRank, List<Unlockable>> Unlockables;
    private RankLoader loader;
    private bool NetworkInitialize___EarlyScheduleOne_002ELevelling_002ELevelManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ELevelling_002ELevelManagerAssembly_002DCSharp_002Edll_Excuted;
    public ERank Rank { get; private set; }
    public int Tier { get; private set; } = 1;
    public int XP { get; private set; }
    public int TotalXP { get; private set; }
    public float XPToNextTier => Mathf.Round(Mathf.Lerp(200f, 2500f, (float)Rank / (float)rankCount) / 25f) * 25f;
    public string SaveFolderName => "Rank";
    public string SaveFileName => "Rank";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder { get; }

    public override void Awake();
    protected override void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    public virtual void InitializeSaveable();
    [ServerRpc(RequireOwnership = false)]
    public void AddXP(int xp);
    [ObserversRpc]
    private void AddXPLocal(int xp);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SetData(NetworkConnection conn, ERank rank, int tier, int xp, int totalXp);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SetUnlockedRegions(NetworkConnection conn, List<EMapRegion> unlockedRegions);
    [ObserversRpc]
    private void IncreaseTierNetworked(FullRank before, FullRank after);
    private void IncreaseTier();
    public virtual string GetSaveString();
    public FullRank GetFullRank();
    public void AddUnlockable(Unlockable unlockable);
    public int GetTotalXPForRank(FullRank fullrank);
    public FullRank GetFullRank(int totalXp);
    public int GetXPForTier(ERank rank);
    public static float GetOrderLimitMultiplier(FullRank rank);
    private static float GetRankOrderLimitMultiplier(ERank rank);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_AddXP_3316948804(int xp);
    public void RpcLogic___AddXP_3316948804(int xp);
    private void RpcReader___Server_AddXP_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_AddXPLocal_3316948804(int xp);
    private void RpcLogic___AddXPLocal_3316948804(int xp);
    private void RpcReader___Observers_AddXPLocal_3316948804(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetData_20965027(NetworkConnection conn, ERank rank, int tier, int xp, int totalXp);
    public void RpcLogic___SetData_20965027(NetworkConnection conn, ERank rank, int tier, int xp, int totalXp);
    private void RpcReader___Observers_SetData_20965027(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetData_20965027(NetworkConnection conn, ERank rank, int tier, int xp, int totalXp);
    private void RpcReader___Target_SetData_20965027(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetUnlockedRegions_563230222(NetworkConnection conn, List<EMapRegion> unlockedRegions);
    public void RpcLogic___SetUnlockedRegions_563230222(NetworkConnection conn, List<EMapRegion> unlockedRegions);
    private void RpcReader___Observers_SetUnlockedRegions_563230222(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetUnlockedRegions_563230222(NetworkConnection conn, List<EMapRegion> unlockedRegions);
    private void RpcReader___Target_SetUnlockedRegions_563230222(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_IncreaseTierNetworked_3953286437(FullRank before, FullRank after);
    private void RpcLogic___IncreaseTierNetworked_3953286437(FullRank before, FullRank after);
    private void RpcReader___Observers_IncreaseTierNetworked_3953286437(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002ELevelling_002ELevelManager_Assembly_002DCSharp_002Edll();
}