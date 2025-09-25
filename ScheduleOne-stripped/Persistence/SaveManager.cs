using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using AeLa.EasyFeedback;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.UI;
using ScheduleOne.UI.MainMenu;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Persistence;
public class SaveManager : PersistentSingleton<SaveManager>
{
    public const string MAIN_SCENE_NAME;
    public const string MENU_SCENE_NAME;
    public const string TUTORIAL_SCENE_NAME;
    public const int SAVES_PER_FRAME;
    public const string SAVE_FILE_EXTENSION;
    public const int SAVE_SLOT_COUNT;
    public const string SAVE_GAME_PREFIX;
    public const bool DEBUG;
    public const bool PRETTY_PRINT;
    public static bool SaveError;
    public List<ISaveable> Saveables;
    public List<IBaseSaveable> BaseSaveables;
    [HideInInspector]
    public List<string> ApprovedBaseLevelPaths;
    protected List<ISaveable> CompletedSaveables;
    protected List<SaveRequest> QueuedSaveRequests;
    [Header("References")]
    public RectTransform WriteIssueDisplay;
    [Header("Events")]
    public UnityEvent onSaveStart;
    public UnityEvent onSaveComplete;
    private bool saveFolderInitialized;
    public bool AccessPermissionIssueDetected { get; protected set; }
    public bool IsSaving { get; protected set; }
    public float SecondsSinceLastSave { get; protected set; }
    public string PlayersSavePath { get; protected set; } = string.Empty;
    public string IndividualSavesContainerPath { get; protected set; } = string.Empty;
    public string BackupFolderPath => Path.Combine(IndividualSavesContainerPath, "Backups");
    public string SaveName { get; protected set; } = "DevSave";

    public static void ReportSaveError();
    protected override void Awake();
    protected override void Start();
    public void CheckSaveFolderInitialized();
    public static bool HasWritePermissionOnDir(string path);
    private void Update();
    public void DelayedSave();
    public void Save();
    public void Save(string saveFolderPath);
    private void ClearBaseLevelOutdatedSaves(string saveFolderPath);
    public void CompleteSaveable(ISaveable saveable);
    public void ClearCompletedSaveable(ISaveable saveable);
    public void CreateSaveBackup(SaveInfo saveInfo);
    public void RegisterSaveable(ISaveable saveable);
    public void QueueSaveRequest(SaveRequest request);
    public void DequeueSaveRequest(SaveRequest request);
    public static string StripExtensions(string filePath);
    public static string MakeFileSafe(string fileName);
    public static float GetVersionNumber(string version);
    private void Clean();
    public void DisablePlayTutorial(SaveInfo info);
    public static string SanitizeFileName(string fileName);
}