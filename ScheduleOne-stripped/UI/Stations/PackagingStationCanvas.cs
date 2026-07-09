using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.Product.Packaging;
using ScheduleOne.UI.Items;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Stations;
public class PackagingStationCanvas : StationInterface<PackagingStationCanvas>
{
    public bool ShowHintOnOpen;
    public bool ShowShiftClickHint;
    public PackagingStation.EMode CurrentMode;
    public Color InstructionWarningColor;
    [Header("References")]
    public ItemSlotUI PackagingSlotUI;
    public ItemSlotUI ProductSlotUI;
    public ItemSlotUI OutputSlotUI;
    public TextMeshProUGUI InstructionLabel;
    public Button BeginButton;
    public Animation ModeAnimation;
    public TextMeshProUGUI ButtonLabel;
    public PackagingStation Station { get; protected set; }

    protected override void Awake();
    protected virtual void Update();
    private void UpdateUI();
    public void Open(PackagingStation station);
    public void Close();
    public void BeginButtonPressed();
    private void BeginPackagingTask();
    public void RepeatPackagingTask();
    public void ToggleMode();
    public void SetMode(PackagingStation.EMode mode);
}