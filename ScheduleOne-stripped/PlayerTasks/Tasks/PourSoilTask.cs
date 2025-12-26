using ScheduleOne.DevUtilities;
using ScheduleOne.Growing;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts.Soil;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks.Tasks;
public class PourSoilTask : GrowContainerPourTask
{
    private SoilDefinition _soilDefinition;
    private PourableSoil _pourableSoil;
    private Collider _hoveredTopCollider;
    private GrowContainer _growContainer;
    public PourSoilTask(GrowContainer growContainer, ItemInstance itemInstance, Pourable pourablePrefab);
    protected override void OnInitialPour();
    public override void Update();
    public override void StopTask();
    protected override void UpdateCursor();
    private void UpdateHover();
    private Collider GetHoveredTopCollider();
}