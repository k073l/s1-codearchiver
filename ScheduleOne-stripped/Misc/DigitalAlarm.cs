using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using TMPro;
using UnityEngine;

namespace ScheduleOne.Misc;
public class DigitalAlarm : MonoBehaviour
{
    public const float FLASH_FREQUENCY;
    public MeshRenderer ScreenMesh;
    public int ScreenMeshMaterialIndex;
    public TextMeshPro ScreenText;
    public bool FlashScreen;
    [Header("Settings")]
    public bool DisplayCurrentTime;
    public Material ScreenOffMat;
    public Material ScreenOnMat;
    private bool isLit;
    private void Start();
    private void OnDestroy();
    public void SetScreenLit(bool lit);
    public void DisplayText(string text);
    public void DisplayMinutes(int mins);
    private void MinPass();
    private void FixedUpdate();
}