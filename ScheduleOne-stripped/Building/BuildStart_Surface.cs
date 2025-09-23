using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Building;
public class BuildStart_Surface : BuildStart_Base
{
    public override void StartBuilding(ItemInstance itemInstance);
    protected virtual SurfaceItem CreateGhostModel(BuildableItemDefinition itemDefinition);
}