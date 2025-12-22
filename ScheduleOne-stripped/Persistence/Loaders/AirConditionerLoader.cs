using ScheduleOne.EntityFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Temperature;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class AirConditionerLoader : GridItemLoader
{
    public override string ItemType => typeof(AirConditionerData).Name;

    public override void Load(DynamicSaveData data);
}