using System;
using System.Collections.Generic;
using FishNet.Object;
using ScheduleOne.Building;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class ProceduralGridItemLoader : BuildableItemLoader
{
    public override string ItemType => typeof(ProceduralGridItemData).Name;
    public override int LoadOrder => 100;

    public override void Load(string mainPath);
    public override void Load(DynamicSaveData data);
    protected ProceduralGridItem LoadAndCreate(string mainPath);
    protected ProceduralGridItem LoadAndCreate(ProceduralGridItemData data);
}