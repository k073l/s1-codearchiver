using System;
using ScheduleOne.Building;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class SurfaceItemLoader : BuildableItemLoader
{
    public override string ItemType => typeof(SurfaceItemData).Name;

    public override void Load(string mainPath);
    public override void Load(DynamicSaveData data);
    protected SurfaceItem LoadAndCreate(string mainPath);
    protected SurfaceItem LoadAndCreate(SurfaceItemData data);
}