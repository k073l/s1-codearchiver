using System;
using System.IO;
using ScheduleOne.DevUtilities;
using ScheduleOne.ExtendedComponents;
using ScheduleOne.Networking;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.MainMenu;
public class SetupScreen : MainMenuScreen
{
    public const string DEFAULT_SAVE_PATH;
    [Header("References")]
    public GameInputField InputField;
    public Button StartButton;
    public RectTransform SkipIntroContainer;
    public Toggle SkipIntroToggle;
    public RectTransform NotHostWarning;
    private int slotIndex;
    protected virtual void Start();
    public void Initialize(int index);
    private void Update();
    public void StartGame();
    private bool IsInputValid();
    private void ClearFolderContents(string folderPath);
    private void CopyDefaultSaveToFolder(string folderPath);
    private static void CopyFilesRecursively(string sourcePath, string targetPath);
}