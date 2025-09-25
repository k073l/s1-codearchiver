using System;
using System.Collections;
using System.Text.RegularExpressions;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.ScriptableObjects;
using ScheduleOne.UI.Input;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone;
public class CallInterface : Singleton<CallInterface>
{
    public const float TIME_PER_CHAR;
    [Header("References")]
    public Canvas Canvas;
    public RectTransform Container;
    public Image ProfilePicture;
    public TextMeshProUGUI NameLabel;
    public TextMeshProUGUI MainText;
    public RectTransform ContinuePrompt;
    public Animation OpenAnim;
    public AudioSourceController TypewriterEffectSound;
    public CanvasGroup CanvasGroup;
    [Header("Settings")]
    public Color Highlight1Color;
    private int currentCallStage;
    private Coroutine slideRoutine;
    private bool skipRollout;
    private Coroutine rolloutRoutine;
    private string highlight1Hex;
    public Action<PhoneCallData> CallCompleted;
    public PhoneCallData ActiveCallData { get; private set; }
    public bool IsOpen { get; protected set; }

    protected override void Awake();
    private void Update();
    private void Exit(ExitAction exit);
    public void StartCall(PhoneCallData data, CallerID caller, int startStage = 0);
    public void EndCall();
    private void Close();
    public void Continue();
    private void ShowStage(int stageIndex, float initialDelay = 0f);
    private string ProcessText(string text);
    private string GetVisibleText(int charactersShown, string fullText);
    private void SetIsVisible(bool visible);
}