using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Persistence.Loaders;
public class MushroomBedLoader : GridItemLoader
{
    public override string ItemType => typeof(MushroomBedData).Name;

    public override void Load(DynamicSaveData data);
}