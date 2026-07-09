using System;
using System.Collections;
using ScheduleOne.Platform;
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

    private const string ServerUrl;
    private PollResponse _receivedPollResponse;
    [Header("Debug")]
    [SerializeField]
    private bool loadDebugData;
    [TextArea(10, 30)]
    [SerializeField]
    private string debugData;
    public PollData ActivePoll { get; private set; }
    public PollData ConfirmedPoll { get; private set; }
    public EPollSubmissionResult SubmissionResult { get; private set; }
    public string SubmisssionFailedMesssage { get; private set; } = string.Empty;

    public event Action<PollData> onActivePollReceived;
    public event Action<PollData> onConfirmedPollReceived;
    private void Start();
    private bool PlatformInitialized();
    public void SelectPollResponse(int responseIndex);
    public static bool TryGetExistingPollResponse(int pollId, out int response);
    private IEnumerator SubmitAnswerToServer(PollAnswer answer);
    private IEnumerator RequestPoll(string url, Action<string> callback = null);
    private void ResponseCallback(string data);
    private static string CleanTicket(string ticket);
    private static void RecordSubmission(int pollId, int response);
}