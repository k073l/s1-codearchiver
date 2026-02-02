using System.Collections;
using System.Collections.Generic;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ScheduleOne.UI;
public class ConsoleUI : MonoBehaviour
{
    [Header("References")]
    public Canvas canvas;
    public TMP_InputField InputField;
    public GameObject Container;
    private static List<string> _commandHistory;
    private int _currentCommandIndex;
    public bool IS_CONSOLE_ENABLED { get; }

    private void Awake();
    private void Update();
    private void UpdateCommandHistory();
    private void Exit(ExitAction exitAction);
    public void SetIsOpen(bool open);
    public void Submit(string val);
}