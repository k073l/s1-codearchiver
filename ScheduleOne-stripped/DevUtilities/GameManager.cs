using System.Collections.Generic;
using EasyButtons;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.Networking;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;
using UnityEngine.CrashReportHandler;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace ScheduleOne.DevUtilities;
public class GameManager : NetworkSingleton<GameManager>, IBaseSaveable, ISaveable
{
    public const bool IS_DEMO;
    public static bool IS_BETA;
    [SerializeField]
    private int seed;
    public string OrganisationName;
    public GameSettings Settings;
    public Transform SpawnPoint;
    public Transform NoHomeRespawnPoint;
    public Transform Temp;
    public UnityEvent onSettingsLoaded;
    private GameDataLoader loader;
    private bool NetworkInitialize___EarlyScheduleOne_002EDevUtilities_002EGameManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EDevUtilities_002EGameManagerAssembly_002DCSharp_002Edll_Excuted;
    public static bool IS_TUTORIAL { get; }
    public static int Seed { get; }
    public Sprite OrganisationLogo { get; protected set; }
    public bool IsTutorial { get; }
    public string SaveFolderName => "Game";
    public string SaveFileName => "Game";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>
    {
        "Logo.png"
    };
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder { get; }

    public override void Awake();
    protected override void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    [TargetRpc]
    public void SetGameData(NetworkConnection conn, GameData data);
    public virtual void InitializeSaveable();
    public virtual string GetSaveString();
    public void Load(GameData data, string path);
    [Button]
    public void EndTutorial(bool natural);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Target_SetGameData_3076874643(NetworkConnection conn, GameData data);
    public void RpcLogic___SetGameData_3076874643(NetworkConnection conn, GameData data);
    private void RpcReader___Target_SetGameData_3076874643(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002EDevUtilities_002EGameManager_Assembly_002DCSharp_002Edll();
}