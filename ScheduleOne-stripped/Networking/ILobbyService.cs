using System;
using System.Collections.Generic;

namespace ScheduleOne.Networking;
public interface ILobbyService
{
    bool IsInLobby { get; }

    bool IsHost { get; }

    int PlayerCount { get; }

    event Action OnLobbyChanged;
    event Action<string> OnLobbyMessage;
    void Initialize();
    void CreateLobby(int maxPlayers);
    void JoinLobby(string lobbyId);
    void LeaveLobby();
    void OpenInviteUI();
    void SendMessage(string message);
    void SetLobbyData(string key, string value);
    string GetLobbyData(string key);
    List<string> GetPlayerIds();
    string GetSessionConnectionIdentifier();
}