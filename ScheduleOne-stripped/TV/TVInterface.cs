using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.UI.Compass;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.TV;
public class TVInterface : MonoBehaviour
{
    public const float OPEN_TIME;
    public const float FOV;
    public List<Player> Players;
    [Header("References")]
    public Canvas Canvas;
    public Transform CameraPosition;
    public TVHomeScreen HomeScreen;
    public TextMeshPro TimeLabel;
    public TextMeshPro Daylabel;
    public UnityEvent<Player> onPlayerAdded;
    public UnityEvent<Player> onPlayerRemoved;
    public bool IsOpen { get; private set; }

    public void Awake();
    public void Start();
    private void OnDestroy();
    private void MinPass();
    public void Open();
    public void Close();
    private void Exit(ExitAction action);
    public bool CanOpen();
    public void AddPlayer(Player player);
    public void RemovePlayer(Player player);
}