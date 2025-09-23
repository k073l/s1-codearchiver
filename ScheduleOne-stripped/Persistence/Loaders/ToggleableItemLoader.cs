using ScheduleOne.EntityFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class ToggleableItemLoader : GridItemLoader
{
    public override string ItemType => typeof(ToggleableItemData).Name;

    public override void Load(string mainPath);
    public override void Load(DynamicSaveData data);
}