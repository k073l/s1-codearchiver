using System.IO;
using System.IO.Compression;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using SFB;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.MainMenu;
[RequireComponent(typeof(Button))]
public class SaveImportButton : MonoBehaviour
{
    public ImportScreen ImportScreen;
    public MainMenuScreen ParentScreen;
    public int SaveSlotIndex;
    public static string TempImportPath => Path.Combine(Singleton<SaveManager>.Instance.IndividualSavesContainerPath, "TempImport");

    private void Awake();
    private void Clicked();
    public static void UnzipSaveFile(string zipFilePath, string destinationFolderPath);
    public static string ShowOpenFileDialog();
}