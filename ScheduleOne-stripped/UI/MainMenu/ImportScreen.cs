using System.IO;
using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using ScheduleOne.Persistence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.MainMenu;
public class ImportScreen : MainMenuScreen
{
    [Header("References")]
    public GameObject MainContainer;
    public GameObject FailContainer;
    public Button ConfirmButton;
    public TextMeshProUGUI OrganisationNameLabel;
    public TextMeshProUGUI NetworthLabel;
    public TextMeshProUGUI VersionLabel;
    public TextMeshProUGUI WarningLabel;
    private int slotToOverwrite;
    private SaveInfo saveInfo;
    public void Initialize(int _slotToOverwrite, MainMenuScreen previousScreen);
    public void Cancel();
    public void Confirm();
    private static void CopyFilesRecursively(string sourcePath, string targetPath);
}