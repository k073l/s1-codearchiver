using System;
using System.Collections.Generic;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerTasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Stations;
public class CauldronInterface : StationInterface<CauldronInterface>
{
    [Header("References")]
    public List<ItemSlotUI> IngredientSlotUIs;
    public ItemSlotUI LiquidSlotUI;
    public ItemSlotUI OutputSlotUI;
    public TextMeshProUGUI InstructionLabel;
    public Button BeginButton;
    public Cauldron Cauldron { get; protected set; }

    protected override void Awake();
    protected virtual void Update();
    private void UpdateUI();
    public void Open(Cauldron cauldron);
    public void Close();
    public void BeginButtonPressed();
    private void BeginTask();
}