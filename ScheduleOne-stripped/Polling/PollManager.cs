using System;
using System.Collections;
using System.Threading.Tasks;
using Steamworks;
using UnityEngine;
using UnityEngine.Networking;

namespace ScheduleOne.Polling;
public class PollManager : MonoBehaviour
{
    public enum EPollSubmissionResult
    {
        InProgress,
        Success,
        Failed
    }

    public const string SERVER_URL;
    private CallResult<EncryptedAppTicketResponse_t> appTicketCallbackResponse;
    private TaskCompletionSource<string> tokenCompletion;
    private PollResponse receivedPollResponse;
    private int sentResponse;
    private string appTicket;
    public Action<PollData> onActivePollReceived;
    public Action<PollData> onConfirmedPollReceived;
    private bool appTicketRequested;
    public PollData ActivePoll { get; private set; }
    public PollData ConfirmedPoll { get; private set; }
    public EPollSubmissionResult SubmissionResult { get; private set; }
    public string SubmisssionFailedMesssage { get; private set; } = string.Empty;

    private void Start();
    private void Update();
    public void GenerateAppTicket();
    public void SelectPollResponse(int responseIndex);
    private async Task InitAppTicket();
    private IEnumerator SubmitAnswerToServer(PollAnswer answer);
    private IEnumerator RequestPoll(string url, Action<string> callback = null);
    private void ResponseCallback(string data);
    private void OnEncryptedAppTicketResponse(EncryptedAppTicketResponse_t response, bool ioFailure);
    private Task<string> GetAppTicket();
    private static string CleanTicket(string ticket);
    public static bool TryGetExistingPollResponse(int pollId, out int response);
    private static void RecordSubmission(int pollId, int response);
}