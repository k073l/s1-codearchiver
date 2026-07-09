using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FishNet;
using FishNet.Connection;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.Platform;
using Unity.AI.Navigation;
using UnityEngine;

namespace ScheduleOne.PlayerScripts;
public class PlayerManager : Singleton<PlayerManager>, IBaseSaveable, ISaveable
{
    private PlayersLoader loader;
    [SerializeField]
    protected List<PlayerData> loadedPlayerData;
    protected List<string> loadedPlayerDataPaths;
    protected List<string> loadedPlayerFileNames;
    public NavMeshSurface PlayerRecoverySurface;
    public string SaveFolderName => "Players";
    public string SaveFileName => "Players";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => true;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder { get; }
    private static List<Player> PlayerList => Player.PlayerList;

    protected override void Awake();
    public virtual void InitializeSaveable();
    public virtual string GetSaveString();
    public virtual List<string> WriteData(string parentFolderPath);
    public void SavePlayer(Player player);
    public void LoadPlayer(PlayerData data, string containerPath);
    public void AllPlayerFilesLoaded();
    public bool TryGetPlayerData(string playerCode, out PlayerData data, out string inventoryString, out string appearanceString, out string clothingString, out VariableData[] variables);
    public static Player GetPlayer(NetworkConnection conn);
    public static Player GetRandomPlayer(bool excludeArrestedOrDead = true, bool excludeSleeping = true);
    public static Player GetPlayer(string playerCode);
    public static Player GetPlayerByName(string playerName);
    public static Player GetClosestPlayer(Vector3 point, out float distance, List<Player> exclude = null);
    public static Player GetClosestPlayer(Vector3 point, out float distance, Player exclude);
    public static Player GetClosestPlayerSqr(Vector3 point, out float sqrDistance, List<Player> exclude = null);
    public static bool AreAllPlayersReadyToSleep();
}