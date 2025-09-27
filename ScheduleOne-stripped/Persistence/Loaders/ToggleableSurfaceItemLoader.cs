using ScheduleOne.EntityFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class ToggleableSurfaceItemLoader : SurfaceItemLoader
{
    public override string ItemType => typeof(ToggleableSurfaceItemData).Name;

    public override void Load(string mainPath);
    public override void Load(DynamicSaveData data);
}