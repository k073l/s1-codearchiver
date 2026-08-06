using System;
using System.Collections;
using System.Threading.Tasks;
using ScheduleOne.DevUtilities;
using Steamworks;
using UnityEngine;

namespace ScheduleOne.Platform;
public static class PlatformAuth
{
    public enum EAuthState
    {
        NotRequested,
        Pending,
        Ready,
        Failed
    }

    private const float AuthRequestTimeoutSeconds;
    private static EAuthState _authState;
    private const int AuthTicketBufferSize;
    private static string _appTicket;
    private static CallResult<EncryptedAppTicketResponse_t> appTicketCallbackResponse;
    private static TaskCompletionSource<string> _tokenCompletion;
    private static HAuthTicket _currentAuthTicket;
    public static EAuthState AuthState { get; private set; }

    public static void PrepareAuth();
    public static string GetAuthToken();
    private static async Task InitSteamAppTicket();
    private static void OnEncryptedAppTicketResponse(EncryptedAppTicketResponse_t response, bool ioFailure);
    private static Task<string> GetAppTicket();
    private static string CleanTicket(string ticket);
    public static bool GetAuthSessionTicket(CSteamID recipientSteamId, out SteamSessionAuthTicket result);
    public static void CancelCurrentAuthSessionTicket();
    public static EBeginAuthSessionResult BeginAuthSession(SteamSessionAuthTicket ticket);
    public static void EndAuthSession(CSteamID steamID);
}