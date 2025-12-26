using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.Growing;
public class PotMoistureDisplay : GrowContainerMoistureDisplay
{
    [SerializeField]
    private GameObject _temperatureBoostIndicator;
    private Pot _pot;
    protected override void Awake();
    protected override void UpdateCanvasContents();
}