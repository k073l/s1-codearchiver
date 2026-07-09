using System;
using System.Collections.Generic;

namespace ScheduleOne.Networking;
public class MockLobbyService : ILobbyService
{
    public bool IsHost => true;
    public bool IsInLobby => false;
    public int PlayerCount => 1;

    public event Action OnLobbyChanged;
    public event Action<string> OnLobbyMessage;
    public void Initialize();
    public void CreateLobby(int maxPlayers);
    public void JoinLobby(string lobbyID);
    public void LeaveLobby();
    public void SetLobbyData(string key, string value);
    public string GetLobbyData(string key);
    public List<string> GetPlayerIds();
    public void SendMessage(string message);
    public void OpenInviteUI();
    public void CloseInviteUI();
    public void OnLobbyMessageReceived(string message);
    public string GetSessionConnectionIdentifier();
}