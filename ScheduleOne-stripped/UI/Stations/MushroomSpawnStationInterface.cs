using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerTasks;
using ScheduleOne.StationFramework;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Stations;
public class MushroomSpawnStationInterface : StationInterface<MushroomSpawnStationInterface>
{
    [Header("References")]
    [SerializeField]
    private Button _beginButton;
    [SerializeField]
    private TextMeshProUGUI _instructionLabel;
    [SerializeField]
    private ItemSlotUI _grainBagSlotUI;
    [SerializeField]
    private ItemSlotUI _syringeSlotUI;
    [SerializeField]
    private ItemSlotUI _outputSlotUI;
    public MushroomSpawnStation Station { get; private set; }

    protected override void Awake();
    public void Open(MushroomSpawnStation station);
    public void OnBeginButtonPressed();
    public void Close();
    private void StationContentsChanged();
    private void UpdateInstruction();
    private bool CanBeginTask(out string instruction);
    private void UpdateBeginButton();
    private void BeginTask();
}