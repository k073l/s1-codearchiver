using ScheduleOne.EntityFramework;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Property;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Building;
public class BuildUpdate_GrowContainer : BuildUpdate_Grid
{
    private GrowContainer _gc;
    private static bool _showTemps;
    public override void Initialize(GridItem buildableItemClass, ItemInstance itemInstance, GameObject ghostModel);
    private float GetTemperature();
    private bool GetTemperatureVisibility();
    protected override void SetShowTemperatures(bool show, ScheduleOne.Property.Property property);
}