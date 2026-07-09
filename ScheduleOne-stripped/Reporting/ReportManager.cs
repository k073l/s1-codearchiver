using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using Newtonsoft.Json;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.Platform;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace ScheduleOne.Reporting;
public static class ReportManager
{
    public enum ESubmissionStage
    {
        Authenticating,
        SubmittingReport,
        UploadingAttachments
    }

    private const string ServerUrl;
    private const float SubmissionCooldownSeconds;
    private static bool _submissionInProgress;
    private static float _timeOnLastSubmissionCompletion;
    private static Action<bool, string> _pendingCallback;
    private static bool _screenshotInProgress;
    private static byte[] _screenshotBytes;
    public static bool IsSubmittingReport => _submissionInProgress;
    public static bool IsOnSubmissionCooldown => Time.unscaledTime - _timeOnLastSubmissionCompletion < 10f;
    public static ESubmissionStage CurrentSubmissionStage { get; private set; } = ESubmissionStage.Authenticating;

    public static bool CanSubmitReport(out string reason);
    public static void SubmitReport(string title, string description, ReportTag[] tags, Dictionary<string, string> metadata, bool includeScreenshot, bool includeSaveFile, Action<bool, string> callback);
    private static byte[] GetSaveGameBytes();
    public static void PrepareScreenshot();
    private static IEnumerator UploadAttachments(ReportResponseData responseData, byte[] screenshot, byte[] savedGame);
    private static IEnumerator UploadBytes(string signedUrl, byte[] bytes);
    private static string GetAdditionalInfo();
}