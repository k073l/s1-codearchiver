using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.Tools;
public class WaterContainerVisualizer : MonoBehaviour
{
    [SerializeField]
    private TransformLerp[] _waterTransformLerps;
    private WaterContainerInstance _assignedWaterContainer;
    public void AssignWaterContainer(WaterContainerInstance waterContainer);
    public void UnassignWaterContainer();
    private void WaterContainerChanged();
    private void SetFillLevel(float normalizedFillLevel);
}