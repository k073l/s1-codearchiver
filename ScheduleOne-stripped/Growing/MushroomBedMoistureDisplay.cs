using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.Growing;
public class MushroomBedMoistureDisplay : GrowContainerMoistureDisplay
{
    [SerializeField]
    private GameObject _tooHotIndicator;
    private MushroomBed _bed;
    protected override void Awake();
    protected override void UpdateCanvasContents();
}