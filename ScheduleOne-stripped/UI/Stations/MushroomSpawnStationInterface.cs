using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.StationFramework;
using ScheduleOne.UI.Items;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Stations;
public class MushroomSpawnStationInterface : Singleton<MushroomSpawnStationInterface>
{
    private const float CameraLerpTime;
    [Header("References")]
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private RectTransform _container;
    [SerializeField]
    private ItemSlotUI _grainBagSlotUI;
    [SerializeField]
    private ItemSlotUI _syringeSlotUI;
    [SerializeField]
    private ItemSlotUI _outputSlotUI;
    [SerializeField]
    private Button _beginButton;
    [SerializeField]
    private TextMeshProUGUI _instructionLabel;
    public Action OnExitStation;
    public bool IsOpen { get; private set; }
    public MushroomSpawnStation Station { get; private set; }

    protected override void Awake();
    protected override void Start();
    private void Exit(ExitAction action);
    private void Update();
    public void Open(MushroomSpawnStation station);
    public void Close(bool exitStation);
    private void StationContentsChanged();
    private void UpdateInstruction();
    private bool CanBeginTask(out string instruction);
    private void UpdateBeginButton();
    private void BeginTask();
}