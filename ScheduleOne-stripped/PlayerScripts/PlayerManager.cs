using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using Steamworks;
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

    protected override void Awake();
    public virtual void InitializeSaveable();
    public virtual string GetSaveString();
    public virtual List<string> WriteData(string parentFolderPath);
    public void SavePlayer(Player player);
    public void LoadPlayer(PlayerData data, string containerPath);
    public void AllPlayerFilesLoaded();
    public bool TryGetPlayerData(string playerCode, out PlayerData data, out string inventoryString, out string appearanceString, out string clothingString, out VariableData[] variables);
}