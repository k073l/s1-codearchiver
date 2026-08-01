using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Networking;
public class Lobby : PersistentSingleton<Lobby>
{
    public const int PlayerLimit;
    public const string JoinReadyMessage;
    public const string LoadTutorialMessage;
    public const string HostLoadingMessage;
    private ILobbyService _lobbyService;
    public bool IsHost { get; }
    public ulong LobbyID { get; private set; }
    public bool IsInLobby { get; }
    public int PlayerCount { get; }

    public event Action OnLobbyChange;
    protected override void Awake();
    protected override void Start();
    private void CreateLobbyService();
    public void TryOpenInviteInterface();
    public void CreateLobby();
    public void LeaveLobby();
    private string GetLaunchLobby();
    public List<string> GetLobbyMemberIDs();
    public void SendLobbyMessage(string message);
    public void SetLobbyData(string key, string value);
    public bool IsSessionReadyForClient();
    public string GetSessionConnectionIdentifier();
}