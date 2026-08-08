using System;
using System.Security.Cryptography;
using System.Text;
using FishNet.Authenticating;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Transporting;
using UnityEngine;

namespace ScheduleOne.Networking;
public abstract class HostAuthenticator : Authenticator
{
    private static string _hostHash;
    private bool _allowHostAuthentication;
    public override void InitializeOnce(NetworkManager networkManager);
    protected virtual void OnDestroy();
    private void ServerManager_OnServerConnectionState(ServerConnectionStateArgs obj);
    private void OnHostPasswordBroadcast(NetworkConnection conn, HostPasswordBroadcast hpb);
    protected abstract void OnHostAuthenticationResult(NetworkConnection conn, bool authenticated);
    private void SetHostHash(int length);
    protected bool AuthenticateAsHost();
}