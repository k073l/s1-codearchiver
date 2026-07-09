using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.UI;
using ScheduleOne.UI.MainMenu;
using Steamworks;
using UnityEngine;

namespace ScheduleOne.Networking;
public class SteamLobbyService : ILobbyService
{
    private CSteamID[] _players;
    private Callback<LobbyCreated_t> _lobbyCreatedCallback;
    private Callback<LobbyEnter_t> _lobbyEnteredCallback;
    private Callback<LobbyChatUpdate_t> _chatUpdateCallback;
    private Callback<GameLobbyJoinRequested_t> _gameLobbyJoinRequestedCallback;
    private Callback<LobbyChatMsg_t> _lobbyChatMessageCallback;
    public bool IsInLobby => _lobbyID != 0;
    public bool IsHost { get; }
    public int PlayerCount { get; }
    private ulong _lobbyID { get; set; }
    private CSteamID _lobbySteamID => new CSteamID(_lobbyID);
    private CSteamID _localPlayerID { get; set; } = CSteamID.Nil;

    public event Action OnLobbyChanged;
    public event Action<string> OnLobbyMessage;
    public void Initialize();
    public void CreateLobby(int maxPlayers);
    public void JoinLobby(string lobbyId);
    public void LeaveLobby();
    public void SetLobbyData(string key, string value);
    public string GetLobbyData(string key);
    private void UpdateLobbyMembers();
    public void JoinAsClient(string steamId64);
    public void SendMessage(string message);
    public void OpenInviteUI();
    public List<string> GetPlayerIds();
    public string GetSessionConnectionIdentifier();
    private unsafe void OnLobbyCreated(LobbyCreated_t result);
    private void OnLobbyEntered(LobbyEnter_t result);
    private void PlayerEnterOrLeave(LobbyChatUpdate_t result);
    private unsafe void LobbyJoinRequested(GameLobbyJoinRequested_t result);
    private void OnLobbyChatMessage(LobbyChatMsg_t result);
}