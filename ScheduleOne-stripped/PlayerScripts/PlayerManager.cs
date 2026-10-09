using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FishNet.Connection;
using ScheduleOne.Avatar.Player;
using ScheduleOne.Avatar.Tools;
using ScheduleOne.AvatarFramework.Customization;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using Unity.AI.Navigation;
using UnityEngine;

namespace ScheduleOne.PlayerScripts;
public class PlayerManager : Singleton<PlayerManager>, IBaseSaveable, ISaveable
{
    private PlayersLoader loader;
    public NavMeshSurface PlayerRecoverySurface;
    protected List<PlayerData> loadedPlayerData;
    protected List<string> loadedPlayerDataPaths;
    protected List<string> loadedPlayerFileNames;
    private bool _playersDataLoaded;
    public string SaveFolderName => "Players";
    public string SaveFileName => "Players";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => true;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder { get; }
    private static List<Player> _playerList => Player.PlayerList;

    protected override void Awake();
    public virtual void InitializeSaveable();
    public virtual string GetSaveString();
    public virtual List<string> WriteData(string parentFolderPath);
    public void SavePlayer(Player player);
    public void StorePlayerData(PlayerData data, string containerPath);
    public void SetAllPlayerDatasLoaded();
    public void TryGetPlayerData(string playerCode, bool isHost, Action<FullPlayerData> onSuccess, Action onFailure);
    private bool TryGetPlayerData(string playerCode, bool isHost, out FullPlayerData data);
    public static Player GetPlayer(NetworkConnection conn);
    public static Player GetRandomPlayer(bool excludeArrestedOrDead = true, bool excludeSleeping = true);
    public static Player GetPlayer(string playerCode);
    public static Player GetPlayerByName(string playerName);
    public static Player GetClosestPlayer(Vector3 point, out float distance, List<Player> exclude = null);
    public static Player GetClosestPlayer(Vector3 point, out float distance, Player exclude);
    public static Player GetClosestPlayerSqr(Vector3 point, out float sqrDistance, List<Player> exclude = null);
    public static bool AreAllPlayersReadyToSleep();
}