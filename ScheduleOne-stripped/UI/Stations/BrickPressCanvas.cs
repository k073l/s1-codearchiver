using System;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.Product;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Stations;
public class BrickPressCanvas : StationInterface<BrickPressCanvas>
{
    [Header("References")]
    public ItemSlotUI[] ProductSlotUIs;
    public ItemSlotUI OutputSlotUI;
    public TextMeshProUGUI InstructionLabel;
    public Button BeginButton;
    public BrickPress Press { get; protected set; }

    protected override void Awake();
    protected virtual void Update();
    private void UpdateUI();
    public void Open(BrickPress press);
    public void Close();
    public void BeginButtonPressed();
    private void BeginTask(ProductItemInstance product);
}