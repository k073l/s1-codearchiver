using System;
using System.Linq;
using System.Text;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.UI;
using ScheduleOne.UI.MainMenu;
using Steamworks;
using UnityEngine;

namespace ScheduleOne.Networking;
public class Lobby : PersistentSingleton<Lobby>
{
    public const bool ENABLED;
    public const int PLAYER_LIMIT;
    public const string JOIN_READY;
    public const string LOAD_TUTORIAL;
    public const string HOST_LOADING;
    public CSteamID[] Players;
    public Action onLobbyChange;
    private Callback<LobbyCreated_t> LobbyCreatedCallback;
    private Callback<LobbyEnter_t> LobbyEnteredCallback;
    private Callback<LobbyChatUpdate_t> ChatUpdateCallback;
    private Callback<GameLobbyJoinRequested_t> GameLobbyJoinRequestedCallback;
    private Callback<LobbyChatMsg_t> LobbyChatMessageCallback;
    public bool IsHost { get; }
    public ulong LobbyID { get; private set; }
    public CSteamID LobbySteamID => new CSteamID(LobbyID);
    public bool IsInLobby => LobbyID != 0;
    public int PlayerCount { get; }
    public CSteamID LocalPlayerID { get; private set; } = CSteamID.Nil;

    protected override void Awake();
    protected override void Start();
    private void InitializeCallbacks();
    public void TryOpenInviteInterface();
    public void LeaveLobby();
    private void CreateLobby();
    private string GetLaunchLobby();
    private void UpdateLobbyMembers();
    public void JoinAsClient(string steamId64);
    public void SendLobbyMessage(string message);
    public void SetLobbyData(string key, string value);
    private unsafe void OnLobbyCreated(LobbyCreated_t result);
    private void OnLobbyEntered(LobbyEnter_t result);
    private void PlayerEnterOrLeave(LobbyChatUpdate_t result);
    private unsafe void LobbyJoinRequested(GameLobbyJoinRequested_t result);
    private void OnLobbyChatMessage(LobbyChatMsg_t result);
}