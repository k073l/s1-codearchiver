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
    private static string _appTicket;
    private static CallResult<EncryptedAppTicketResponse_t> appTicketCallbackResponse;
    private static TaskCompletionSource<string> _tokenCompletion;
    public static EAuthState AuthState { get; private set; }

    public static void PrepareAuth();
    public static string GetAuthToken();
    private static async Task InitSteamAppTicket();
    private static void OnEncryptedAppTicketResponse(EncryptedAppTicketResponse_t response, bool ioFailure);
    private static Task<string> GetAppTicket();
    private static string CleanTicket(string ticket);
}