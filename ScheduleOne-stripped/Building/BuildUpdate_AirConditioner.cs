using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Property;
using ScheduleOne.Temperature;
using UnityEngine;

namespace ScheduleOne.Building;
public class BuildUpdate_AirConditioner : BuildUpdate_Grid
{
    private AirConditioner _ac;
    private AirConditioner.EMode _currentMode;
    private ScheduleOne.Property.Property _currentProperty;
    public override void Initialize(GridItem buildableItemClass, ItemInstance itemInstance, GameObject ghostModel);
    protected override void Update();
    private void CycleACMode();
    private void SetACMode(AirConditioner.EMode mode);
    protected override void OnPlacedObjectPreSpawn(GridItem item);
    protected override void OnClosestIntersectionChanged(TileIntersection previous, TileIntersection current);
    private void AddToProperty(ScheduleOne.Property.Property property);
    public void RemoveFromPropery();
}