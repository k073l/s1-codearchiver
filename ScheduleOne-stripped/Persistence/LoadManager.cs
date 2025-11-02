using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AeLa.EasyFeedback;
using FishNet;
using FishNet.Component.Scenes;
using FishNet.Transporting;
using FishNet.Transporting.Multipass;
using FishNet.Transporting.Tugboat;
using FishNet.Transporting.Yak;
using FishySteamworks;
using Pathfinding;
using ScheduleOne.Audio;
using ScheduleOne.AvatarFramework.Animation;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.Money;
using ScheduleOne.Networking;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.ItemLoaders;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Property;
using ScheduleOne.Quests;
using ScheduleOne.UI;
using ScheduleOne.UI.MainMenu;
using ScheduleOne.UI.Phone;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace ScheduleOne.Persistence;
public class LoadManager : PersistentSingleton<LoadManager>
{
    public enum ELoadStatus
    {
        None,
        LoadingScene,
        Initializing,
        LoadingData,
        SpawningPlayer,
        WaitingForHost
    }

    public const int LOADS_PER_FRAME;
    public const bool DEBUG;
    public const float LOAD_ERROR_TIMEOUT;
    public const float NETWORK_TIMEOUT;
    public static List<string> LoadHistory;
    public static SaveInfo[] SaveGames;
    public static SaveInfo LastPlayedGame;
    private List<LoadRequest> loadRequests;
    public List<ItemLoader> ItemLoaders;
    public List<BuildableItemLoader> ObjectLoaders;
    public List<LegacyNPCLoader> LegacyNPCLoaders;
    public List<NPCLoader> NPCLoaders;
    public UnityEvent onPreSceneChange;
    public UnityEvent onPreLoad;
    public UnityEvent onLoadComplete;
    public UnityEvent onSaveInfoLoaded;
    private List<IStaggeredReplicator> staggeredReplicators;
    public string DefaultTutorialSaveFolder => Path.Combine(Application.streamingAssetsPath, "DefaultTutorialSave");
    public bool IsGameLoaded { get; protected set; }
    public bool IsLoading { get; protected set; }
    public float TimeSinceGameLoaded { get; protected set; }
    public bool DebugMode { get; protected set; }
    public ELoadStatus LoadStatus { get; protected set; }
    public string LoadedGameFolderPath { get; protected set; } = string.Empty;
    public SaveInfo ActiveSaveInfo { get; private set; }
    public SaveInfo StoredSaveInfo { get; private set; }

    protected override void Awake();
    protected override void Start();
    private void Bananas();
    private void InitializeItemLoaders();
    private void InitializeObjectLoaders();
    private void InitializeNPCLoaders();
    public void Update();
    public void QueueLoadRequest(LoadRequest request);
    public void DequeueLoadRequest(LoadRequest request);
    public ItemLoader GetItemLoader(string itemType);
    public BuildableItemLoader GetObjectLoader(string objectType);
    public LegacyNPCLoader GetLegacyNPCLoader(string npcType);
    public NPCLoader GetNPCLoader(string npcType);
    public string GetLoadStatusText();
    public void StartGame(SaveInfo info, bool allowLoadStacking = false, bool allowSaveBackup = true);
    public void LoadTutorialAsClient();
    public void LoadAsClient(string steamId64);
    private void StartLoadErrorAutosubmit();
    public void SetWaitingForHostLoad();
    public void LoadLastSave();
    private void CleanUp();
    public void ExitToMenu(SaveInfo autoLoadSave = null, MainMenuPopup.Data mainMenuPopup = null, bool preventLeaveLobby = false);
    public static bool TryLoadSaveInfo(string saveFolderPath, int saveSlotIndex, out SaveInfo saveInfo, bool requireGameFile = false);
    public void RefreshSaveInfo();
    public void AddStaggeredReplicator(IStaggeredReplicator replicator);
}