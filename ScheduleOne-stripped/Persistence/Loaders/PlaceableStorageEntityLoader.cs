using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Persistence.Loaders;
public class PlaceableStorageEntityLoader : GridItemLoader
{
    public override string ItemType => typeof(PlaceableStorageData).Name;

    public override void Load(string mainPath);
    public override void Load(DynamicSaveData data);
}