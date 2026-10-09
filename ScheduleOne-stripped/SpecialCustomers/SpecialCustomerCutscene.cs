using System.Collections;
using ScheduleOne.Audio;
using ScheduleOne.Core;
using ScheduleOne.Core.Audio;
using ScheduleOne.Cutscenes;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.Weather;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers;
public class SpecialCustomerCutscene : Cutscene, ISleepEvent
{
    [Header("Settings")]
    [SerializeField]
    private bool _overrideTimeOfDay;
    [Conditional("_overrideTimeOfDay", false)]
    [SerializeField]
    private int _timeOfDayOverride;
    [Header("Cutscene Timing")]
    [Tooltip("How long to wait before starting the cutscene? This gives the NPCs time to get into position before the cutscene starts.")]
    [SerializeField]
    private float _prewarmDuration;
    [SerializeField]
    [Range(0f, 2f)]
    private float _fadeInDuration;
    [SerializeField]
    [Range(0f, 2f)]
    private float _fadeOutDuration;
    [Header("Cutscene Music")]
    [SerializeField]
    private AudioClip _cutsceneClip;
    [SerializeField]
    private float _cutsceneMusicVolume;
    private AudioSourceController _cutsceneAudioSource;
    public bool IsInProgress { get; private set; }
    public int EventOrder { get; private set; } = 10;

    public void StartEvent();
    public void BeginFadeIn();
    public void BeginFadeOut();
    protected override void End();
}