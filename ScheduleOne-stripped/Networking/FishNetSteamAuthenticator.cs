using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Authenticating;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Transporting;
using ScheduleOne.Platform;
using Steamworks;
using UnityEngine;

namespace ScheduleOne.Networking;
internal sealed class FishNetSteamAuthenticator : HostAuthenticator
{
    public enum ESteamAuthMode
    {
        Anyone,
        FriendOfHost,
        FriendOfAnyExistingPlayer
    }

    private const float FriendCheckTimeout;
    private ESteamAuthMode _authMode;
    private Dictionary<NetworkConnection, CSteamID> _authenticatedConnections;
    public override event Action<NetworkConnection, bool> OnAuthenticationResult;
    public event Action<bool> OnLocalAuthenticationResult;
    public void SetAuthMode(ESteamAuthMode mode);
    public override void InitializeOnce(NetworkManager networkManager);
    protected override void OnDestroy();
    private unsafe void ClientManager_OnClientConnectionState(ClientConnectionStateArgs args);
    private unsafe void ServerManager_OnRemoteConnectionState(NetworkConnection conn, RemoteConnectionStateArgs args);
    private unsafe void OnSteamAuthBroadcast(NetworkConnection conn, SteamSessionAuthTicket auth);
    private void IsSteamUserPermittedToJoinSession(CSteamID steamId, Action<bool> result);
    private void OnResponseBroadcast(ResponseBroadcast rb);
    private void SendAuthenticationResponse(NetworkConnection conn, bool authenticated);
    protected override void OnHostAuthenticationResult(NetworkConnection conn, bool authenticated);
    private void OnFriendCheckRequested(CheckIfUserIsFriendBroadcast friend);
}