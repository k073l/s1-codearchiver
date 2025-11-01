using System;
using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.CharacterClasses;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.PlayerScripts;
using ScheduleOne.VoiceOver;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Map;
public class SewerManager : NetworkSingleton<SewerManager>, IBaseSaveable, ISaveable
{
    [Serializable]
    public class KeyPossessor
    {
        public NPC NPC;
        [Tooltip("Description of the NPC for Oscar's key location dialogue.")]
        public string NPCDescription;
    }

    public ItemDefinition SewerKeyItem;
    public AudioSourceController SewerUnlockSound;
    public ItemPickup RandomWorldSewerKeyPickup;
    public Transform[] RandomSewerKeyLocations;
    public SewerKing SewerKingNPC;
    public SewerGoblin SewerGoblinNPC;
    public KeyPossessor[] SewerKeyPossessors;
    private SewerLoader loader;
    private bool NetworkInitialize___EarlyScheduleOne_002EMap_002ESewerManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EMap_002ESewerManagerAssembly_002DCSharp_002Edll_Excuted;
    public bool IsSewerUnlocked { get; private set; }
    public bool IsRandomWorldKeyCollected { get; private set; }
    public int RandomSewerKeyLocationIndex { get; set; } = -1;
    public bool HasSewerKingBeenDefeated { get; private set; }
    public int RandomSewerPossessorIndex { get; set; } = -1;
    public string SaveFolderName => "Sewer";
    public string SaveFileName => "Sewer";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder { get; }

    public override void Awake();
    protected override void Start();
    public virtual void InitializeSaveable();
    public override void OnSpawnServer(NetworkConnection connection);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetSewerUnlocked_Server();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetSewerUnlocked_Client(NetworkConnection conn);
    public void SetRandomWorldKeyCollected();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    private void SetRandomKeyCollected_Server();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetRandomKeyCollected_Client(NetworkConnection conn);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetSewerKeyLocation(NetworkConnection conn, int locationIndex);
    private void SewerKingDefeated();
    [ObserversRpc]
    [TargetRpc]
    private void DisableSewerKing(NetworkConnection conn);
    public List<Player> GetPlayersInSewer();
    public virtual string GetSaveString();
    public void Load(SewerData sewerData);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetRandomKeyPossessor(NetworkConnection conn, int possessorIndex);
    private void AskedAboutSewerKey();
    private void EnsureKeyPosessorHasKey();
    public KeyPossessor GetSewerKeyPossessor();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetSewerUnlocked_Server_2166136261();
    public void RpcLogic___SetSewerUnlocked_Server_2166136261();
    private void RpcReader___Server_SetSewerUnlocked_Server_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetSewerUnlocked_Client_328543758(NetworkConnection conn);
    private void RpcLogic___SetSewerUnlocked_Client_328543758(NetworkConnection conn);
    private void RpcReader___Observers_SetSewerUnlocked_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetSewerUnlocked_Client_328543758(NetworkConnection conn);
    private void RpcReader___Target_SetSewerUnlocked_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetRandomKeyCollected_Server_2166136261();
    private void RpcLogic___SetRandomKeyCollected_Server_2166136261();
    private void RpcReader___Server_SetRandomKeyCollected_Server_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetRandomKeyCollected_Client_328543758(NetworkConnection conn);
    private void RpcLogic___SetRandomKeyCollected_Client_328543758(NetworkConnection conn);
    private void RpcReader___Observers_SetRandomKeyCollected_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetRandomKeyCollected_Client_328543758(NetworkConnection conn);
    private void RpcReader___Target_SetRandomKeyCollected_Client_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetSewerKeyLocation_2681120339(NetworkConnection conn, int locationIndex);
    private void RpcLogic___SetSewerKeyLocation_2681120339(NetworkConnection conn, int locationIndex);
    private void RpcReader___Observers_SetSewerKeyLocation_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetSewerKeyLocation_2681120339(NetworkConnection conn, int locationIndex);
    private void RpcReader___Target_SetSewerKeyLocation_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_DisableSewerKing_328543758(NetworkConnection conn);
    private void RpcLogic___DisableSewerKing_328543758(NetworkConnection conn);
    private void RpcReader___Observers_DisableSewerKing_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_DisableSewerKing_328543758(NetworkConnection conn);
    private void RpcReader___Target_DisableSewerKing_328543758(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetRandomKeyPossessor_2681120339(NetworkConnection conn, int possessorIndex);
    private void RpcLogic___SetRandomKeyPossessor_2681120339(NetworkConnection conn, int possessorIndex);
    private void RpcReader___Observers_SetRandomKeyPossessor_2681120339(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetRandomKeyPossessor_2681120339(NetworkConnection conn, int possessorIndex);
    private void RpcReader___Target_SetRandomKeyPossessor_2681120339(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002EMap_002ESewerManager_Assembly_002DCSharp_002Edll();
}