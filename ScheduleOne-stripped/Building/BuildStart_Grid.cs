using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Tiles;
using ScheduleOne.UI;
using ScheduleOne.UI.Input;
using UnityEngine;

namespace ScheduleOne.Building;
public class BuildStart_Grid : BuildStart_Base
{
    private const float GhostModelScale;
    protected GridItem ghostModelClass;
    public override void StartBuilding(ItemInstance itemInstance);
    protected override List<InputPromptsData> GetInputPromptsModules();
    protected virtual GridItem CreateGhostModel(BuildableItemDefinition itemDefinition);
}