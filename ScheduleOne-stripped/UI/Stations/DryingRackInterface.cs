using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Stations;
public class DryingRackInterface : StationInterface<DryingRackInterface>
{
    [Header("References")]
    public UIPanel ProgressContainerPanel;
    public ItemSlotUI InputSlotUI;
    public ItemSlotUI OutputSlotUI;
    public TextMeshProUGUI InstructionLabel;
    public TextMeshProUGUI CapacityLabel;
    public Button InsertButton;
    public RectTransform IndicatorContainer;
    public RectTransform[] IndicatorAlignments;
    [Header("Prefabs")]
    public DryingOperationUI IndicatorPrefab;
    private List<DryingOperationUI> operationUIs;
    public DryingRack Rack { get; protected set; }

    protected override void Start();
    private void MinPass();
    protected virtual void Update();
    private void UpdateUI();
    private void UpdateDryingOperations();
    private void UpdateQuantities();
    public void Open(DryingRack rack);
    public void Close();
    private void CreateOperationUI(DryingOperation operation);
    private void DestroyOperationUI(DryingOperation operation);
    public void Insert();
}