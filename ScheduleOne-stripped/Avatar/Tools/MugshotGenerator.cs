using System;
using System.Collections;
using System.IO;
using ScheduleOne.AvatarFramework;
using ScheduleOne.Core.Avatar;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Avatar.Tools;
public class MugshotGenerator : MonoBehaviour
{
    private const string OutputPath;
    private const int MugshotSize;
    [Header("Assign Appearance and Outfit")]
    [SerializeField]
    private NakedAppearanceObject _appearance;
    [SerializeField]
    private Outfit _outfit;
    [Header("References")]
    [SerializeField]
    private ScheduleOne.AvatarFramework.Avatar _avatar;
    [SerializeField]
    private Transform _cameraPosition;
    private Coroutine _mugshotRoutine;
    public void GenerateMugshotAndWriteToFile(NakedAppearance appearance, Outfit outfit, string folderPath, string mugshotName, Action<string> callback);
    public void GenerateMugshot(NakedAppearance appearance, Outfit outfit, Action<Texture2D> callback);
    private Texture2D GetTexture();
}