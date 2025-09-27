using System;
using ScheduleOne.Building;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class GridItemLoader : BuildableItemLoader
{
    public override string ItemType => typeof(GridItemData).Name;

    public override void Load(string mainPath);
    public override void Load(DynamicSaveData data);
    protected GridItem LoadAndCreate(string mainPath);
    protected GridItem LoadAndCreate(GridItemData data);
}