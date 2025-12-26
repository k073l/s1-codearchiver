using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerTasks;
using ScheduleOne.Tools;
using UnityEngine;

namespace ScheduleOne.PlayerScripts;
public class WaterContainerPourable : Pourable
{
    [SerializeField]
    private WaterContainerVisualizer _visuals;
    private WaterContainerInstance _waterContainerItem;
    public void SetupWaterContainerPourable(WaterContainerInstance waterContainer);
    private void OnDestroy();
    protected override void PourAmount(float amount);
}