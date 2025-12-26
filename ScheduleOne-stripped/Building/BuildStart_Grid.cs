using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Tiles;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Building;
public class BuildStart_Grid : BuildStart_Base
{
    protected GridItem ghostModelClass;
    public override void StartBuilding(ItemInstance itemInstance);
    protected virtual string GetInputPromptsModuleName();
    protected virtual GridItem CreateGhostModel(BuildableItemDefinition itemDefinition);
}