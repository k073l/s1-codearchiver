using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.Management;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.StationFramework;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Persistence.Loaders;
public class SpawnStationLoader : GridItemLoader
{
    public override string ItemType => typeof(SpawnStationData).Name;

    public override void Load(DynamicSaveData data);
}