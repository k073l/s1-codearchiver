using System.IO;
using System.IO.Compression;
using ScheduleOne.Persistence;
using SFB;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.MainMenu;
[RequireComponent(typeof(Button))]
public class SaveExportButton : MonoBehaviour
{
    public int SaveSlotIndex;
    private void Awake();
    private void Clicked();
    public static string ShowSaveFileDialog(string fileName);
    public static void ZipSaveFolder(string sourceFolderPath, string destinationZipPath);
}