using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Temperature;
using ScheduleOne.UI;
using ScheduleOne.Variables;
using UnityEngine;

namespace ScheduleOne.Building;
public class BuildStart_AirConditioner : BuildStart_Grid
{
    private AirConditioner ac;
    public override void StartBuilding(ItemInstance itemInstance);
    protected override string GetInputPromptsModuleName();
}