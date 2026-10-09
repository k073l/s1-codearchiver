using System;
using System.Collections;
using FishNet;
using ScheduleOne.Audio;
using ScheduleOne.CharacterCreator;
using ScheduleOne.Clothing;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Networking;
using ScheduleOne.Persistence;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Property;
using ScheduleOne.State;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.Cutscenes;
public class IntroManager : Singleton<IntroManager>
{
    private const float SkipInputTime;
    public int CurrentStep;
    [Header("Settings")]
    public int TimeOfDayOverride;
    [Header("References")]
    public GameObject Container;
    public Transform PlayerInitialPosition;
    public Transform PlayerInitialPosition_AfterRVExplosion;
    public Transform CameraContainer;
    public Animation Anim;
    public GameObject SkipContainer;
    public Image SkipDial;
    public GameObject[] DisableDuringIntro;
    public RV rv;
    public UnityEvent onIntroDone;
    public UnityEvent onIntroDoneAsServer;
    public string MusicName;
    private float currentSkipTime;
    private bool depressed;
    private ScheduleOne.State.State _state;
    public bool IsPlaying { get; protected set; }

    protected override void Awake();
    private void Update();
    [Button]
    public void Play();
    private void PlayMusic();
    public void CharacterCreationDone(CharacterCreatorState characterCreatorOutput);
    public void PassedStep(int stepIndex);
}