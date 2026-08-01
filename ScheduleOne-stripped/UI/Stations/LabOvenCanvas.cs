using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.StationFramework;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Stations;
public class LabOvenCanvas : StationInterface<LabOvenCanvas>
{
    [Header("References")]
    public ItemSlotUI IngredientSlotUI;
    public ItemSlotUI OutputSlotUI;
    public TextMeshProUGUI InstructionLabel;
    public TextMeshProUGUI ErrorLabel;
    public Button BeginButton;
    public TextMeshProUGUI BeginButtonLabel;
    public RectTransform ProgressContainer;
    public Image IngredientIcon;
    public Image ProgressImg;
    public Image ProductIcon;
    public LabOven Oven { get; protected set; }

    protected override void Awake();
    protected virtual void Update();
    private void UpdateUI();
    public void Open(LabOven oven);
    public void Close();
    public void BeginButtonPressed();
    private void BeginTask();
    public bool CanBegin();
    private bool DoesOvenOutputHaveSpace();
    private void RefreshActiveOperation();
}