using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.UI.Shop;
using TMPro;
using UnityEngine;

namespace ScheduleOne;
public class DebugInterface : MonoBehaviour
{
    public UIScreen MainScreen;
    public UIScreen SecondScreen;
    public UIPanel GridPanel;
    public Transform GridPanelContainer;
    public UISelectable ButtonPrefab;
    public UIPanel horizontalPanel;
    public TextMeshProUGUI DebugText;
    public UIHorizontalSelector testHorizontalSelector;
    public UIPopupSelector testPopupSelector;
    public Sprite testIcon;
    private void Start();
    private void Update();
    private void OpenConfirmationMenu();
    private void OpenModifyAmountMenu();
    private void SetupGridPanel();
    public void ApplyFilter(int[] filters);
    private void HandleInputDeviceChanged(GameInput.InputDeviceType type);
}