using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.Management;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.UI.Management;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Tools;
public class ManagementClipboard : Singleton<ManagementClipboard>
{
    public bool IsEquipped;
    public const float OpenTime;
    [Header("References")]
    public Transform ClipboardTransform;
    public Camera OverlayCamera;
    public Light OverlayLight;
    public SelectionInfoUI SelectionInfo;
    [Header("Settings")]
    public float ClosedOffset;
    public UnityEvent onClipboardEquipped;
    public UnityEvent onClipboardUnequipped;
    public UnityEvent onOpened;
    public UnityEvent onClosed;
    private Coroutine lerpRoutine;
    private List<IConfigurable> CurrentConfigurables;
    public bool IsOpen { get; protected set; }
    public bool StatePreserved { get; protected set; }

    protected override void Awake();
    private void Update();
    private void Exit(ExitAction exitAction);
    public void Open(List<IConfigurable> selection, ManagementClipboard_Equippable equippable);
    public void Close(bool preserveState = false);
    private void LerpToVerticalPosition(bool open, Action callback);
}