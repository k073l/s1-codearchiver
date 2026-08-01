using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.ObjectScripts;
public class JukeboxInterface : MonoBehaviour
{
    private const float OpenTime;
    private const float Fov;
    [Header("References")]
    public Jukebox Jukebox;
    public Canvas Canvas;
    public Transform CameraPosition;
    public InteractableObject IntObj;
    public Image PausePlayImage;
    public Button ShuffleButton;
    public Button RepeatButton;
    public Button SyncButton;
    public RectTransform EntryContainer;
    public GameObject AmbientDisplayContainer;
    public TextMeshPro AmbientDisplaySongLabel;
    public TextMeshPro AmbientDisplayTimeLabel;
    public MonoState State;
    [Header("Settings")]
    public Sprite PlaySprite;
    public Sprite PauseSprite;
    public Sprite SongEntryPlaySprite;
    public Sprite SongEntryPauseSprite;
    public Sprite RepeatModeSprite_None;
    public Sprite RepeatModeSprite_Track;
    public Sprite RepeatModeSprite_Queue;
    public Color DeselectedColor;
    public Color SelectedColor;
    public GameObject SongEntryPrefab;
    private List<RectTransform> songEntries;
    public bool IsOpen { get; private set; }

    private void Awake();
    private void FixedUpdate();
    private void UpdateAmbientDisplay();
    private void SetupSongEntries();
    public void Start();
    public void Open();
    public void Close();
    private void OnClose();
    private void Hovered();
    private void Interacted();
    public void PlayPausePressed();
    public void BackPressed();
    public void NextPressed();
    public void ShufflePressed();
    public void RepeatPressed();
    public void SyncPressed();
    public void SongEntryClicked(RectTransform entry);
    private void RefreshSongEntries();
    private void RefreshUI();
    private void RefreshAmbientDisplay();
}