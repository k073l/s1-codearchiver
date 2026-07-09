using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.Input;
using ScheduleOne.Vehicles;
using TMPro;
using UnityEngine;

namespace ScheduleOne.UI;
public class VehicleCanvas : Singleton<VehicleCanvas>
{
    [Header("References")]
    public Canvas Canvas;
    public TextMeshProUGUI SpeedText;
    public InputPromptsData VehiclePrompts;
    public InputPromptsData DriverPrompts;
    private LandVehicle currentVehicle;
    protected override void Start();
    private void Subscribe();
    private void Update();
    private void LateUpdate();
    private void VehicleEntered(LandVehicle veh);
    private void VehicleExited(LandVehicle veh);
    private void UpdateSpeedText();
}